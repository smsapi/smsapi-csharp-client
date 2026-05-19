using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SMSApi.Api.Response
{
    [DataContract]
    public class Group : Base
    {
        [DataMember(Name = "created_by", IsRequired = false)]
        public readonly string CreatedBy;

        [DataMember(Name = "id", IsRequired = false)]
        public readonly string Id;

        [DataMember(Name = "idx", IsRequired = false)]
        public readonly string Idx;

        [DataMember(Name = "name", IsRequired = true)]
        public readonly string Name;

        [DataMember(Name = "permissions", IsRequired = false)]
        private List<GroupPermission> permissions;

        private Group()
        { }

        public int ContactsCount { get; private set; }

        [DataMember(Name = "contacts_count", IsRequired = false)]
        private int? ContactsCountSerializationHelper
        {
            get => ContactsCount;
            set => ContactsCount = value ?? 0;
        }

        public DateTime? DateCreated { get; private set; }

        public DateTime? DateUpdated { get; private set; }

        [DataMember(Name = "description", IsRequired = false)]
        public string Description { get; private set; }

        [Obsolete("use Description instead")]
        [DataMember(Name = "info", IsRequired = false)]
        public string Info
        {
            get => Description;
            private set => Description = value;
        }

        [Obsolete("use ContactsCount instead")]
        public uint NumbersCount
        {
            get => (uint)ContactsCount;
            private set => ContactsCount = (int)value;
        }

        [DataMember(Name = "numbers_count", IsRequired = false)]
        private int? NumbersCountSerializationHelper
        {
            get => ContactsCount;
            set => ContactsCount = value ?? ContactsCount;
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

        [DataMember(Name = "date_created", IsRequired = false)]
        private string DateCreatedSerializationHelper
        {
            set => DateCreated = DateTime.Parse(value);
            get => "";
        }

        [DataMember(Name = "date_updated", IsRequired = false)]
        private string DateUpdatedSerializationHelper
        {
            set => DateUpdated = DateTime.Parse(value);
            get => "";
        }
    }
}
