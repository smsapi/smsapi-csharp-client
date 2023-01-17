﻿using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SMSApi.Api.Response
{
    [DataContract]
    public class Senders : Countable
    {
        [DataMember(Name = "list", IsRequired = false)]
        private List<Sender> list;

        private Senders()
        { }

        public List<Sender> List
        {
            get
            {
                if (list == null)
                {
                    list = new List<Sender>();
                }

                return list;
            }

            set
            { }
        }
    }
}
