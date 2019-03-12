using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;

namespace SMSApi.Api.Action
{
    public class VMSSend : Send
    {
        public VMSSend()
        { }

        protected override string Uri() { return "vms.do"; }

        protected override Dictionary<string, Stream> Files()
        {
            Dictionary<string, Stream> files = null;

            if (File != null && File.Length > 0)
            {
                files = new Dictionary<string, Stream>();
                files.Add("file", File);
            }

            return files;
        }

        protected override NameValueCollection Values()
        {
            NameValueCollection collection = new NameValueCollection();

            collection.Add("format", "json");

            collection.Add("username", client.GetUsername());
            collection.Add("password", client.GetPassword());

            if (To != null)
                collection.Add("to", string.Join(",", To));

            if (From != null)
                collection.Add("from", From);
            
//            if (Group != null)
//                collection.Add("group", Group);

            if (TTS != null)
                collection.Add("tts", TTS);

            if (DateSent != null)
                collection.Add("date", DateSent);

            if (Try > 0)
                collection.Add("try", Try.ToString());

            if (Interval > 0)
                collection.Add("interval", Interval.ToString());

            if (Partner != null)
                collection.Add("partner_id", Partner);

            if (SkipGSM == true)
                collection.Add("skip_gsm", "1");

            if (TTSLector != null)
                collection.Add("tts_lector", TTSLector);

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

            if ( (TTS == null || TTS.Length < 1) && (File == null || File.Length == 0) )
            {
                throw new ArgumentException("Cannot send message without content!");
            }

            if (TTS != null  && File != null)
            {
                throw new ArgumentException("Cannot send TTS and file at the same time");
            }
        }

        private string From;
        private Stream File;
        private string TTS;
        private string TTSLector;
        private int Try = 0;
        private int Interval = 0;
        private bool SkipGSM = false;

        public VMSSend SetTo(string to)
        {
            To = new string[] { to };
            return this;
        }

        public VMSSend SetTo(string[] to)
        {
            To = to;
            return this;
        }

        public VMSSend SetFrom(string from)
        {
            From = from;
            return this;
        }

        public VMSSend SetGroup(string group)
        {
            Group = group;
            return this;
        }

        public VMSSend SetDateSent(string data)
        {
            DateSent = data;
            return this;
        }

        public VMSSend SetDateSent(DateTime data)
        {
            DateSent = data.ToString("yyyy-MM-ddTHH:mm:ssK");
            return this;
        }

        public VMSSend SetIDx(string idx)
        {
            Idx = new string[] { idx };
            return this;
        }

        public VMSSend SetIDx(string[] idx)
        {
            Idx = idx;
            return this;
        }

        public VMSSend SetCheckIDx(bool check = true)
        {
            IdxCheck = check;
            return this;
        }

        public VMSSend SetFile(Stream file)
        {
            File = file;
            return this;
        }

        public VMSSend SetTTS(string tts)
        {
            TTS = tts;
            return this;
        }

        public VMSSend SetTTSLector(string lector)
        {
            TTSLector = lector;
            return this;
        }

        public VMSSend SetPartner(string partner)
        {
            Partner = partner;
            return this;
        }

        public VMSSend SetTest(bool test = true)
        {
            Test = test;
            return this;
        }

        public VMSSend SetTry(int retry)
        {
            Try = retry;
            return this;
        }

        public VMSSend SetTryInterval(int sec)
        {
            Interval = sec;
            return this;
        }

        public VMSSend SetSkipGSM(bool flag)
        {
            SkipGSM = flag;
            return this;
        }

        
    }
}
