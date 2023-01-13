using System;
using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
    public class MMSSend : Send
    {
        private string Smil;

        private string Subject;

        public MMSSend SetCheckIDx(bool check = true)
        {
            IdxCheck = check;
            return this;
        }

        public MMSSend SetDateSent(string data)
        {
            DateSent = data;
            return this;
        }

        public MMSSend SetDateSent(DateTime data)
        {
            DateSent = data.ToString("yyyy-MM-ddTHH:mm:ssK");
            return this;
        }

        public MMSSend SetGroup(string group)
        {
            Group = group;
            return this;
        }

        public MMSSend SetIDx(string idx)
        {
            Idx = new[] { idx };
            return this;
        }

        public MMSSend SetIDx(string[] idx)
        {
            Idx = idx;
            return this;
        }

        public MMSSend SetPartner(string partner)
        {
            Partner = partner;
            return this;
        }

        public MMSSend SetSmil(string smil)
        {
            Smil = smil;
            return this;
        }

        public MMSSend SetSubject(string subject)
        {
            Subject = subject;
            return this;
        }

        public MMSSend SetTest(bool test = true)
        {
            Test = test;
            return this;
        }

        public MMSSend SetTo(string to)
        {
            To = new[] { to };
            return this;
        }

        public MMSSend SetTo(string[] to)
        {
            To = to;
            return this;
        }

        protected override string Uri()
        {
            return "mms.do";
        }

        protected override void Validate()
        {
            if (To != null && Group != null)
            {
                throw new ArgumentException("Cannot use 'to' and 'group' at the same time!");
            }

            if (Smil == null || Smil.Length < 1)
            {
                throw new ArgumentException("Cannot send message without smil!");
            }
        }

        protected override NameValueCollection Values()
        {
            var collection = new NameValueCollection();

            if (To != null)
            {
                collection.Add("to", string.Join(",", To));
            }

            if (Group != null)
            {
                collection.Add("group", Group);
            }

            if (Subject != null)
            {
                collection.Add("subject", Subject);
            }

            collection.Add("smil", Smil);

            if (DateSent != null)
            {
                collection.Add("date", DateSent);
            }

            if (Partner != null)
            {
                collection.Add("partner_id", Partner);
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

            return collection;
        }
    }
}
