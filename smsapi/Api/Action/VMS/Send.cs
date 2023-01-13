using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;

namespace SMSApi.Api.Action
{
    public class VMSSend : Send
    {
        private Stream File;

        private string From;
        private int Interval;
        private bool SkipGSM;
        private int Try;
        private string TTS;
        private string TTSLector;

        public VMSSend SetCheckIDx(bool check = true)
        {
            IdxCheck = check;
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

        public VMSSend SetFile(Stream file)
        {
            File = file;
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

        public VMSSend SetIDx(string idx)
        {
            Idx = new[] { idx };
            return this;
        }

        public VMSSend SetIDx(string[] idx)
        {
            Idx = idx;
            return this;
        }

        public VMSSend SetPartner(string partner)
        {
            Partner = partner;
            return this;
        }

        public VMSSend SetSkipGSM(bool flag)
        {
            SkipGSM = flag;
            return this;
        }

        public VMSSend SetTest(bool test = true)
        {
            Test = test;
            return this;
        }

        public VMSSend SetTo(string to)
        {
            To = new[] { to };
            return this;
        }

        public VMSSend SetTo(string[] to)
        {
            To = to;
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

        protected override Dictionary<string, Stream> Files()
        {
            Dictionary<string, Stream> files = new Dictionary<string, Stream>();

            if (File != null && File.Length > 0)
            {
                files.Add("file", File);
            }

            return files;
        }

        protected override string Uri()
        {
            return "vms.do";
        }

        protected override void Validate()
        {
            if (To != null && Group != null)
            {
                throw new ArgumentException("Cannot use 'to' and 'group' at the same time!");
            }

            if ((TTS == null || TTS.Length < 1) && (File == null || File.Length == 0))
            {
                throw new ArgumentException("Cannot send message without content!");
            }

            if (TTS != null && File != null)
            {
                throw new ArgumentException("Cannot send TTS and file at the same time");
            }
        }

        protected override NameValueCollection Values()
        {
            var collection = new NameValueCollection();

            if (To != null)
            {
                collection.Add("to", string.Join(",", To));
            }

            if (From != null)
            {
                collection.Add("from", From);
            }

            if (TTS != null)
            {
                collection.Add("tts", TTS);
            }

            if (DateSent != null)
            {
                collection.Add("date", DateSent);
            }

            if (Try > 0)
            {
                collection.Add("try", Try.ToString());
            }

            if (Interval > 0)
            {
                collection.Add("interval", Interval.ToString());
            }

            if (Partner != null)
            {
                collection.Add("partner_id", Partner);
            }

            if (SkipGSM)
            {
                collection.Add("skip_gsm", "1");
            }

            if (TTSLector != null)
            {
                collection.Add("tts_lector", TTSLector);
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
