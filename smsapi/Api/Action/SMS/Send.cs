using System;
using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
    public class SMSSend : Send
    {
        private string DataCoding;
        private string DateExpire;
        private bool Details = true;
        private string Encoding = "UTF-8";
        private bool Fast;
        private bool Flash;
        private int MaxParts;
        private bool Normalize;
        private bool NoUnicode;
        private string[] Params;
        private string Sender;
        private bool Single;
        private string Text;

        protected override RequestMethod Method => RequestMethod.POST;

        public SMSSend SetCheckIDx(bool check = true)
        {
            IdxCheck = check;
            return this;
        }

        public SMSSend SetDataCoding(string dataCoding)
        {
            DataCoding = dataCoding;
            return this;
        }

        public SMSSend SetDateExpire(string data)
        {
            DateExpire = data;
            return this;
        }

        public SMSSend SetDateExpire(DateTime data)
        {
            DateExpire = data.ToString("yyyy-MM-ddTHH:mm:ssK");
            return this;
        }

        public SMSSend SetDateSent(string data)
        {
            DateSent = data;
            return this;
        }

        public SMSSend SetDateSent(DateTime data)
        {
            DateSent = data.ToString("yyyy-MM-ddTHH:mm:ssK");
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
            Fast = fast;
            return this;
        }

        public SMSSend SetFlash(bool flash = true)
        {
            Flash = flash;
            return this;
        }

        public SMSSend SetGroup(string group)
        {
            Group = group;
            return this;
        }

        public SMSSend SetIDx(string idx)
        {
            Idx = new[] { idx };
            return this;
        }

        public SMSSend SetIDx(string[] idx)
        {
            Idx = idx;
            return this;
        }

        public SMSSend SetNormalize(bool flag = true)
        {
            Normalize = flag;
            return this;
        }

        public SMSSend SetNoUnicode(bool noUnicode = true)
        {
            NoUnicode = noUnicode;
            return this;
        }

        public SMSSend SetParam(int i, string[] text)
        {
            return SetParam(i, string.Join("|", text));
        }

        public SMSSend SetParam(int i, string text)
        {
            if (i > 3 || i < 0)
            {
                throw new IndexOutOfRangeException();
            }

            if (Params == null)
            {
                Params = new string[4];
            }

            Params[i] = text;

            return this;
        }

        public SMSSend SetPartner(string partner)
        {
            Partner = partner;
            return this;
        }

        public SMSSend SetSender(string sender)
        {
            Sender = sender;
            return this;
        }

        public SMSSend SetSingle(bool single = true)
        {
            Single = single;
            return this;
        }

        public SMSSend SetTest(bool test = true)
        {
            Test = test;
            return this;
        }

        public SMSSend SetText(string text)
        {
            Text = text;
            return this;
        }

        public SMSSend SetTo(string to)
        {
            To = new[] { to };
            return this;
        }

        public SMSSend SetTo(string[] to)
        {
            To = to;
            return this;
        }

        protected override string Uri()
        {
            return "sms.do";
        }

        protected override void Validate()
        {
            if (To != null && Group != null)
            {
                throw new ArgumentException("Cannot use 'to' and 'group' at the same time!");
            }

            if (Text == null)
            {
                throw new ArgumentException("Cannot send message without text!");
            }
        }

        protected override NameValueCollection Values()
        {
            var collection = new NameValueCollection();

            if (Sender != null)
            {
                collection.Add("from", Sender);
            }

            if (To != null)
            {
                collection.Add("to", string.Join(",", To));
            }

            if (Group != null)
            {
                collection.Add("group", Group);
            }

            collection.Add("message", Text);

            collection.Add("single", Single ? "1" : "0");
            collection.Add("nounicode", NoUnicode ? "1" : "0");
            collection.Add("flash", Flash ? "1" : "0");
            collection.Add("fast", Fast ? "1" : "0");

            if (DataCoding != null)
            {
                collection.Add("datacoding", DataCoding);
            }

            if (MaxParts > 0)
            {
                collection.Add("max_parts", MaxParts.ToString());
            }

            if (DateSent != null)
            {
                collection.Add("date", DateSent);
            }

            if (DateExpire != null)
            {
                collection.Add("expiration_date", DateExpire);
            }

            if (Partner != null)
            {
                collection.Add("partner_id", Partner);
            }

            collection.Add("encoding", Encoding);

            if (Normalize)
            {
                collection.Add("normalize", "1");
            }

            if (Test)
            {
                collection.Add("test", "1");
            }

            if (Idx != null && Idx.Length > 0)
            {
                collection.Add("check_idx", IdxCheck ? "1" : "0");
                collection.Add("idx", string.Join("|", Idx));
            }

            if (Details)
            {
                collection.Add("details", "1");
            }

            if (Params != null)
            {
                for (int i = 0; i < Params.Length; i++)
                {
                    if (Params[i] != null)
                    {
                        collection.Add("param" + (i + 1), Params[i]);
                    }
                }
            }

            return collection;
        }
    }
}
