using System.Collections.Generic;

namespace SMSApi.Api.Response
{
    public class CheckNumber : Countable
    {
        private List<NumberStatus> list;

        protected CheckNumber()
        { }

        public List<NumberStatus> List
        {
            get
            {
                if (list == null)
                {
                    list = new List<NumberStatus>();
                }

                return list;
            }

            set
            { }
        }
    }
}
