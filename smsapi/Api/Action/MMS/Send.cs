using System;
using System.Collections.Specialized;

namespace SMSApi.Api.Action
{
    public class MMSSend : Send
    {
        public MMSSend() : base() { }

        protected override string Uri() { return "mms.do"; }

        protected override NameValueCollection Values()
        {
            NameValueCollection collection = new NameValueCollection();

            collection.Add("format", "json");

            collection.Add("username", client.GetUsername());
            collection.Add("password", client.GetPassword());

            if (To != null)
                collection.Add("to", string.Join(",", To));

            if (Group != null)
                collection.Add("group", Group);

            if (Subject != null)
                collection.Add("subject", Subject);

            collection.Add("smil", Smil);

            if (DateSent != null)
                collection.Add("date", DateSent);

            if (Partner != null)
                collection.Add("partner_id", Partner);

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

            if (Smil == null || Smil.Length < 1)
            {
                throw new ArgumentException("Cannot send message without smil!");
            }
        }

        private string Subject;
        private string Smil;

        public MMSSend SetTo(string to)
        {
            this.To = new string[] { to };
            return this;
        }

        public MMSSend SetTo(string[] to)
        {
            this.To = to;
            return this;
        }

        public MMSSend SetGroup(string group)
        {
            this.Group = group;
            return this;
        }

        public MMSSend SetDateSent(string data)
        {
            this.DateSent = data;
            return this;
        }

        public MMSSend SetDateSent(DateTime data)
        {
            this.DateSent = data.ToString("yyyy-MM-ddTHH:mm:ssK");
            return this;
        }

        public MMSSend SetIDx(string idx)
        {
            this.Idx = new string[] { idx };
            return this;
        }

        public MMSSend SetIDx(string[] idx)
        {
            this.Idx = idx;
            return this;
        }

        public MMSSend SetCheckIDx(bool check = true)
        {
            this.IdxCheck = check;
            return this;
        }

        public MMSSend SetSubject(string subject)
        {
            this.Subject = subject;
            return this;
        }

        public MMSSend SetSmil(string smil)
        {
            this.Smil = smil;
            return this;
        }

        public MMSSend SetPartner(string partner)
        {
            this.Partner = partner;
            return this;
        }

        public MMSSend SetTest(bool test = true)
        {
            this.Test = test;
            return this;
        }
    }
}
