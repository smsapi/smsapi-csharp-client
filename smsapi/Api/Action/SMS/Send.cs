using System;
using System.Collections.Specialized;
using System.IO;
using System.Runtime.Serialization.Json;

namespace SMSApi.Api.Action
{
    public class SMSSend : Send
    {
        public SMSSend() : base() { }

        protected override string Uri() { return "sms.do"; }

        protected override NameValueCollection Values()
        {
            NameValueCollection collection = new NameValueCollection();

            collection.Add("format", "json");

            collection.Add("username", client.GetUsername());
            collection.Add("password", client.GetPassword());

            if (Sender != null) 
                collection.Add("from", Sender);

            if (To != null)
                collection.Add("to", string.Join(",", To));

            if (Group != null)
                collection.Add("group", Group);

            collection.Add("message", Text);

            collection.Add("single", (Single ? "1" : "0") );
            collection.Add("nounicode", (NoUnicode ? "1" : "0") );
            collection.Add("flash", (Flash ? "1" : "0") );
            collection.Add("fast", (Fast ? "1" : "0") );

            if (DataCoding != null)
                collection.Add("datacoding", DataCoding);

            if (MaxParts > 0)
                collection.Add("max_parts", MaxParts.ToString());

            if (DateSent != null)
                collection.Add("date", DateSent);

            if (DateExpire != null)
                collection.Add("expiration_date", DateExpire);

            if (Partner != null)
                collection.Add("partner_id", Partner);

            collection.Add("encoding", Encoding);

            if (Test == true)
                collection.Add("test", "1");

            if (Idx != null && Idx.Length > 0)
            {
                collection.Add("check_idx", (IdxCheck ? "1" : "0"));
                collection.Add("idx", string.Join("|", Idx));
            }

            return collection;
        }

        protected override void Validate()
        {
            if( To != null && Group != null )
            {
                throw new ArgumentException("Cannot use 'to' and 'group' at the same time!");
            }

            if (Text == null)
            {
                throw new ArgumentException("Cannot send message without text!");
            }
        }

        private string Text;
        private string DateExpire;
        private string Sender;
        private bool Single = false;
        private bool NoUnicode = false;
        private string DataCoding;
        private string udh;
        private bool Flash = false;
        private string Encoding = "UTF-8";
        private bool Fast = false;
        private int MaxParts = 0;

        public SMSSend SetTo(string to)
        {
            this.To = new string[] { to };
            return this;
        }

        public SMSSend SetTo(string[] to)
        {
            this.To = to;
            return this;
        }

        public SMSSend SetGroup(string group)
        {
            this.Group = group;
            return this;
        }

        public SMSSend SetDateSent(string data)
        {
            this.DateSent = data;
            return this;
        }

        public SMSSend SetDateSent(DateTime data)
        {
            this.DateSent = data.ToString("yyyy-MM-ddTHH:mm:ssK");
            return this;
        }

        public SMSSend SetIDx(string idx)
        {
            this.Idx = new string[] { idx };
            return this;
        }

        public SMSSend SetIDx(string[] idx)
        {
            this.Idx = idx;
            return this;
        }

        public SMSSend SetCheckIDx(bool check = true)
        {
            this.IdxCheck = check;
            return this;
        }

        public SMSSend SetPartner(string partner)
        {
            this.Partner = partner;
            return this;
        }

        public SMSSend SetText(string text)
        {
            this.Text = text;
            return this;
        }

        public SMSSend SetDateExpire(string data)
        {
            this.DateExpire = data;
            return this;
        }

        public SMSSend SetDateExpire(DateTime data)
        {
            this.DateExpire = data.ToString("yyyy-MM-ddTHH:mm:ssK");
            return this;
        }

        public SMSSend SetSender(string sender)
        {
            this.Sender = sender;
            return this;
        }

        public SMSSend SetSingle(bool single = true)
        {
            this.Single = single;
            return this;
        }

        public SMSSend SetNoUnicode(bool noUnicode = true)
        {
            this.NoUnicode = noUnicode;
            return this;
        }

        public SMSSend SetDataCoding(string dataCoding)
        {
            this.DataCoding = dataCoding;
            return this;
        }

        public SMSSend SetUdh(string udh)
        {
            this.udh = udh;
            return this;
        }

        public SMSSend SetFlash(bool flash = true)
        {
            this.Flash = flash;
            return this;
        }

/*
        public SMSSend SetEncoding(string encoding)
        {
            this.encoding = encoding;
            return this;
        }
*/

        public SMSSend SetFast(bool fast = true)
        {
            this.Fast = fast;
            return this;
        }

        public SMSSend SetTest(bool test = true)
        {
            this.Test = test;
            return this;
        }
    }
}
