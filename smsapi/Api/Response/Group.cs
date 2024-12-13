using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using SMSApi.Api.Response.ResponseResolver;
using Newtonsoft.Json;

namespace SMSApi.Api.Response
{
    public class Group : ErrorAwareResponse
    {
        public readonly string CreatedBy;

        public readonly string Id;

        public readonly string Idx;

        [JsonRequired]
        public readonly string Name;

        private List<GroupPermission> permissions;

        [JsonProperty("contacts_count")]
        public int? ContactsCount { get; private set; }

        public DateTime? DateCreated { get; private set; }

        public DateTime? DateUpdated { get; private set; }

        [JsonProperty("description")]
        public string Description { get; private set; }

        [Obsolete("use Description instead")]
        [JsonProperty("info")]
        public string Info
        {
            get => Description;
            private set => Description = value;
        }

        [Obsolete("use ContactsCount instead")]
        [JsonProperty("numbers_count")]
        public uint NumbersCount
        {
            get => (uint)ContactsCount;
            private set => ContactsCount = (int)value;
        }

        public List<GroupPermission> Permissions
        {
            get
            {
                if (permissions == null)
                {
                    permissions = new List<GroupPermission>();
                }

                return permissions;
            }
        }

        [JsonProperty("date_created")]
        private string DateCreatedSerializationHelper
        {
            set => DateCreated = DateTime.Parse(value);
            get => "";
        }

        [JsonProperty("date_updated")]
        private string DateUpdatedSerializationHelper
        {
            set => DateUpdated = DateTime.Parse(value);
            get => "";
        }
    }
}
