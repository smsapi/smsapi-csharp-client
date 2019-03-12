using System;
using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
    public class SMSSend : Send
    {
        protected override string Uri() { return "sms.do"; }

        protected override NameValueCollection Values()
        {
            var collection = new NameValueCollection
            {
                {"format", "json"},
                {"username", client.GetUsername()},
                {"password", client.GetPassword()}
            };



            if (_sender != null) 
                collection.Add("from", _sender);

            if (To != null)
                collection.Add("to", string.Join(",", To));

            if (Group != null)
                collection.Add("group", Group);

            collection.Add("message", _text);

            collection.Add("single", (_single ? "1" : "0") );
            collection.Add("nounicode", (_noUnicode ? "1" : "0") );
            collection.Add("flash", (_flash ? "1" : "0") );
            collection.Add("fast", (_fast ? "1" : "0") );

            if (_dataCoding != null)
                collection.Add("datacoding", _dataCoding);

            if (MaxParts > 0)
                collection.Add("max_parts", MaxParts.ToString());

            if (DateSent != null)
                collection.Add("date", DateSent);

            if (_dateExpire != null)
                collection.Add("expiration_date", _dateExpire);

            if (Partner != null)
                collection.Add("partner_id", Partner);

            collection.Add("encoding", _encoding);

			if (_normalize)
				collection.Add("normalize", "1");

            if (Test)
                collection.Add("test", "1");

            if (Idx != null && Idx.Length > 0)
            {
                collection.Add("check_idx", (IdxCheck ? "1" : "0"));
                collection.Add("idx", string.Join("|", Idx));
            }

            if (_details)
            {
                collection.Add("details", "1");
            }

            if (_params != null)
            {
                for (var i = 0; i < _params.Length; i++)
                {
                    if (_params[i] != null)
                    {
                        collection.Add("param" + (i + 1), _params[i]);
                    }
                }
            }

            return collection;
        }

        protected override void Validate()
        {
            if( To != null && Group != null )
            {
                throw new ArgumentException("Cannot use 'to' and 'group' at the same time!");
            }

            if (_text == null)
            {
                throw new ArgumentException("Cannot send message without text!");
            }
        }

        private string _text;
        private string _dateExpire;
        private string _sender;
        private bool _single;
        private bool _noUnicode;
        private string _dataCoding;
        private string _udh;
        private bool _flash;
        private readonly string _encoding = "UTF-8";
        private bool _fast;
		private bool _normalize;
        private readonly int MaxParts = 0;
        private string[] _params;
        private bool _details = true;

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

        public SMSSend SetGroup(string group)
        {
            Group = group;
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

        public SMSSend SetCheckIDx(bool check = true)
        {
            IdxCheck = check;
            return this;
        }

        public SMSSend SetPartner(string partner)
        {
            Partner = partner;
            return this;
        }

        public SMSSend SetText(string text)
        {
            _text = text;
            return this;
        }

        public SMSSend SetDateExpire(string data)
        {
            _dateExpire = data;
            return this;
        }

        public SMSSend SetDateExpire(DateTime data)
        {
            _dateExpire = data.ToString("yyyy-MM-ddTHH:mm:ssK");
            return this;
        }

        public SMSSend SetSender(string sender)
        {
            _sender = sender;
            return this;
        }

        public SMSSend SetSingle(bool single = true)
        {
            _single = single;
            return this;
        }

        public SMSSend SetNoUnicode(bool noUnicode = true)
        {
            _noUnicode = noUnicode;
            return this;
        }

        public SMSSend SetDataCoding(string dataCoding)
        {
            _dataCoding = dataCoding;
            return this;
        }

        public SMSSend SetUdh(string udh)
        {
            _udh = udh;
            return this;
        }

        public SMSSend SetFlash(bool flash = true)
        {
            _flash = flash;
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
            _fast = fast;
            return this;
        }

        public SMSSend SetTest(bool test = true)
        {
            Test = test;
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

            if (_params == null)
            {
                _params = new string[4];
            }

            _params[i] = text;

            return this;
        }

		public SMSSend SetNormalize(bool flag = true)
		{
			_normalize = flag;
			return this;
		}
    }
}
