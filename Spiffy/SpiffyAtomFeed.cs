﻿using System;
using System.Xml;
using System.Text;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Security;

namespace Spiffy
{

    /// <summary>
    /// Provides an easy method of retreiving and programming against gmail atom feeds.
    /// </summary>
    public class SpiffyAtomFeed
    {

        #region Private Variables

        private static string _gmailFeedUrl = "https://mail.google.com/mail/feed/atom";
        private string _gmailUserName = string.Empty;
        private SecureString _gmailPassword = null; //060 (was empty)
        private string _feedLabel = string.Empty;
        private string _title = string.Empty;
        private string _message = string.Empty;
        private DateTime _modified = DateTime.MinValue;
        private XmlDocument _feedXml = null;

        private AtomFeedEntryCollection _entryCol = null;

        #endregion


        /// <summary>
        /// Constructor, creates the gmail atom feed object. 
        /// <note>
        /// Creating the object does not get the feed, the <c>GetFeed</c> method must be called to get the current feed.
        /// </note>
        /// </summary>
        /// <param name="gmailUserName">The username of the gmail account that the message will be sent through</param>
        /// <param name="gmailPassword">The password of the gmail account that the message will be sent through</param>
        public SpiffyAtomFeed(string gmailUserName, SecureString gmailPassword)
        {
            _gmailUserName = gmailUserName;
            _gmailPassword = gmailPassword;
            _entryCol = new AtomFeedEntryCollection();
        }

        /// <summary>
        /// Gets the current atom feed for the specified account and loads all properties and collections with the feed data. Any existing data will be replaced by the new feed.
        /// <note>
        /// If the <c>FeedLabel</c> property equals <c>string.Empty</c> the feed for the inbox will be retreived.
        /// </note>
        /// </summary>
        public void GetFeed()
        {
            StringBuilder sBuilder = new StringBuilder();
            byte[] buffer = new byte[8192];
            int byteCount = 0;

            try
            {
                string url = SpiffyAtomFeed.FeedUrl;

                if (this.FeedLabel != string.Empty)
                {
                    url += (url.EndsWith("/")) ? string.Empty : "/";
                    url += this.FeedLabel;
                }

                System.Net.NetworkCredential credentials = new NetworkCredential(this.GmailUserName, this.GmailPassword);

                WebRequest webRequest = WebRequest.Create(url);

                //throws System.UriFormatException in Console when proxy is unreachable or invalid
                switch (Properties.Settings.Default.proxyEnabled)
                {
                    case true:
                        webRequest.Proxy = SpiffyStuff.userProxy();
                        break;

                    case false:
                        webRequest.Proxy = null; 
                        break;
                }
                webRequest.Credentials = credentials;

                WebResponse webResponse = webRequest.GetResponse();
                Stream stream = webResponse.GetResponseStream();

                while ((byteCount = stream.Read(buffer, 0, buffer.Length)) > 0)
                    sBuilder.Append(Encoding.UTF8.GetString(buffer, 0, byteCount));
                    //sBuilder.Append(Encoding.ASCII.GetString(buffer, 0, byteCount));             

                _feedXml = new XmlDocument();
                _feedXml.LoadXml(sBuilder.ToString());
                
                stream.Close(); //close stream

                loadFeedEntries();
            }
            catch (Exception ex) //changed from webexception in 060 to hide xml errors too
            {
                //TODO: add error handling
                //throw ex;
                SpiffyStuff.LogExceptionInfo(ex, "getFeed()", true);
            }
        }


