using System;
using System.Collections.Generic;
using System.Text;

namespace Spiffy
{
    public class SpiffyAlertEventArgs : EventArgs
    {
        public string url, messageid;

        public SpiffyAlertEventArgs(string urlData, string messageidData)
        {
            url = urlData;
            messageid = messageidData; //maybe used later when i figure it out
        }

        public string Url {            
            get 
            {
                return url; 
            }
            set
            {
                url = value;
            }

        }

        public string Messageid
        {
            get
            {
                return messageid;
            }
            set
            {
                messageid = value;
            }

        }
    }
}
