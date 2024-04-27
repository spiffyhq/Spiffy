using System;
using System.Collections.Generic;
using System.Text;

namespace Spiffy
{
    public partial class SpiffyAccount
    {
        //account properties
        protected string name, url, customalertPath;
        protected int unreadCounter, totalUnread;
        protected bool hasNewMail, isApps, pwdSaved, hasCustomAlert;

        /// <summary>
        /// Get/Set the account Name
        /// </summary>
        public string AccountName
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        /// <summary>
        /// Get/Set the account Url for opening Inbox
        /// </summary>
        public string AccountUrl
        {
            get
            {
                return url;
            }
            set
            {
                url = value;
            }
        }

        /// <summary>
        /// Get/Set the custom alert path if used
        /// </summary>
        public string AccountCustomAlertPath
        {
            get
            {
                return customalertPath;
            }
            set
            {
                customalertPath = value;
            }
        }

        /// <summary>
        /// Get/Set the bool if there is new mail for this account
        /// </summary>
        public bool AccountHasNewMail
        {
            get
            {
                return hasNewMail;
            }
            set
            {
                hasNewMail = value;
            }
        }

        /// <summary>
        /// Get/Set the bool if there is a custom alert set for the account
        /// </summary>
        public bool AccountHasCustomAlert
        {
            get
            {
                return hasCustomAlert;
            }
            set
            {
                hasCustomAlert = value;
            }
        }

        /// <summary>
        /// Get/Set the bool if its a google apps account
        /// </summary>
        public bool IsAppsAccount
        {
            get
            {
                return isApps;
            }
            set
            {
                isApps = value;
            }
        }

        /// <summary>
        /// Get/Set the bool if this accounts password is saved
        /// </summary>
        public bool PasswordSaved
        {
            get
            {
                return pwdSaved;
            }
            set
            {
                pwdSaved = value;
            }
        }

        /// <summary>
        /// Get/Set the unread e-mail Counter
        /// </summary>
        public int AccountUnread
        {
            get
            {
                return unreadCounter;
            }
            set
            {
                unreadCounter = value;
            }
        }

        /// <summary>
        /// Get/Set the total unread e-mail count
        /// </summary>
        public int AccountTotalUnread
        {
            get
            {
                return totalUnread;
            }
            set
            {
                totalUnread = value;
            }
        }
    }
}