        /// <summary>
        /// Loads the <c>FeedEntries</c> collection from the data retreived in the feed.
        /// </summary>
        private void loadFeedEntries()
        {
            XmlNamespaceManager nsm = new XmlNamespaceManager(_feedXml.NameTable);
            nsm.AddNamespace("atom", "http://purl.org/atom/ns#");

            _title = _feedXml.SelectSingleNode("/atom:feed/atom:title", nsm).InnerText;
            _message = _feedXml.SelectSingleNode("/atom:feed/atom:tagline", nsm).InnerText;
            //_modified = DateTime.Parse(_feedXml.SelectSingleNode("/atom:feed/atom:modified", nsm).InnerText);
            _modified = DateTime.Parse(Regex.Replace(_feedXml.SelectSingleNode("/atom:feed/atom:modified", nsm).InnerText, @"T24", "T00"));

            int nodeCount = _feedXml.SelectNodes("//atom:entry", nsm).Count;
            string baseXPath = string.Empty;
            _entryCol.Clear();

            for (int i = 1; i <= nodeCount; i++)
            {
                baseXPath = "/atom:feed/atom:entry[position()=" + i.ToString() + "]/atom:";
                try
                {
                    AtomFeedEntry atomEntry = new AtomFeedEntry(
                        _feedXml.SelectSingleNode(baseXPath + "title", nsm).InnerText,
                        _feedXml.SelectSingleNode(baseXPath + "summary", nsm).InnerText,
                        _feedXml.SelectSingleNode(baseXPath + "author/atom:name", nsm).InnerText,
                        _feedXml.SelectSingleNode(baseXPath + "author/atom:email", nsm).InnerText,
                        _feedXml.SelectSingleNode(baseXPath + "id", nsm).InnerText,
                        //DateTime.Parse(_feedXml.SelectSingleNode(baseXPath + "issued", nsm).InnerText));
                        DateTime.Parse(Regex.Replace(_feedXml.SelectSingleNode(baseXPath + "issued", nsm).InnerText, @"T24", "T00")));

                    _entryCol.Add(atomEntry);
                }
                catch (NullReferenceException nre4) //Spiffy -> is catched when no sender is known (add 'unknown sender')
                {
                    AtomFeedEntry atomEntry = new AtomFeedEntry(
                        _feedXml.SelectSingleNode(baseXPath + "title", nsm).InnerText,
                        _feedXml.SelectSingleNode(baseXPath + "summary", nsm).InnerText,
                        SpiffyText.String00317, //unknown sender
                        SpiffyText.String00318, //unknown address
                        _feedXml.SelectSingleNode(baseXPath + "id", nsm).InnerText,
                                            //DateTime.Parse(_feedXml.SelectSingleNode(baseXPath + "issued", nsm).InnerText));
                        DateTime.Parse(Regex.Replace(_feedXml.SelectSingleNode(baseXPath + "issued", nsm).InnerText, @"T24", "T00")));

                    _entryCol.Add(atomEntry);
                }

            }
        }


        /// <summary>
        /// Collection containing the feeds entry objects
        /// </summary>
        public AtomFeedEntryCollection FeedEntries
        {
            get { return _entryCol; }
        }

        /// <summary>
        /// The username of the gmail account that the message will be sent through
        /// </summary>
        public string GmailUserName
        {
            get { return _gmailUserName; }
            set { _gmailUserName = value; }
        }

        /// <summary>
        /// The password of the gmail account that the message will be sent through
        /// </summary>
        public SecureString GmailPassword
        {
            get { return _gmailPassword; }
            set { _gmailPassword = value; }
        }

        /// <summary>
        /// The label to retreive the feeds from. To get the new inbox messages set this to <c>string.Empty</c>.
        /// </summary>
        public string FeedLabel
        {
            get { return _feedLabel; }
            set { _feedLabel = value; }
        }

        /// <summary>
        /// Returns the feed data retreived from gmail
        /// </summary>
        public XmlDocument FeedXml
        {
            get { return _feedXml; }
        }

        /// <summary>
        /// Returns the feed data retreived from gmail
        /// </summary>
        public string RawFeed
        {
            get { return _feedXml.OuterXml; }
        }

        /// <summary>
        /// Returns the <c>/feed/tagline</c> property
        /// </summary>
        public string Message
        {
            get { return _message; }
        }

        /// <summary>
        /// Returns the <c>/feed/title</c> property
        /// </summary>
        public string Title
        {
            get { return _title; }
        }

        /// <summary>
        /// Returns the <c>/feed/modified</c> property
        /// </summary>
        public DateTime Modified
        {
            get { return _modified; }
        }

        /// <summary>
        /// Base Url for the gmail atom feed, the default is "https://mail.google.com/mail/feed/atom"
        /// </summary>
        public static string FeedUrl
        {
            get { return _gmailFeedUrl; }
            set { _gmailFeedUrl = value; }
        }



        /// <summary>
        /// Class for storing the <c>/feed/entry</c> items
        /// </summary>
        public class AtomFeedEntry
        {
            private string _subject = string.Empty;
            private string _summary = string.Empty;
            private string _fromName = string.Empty;
            private string _fromEmail = string.Empty;
            private string _id = string.Empty;
            private DateTime _received = DateTime.MinValue;

