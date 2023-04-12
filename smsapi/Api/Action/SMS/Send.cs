using System;
using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
    public class SMSSend : Send
    {
        private const string Encoding = "UTF-8";
        
        private string dataCoding;
        private string dateExpire;
        private bool fast;
        private bool flash;
        private int maxParts;
        private bool normalize;
        private bool noUnicode;
        private string[] @params;
        private string sender;
        private bool single;
        private string text;
        private string? template;

        protected override RequestMethod Method => RequestMethod.POST;

        public SMSSend SetCheckIDx(bool check = true)
        {
            IdxCheck = check;
            return this;
        }

        public SMSSend SetDataCoding(string dataCoding)
        {
            this.dataCoding = dataCoding;
            return this;
        }

        public SMSSend SetDateExpire(string data)
        {
            dateExpire = data;
            return this;
        }

        public SMSSend SetDateExpire(DateTime data)
        {
            dateExpire = data.ToString("yyyy-MM-ddTHH:mm:ssK");
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
            this.fast = fast;
            return this;
        }

        public SMSSend SetFlash(bool flash = true)
        {
            this.flash = flash;
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
            normalize = flag;
            return this;
        }

        public SMSSend SetNoUnicode(bool noUnicode = true)
        {
            this.noUnicode = noUnicode;
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

            if (@params == null)
            {
                @params = new string[4];
            }

            @params[i] = text;

            return this;
        }

        public SMSSend SetPartner(string partner)
        {
            Partner = partner;
            return this;
        }

        public SMSSend SetSender(string sender)
        {
            this.sender = sender;
            return this;
        }

        public SMSSend SetSingle(bool single = true)
        {
            this.single = single;
            return this;
        }

        public SMSSend SetTest(bool test = true)
        {
            Test = test;
            return this;
        }

        public SMSSend SetText(string text)
        {
            this.text = text;
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
        
        public SMSSend SetTemplate(string templateName)
        {
            template = templateName;
            
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

            if (text == null)
            {
                throw new ArgumentException("Cannot send message without text!");
            }
        }

        protected override NameValueCollection Values()
        {
            var collection = new NameValueCollection();

            if (sender != null)
            {
                collection.Add("from", sender);
            }

            if (To != null)
            {
                collection.Add("to", string.Join(",", To));
            }

            if (Group != null)
            {
                collection.Add("group", Group);
            }

            collection.Add("message", text);

            collection.Add("single", single ? "1" : "0");
            collection.Add("nounicode", noUnicode ? "1" : "0");
            collection.Add("flash", flash ? "1" : "0");
            collection.Add("fast", fast ? "1" : "0");
            collection.Add("details", "1");

            if (dataCoding != null)
            {
                collection.Add("datacoding", dataCoding);
            }

            if (maxParts > 0)
            {
                collection.Add("max_parts", maxParts.ToString());
            }

            if (DateSent != null)
            {
                collection.Add("date", DateSent);
            }

            if (dateExpire != null)
            {
                collection.Add("expiration_date", dateExpire);
            }

            if (Partner != null)
            {
                collection.Add("partner_id", Partner);
            }

            collection.Add("encoding", Encoding);

            if (normalize)
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

            if (@params != null)
            {
                for (int i = 0; i < @params.Length; i++)
                {
                    if (@params[i] != null)
                    {
                        collection.Add("param" + (i + 1), @params[i]);
                    }
                }
            }

            if (template != null)
            {
                collection.Add("template", template);
            }

            return collection;
        }
    }
}