            /// <summary>
            /// Constructor, loads the object
            /// </summary>
            /// <param name="subject"><c>/feed/entry/title</c> property</param>
            /// <param name="summary"><c>/feed/entry/summary</c> property</param>
            /// <param name="fromName"><c>/feed/entry/author/name</c> property</param>
            /// <param name="fromEmail"><c>/feed/entry/author/email</c> property</param>
            /// <param name="id"><c>/feed/entry/id</c> property</param>
            /// <param name="received"><c>/feed/entry/issued</c> property</param>
            public AtomFeedEntry(string subject, string summary, string fromName, string fromEmail, string id, DateTime received)
            {
                _subject = subject;
                _summary = summary;
                _fromName = fromName;
                _fromEmail = fromEmail;               
                _id = id;
                _received = received;
            }

            /// <summary>
            /// Returns the <c>/feed/entry/title</c> property
            /// </summary>
            public string Subject { get { return _subject; } }

            /// <summary>
            /// Returns the <c>/feed/entry/summary</c> property
            /// </summary>
            public string Summary { get { return _summary; } }

            /// <summary>
            /// Returns the <c>/feed/entry/author/name</c> property
            /// </summary>
            public string FromName { get { return _fromName; } }

            /// <summary>
            /// Returns the <c>/feed/entry/author/email</c> property
            /// </summary>
            public string FromEmail { get { return _fromEmail; } }

            /// <summary>
            /// Returns the <c>/feed/entry/id</c> property
            /// </summary>
            public string Id { get { return _id; } }

            /// <summary>
            /// Returns the <c>/feed/entry/issued</c> property
            /// </summary>
            public DateTime Received { get { return _received; } }

        } //AtomFeedEntry


        /// <summary>
        /// Collection of <c>AtomFeedEntry</c> objects
        /// </summary>
        public class AtomFeedEntryCollection : System.Collections.CollectionBase
        {

            /// <summary>
            /// Indexer for retreiving an <c>AtomFeedEntry</c> object
            /// </summary>
            public AtomFeedEntry this[int index]
            {
                get { return this.List[index] as AtomFeedEntry; }
                set { this.List[index] = value; }
            }

            /// <summary>
            /// Adds an <c>AtomFeedEntry</c> object to the collection
            /// </summary>
            /// <param name="feedEntry"><c>AtomFeedEntry</c> to add</param>
            public void Add(AtomFeedEntry feedEntry) { this.List.Add(feedEntry); }

            /// <summary>
            /// Clears the collection
            /// </summary>
            public new void Clear() { this.List.Clear(); }

            /// <summary>
            /// Returns true if the collection contains the specified object
            /// </summary>
            /// <param name="feedEntry"><c>AtomFeedEntry</c> to find</param>
            /// <returns></returns>
            public bool Contains(AtomFeedEntry feedEntry) { return this.List.Contains(feedEntry); }

            /// <summary>
            /// Returns the position of the first of the <c>AtomFeedEntry</c> object. If it is not found then <c>-1</c> is returned.
            /// </summary>
            /// <param name="feedEntry"><c>AtomFeedEntry</c> to find</param>
            /// <returns></returns>
            public int IndexOf(AtomFeedEntry feedEntry) { return this.List.IndexOf(feedEntry); }

            /// <summary>
            /// Inserts an <c>AtomFeedEntry</c> at the specified position
            /// </summary>
            /// <param name="index">Position to insert at</param>
            /// <param name="feedEntry"><c>AtomFeedEntry</c> to insert</param>
            public void Insert(int index, AtomFeedEntry feedEntry) { this.List.Insert(index, feedEntry); }

            /// <summary>
            /// Removes an <c>AtomFeedEntry</c> from the collection
            /// </summary>
            /// <param name="feedEntry"><c>AtomFeedEntry</c> to be removed</param>
            public void Remove(AtomFeedEntry feedEntry) { this.List.Remove(feedEntry); }

            /// <summary>
            /// Removes an <c>AtomFeedEntry</c> object from the specified position
            /// </summary>
            /// <param name="index">Position of <c>AtomFeedEntry</c> to be removed</param>
            public new void RemoveAt(int index) { this.List.RemoveAt(index); }

        } //AtomFeedEntryCollection

    } //GmailAtomFeed
}
