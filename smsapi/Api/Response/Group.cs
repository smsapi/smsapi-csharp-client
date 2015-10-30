using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SMSApi.Api.Response
{
	[DataContract]
	public class Group : Base
	{
		private Group() : base() { }

		[DataMember(Name = "id", IsRequired = false)]
		public readonly string Id;

		[DataMember(Name = "name", IsRequired = true)]
		public readonly string Name;

		private int contactsCount;
		[DataMember(Name = "contacts_count", IsRequired = false)]
		public int ContactsCount { get { return contactsCount; } private set { contactsCount = value; } }

		private DateTime? dateCreated;
		[DataMember(Name = "date_created", IsRequired = false)]
		private string DateCreatedSerializationHelper { set { dateCreated = DateTime.Parse(value); } get { return ""; } }
		public DateTime? DateCreated { get { return dateCreated; } }

		private DateTime? dateUpdated;
		[DataMember(Name = "date_updated", IsRequired = false)]
		private string DateUpdatedSerializationHelper { set { dateUpdated = DateTime.Parse(value); } get { return ""; } }
		public DateTime? DateUpdated { get { return dateUpdated; } }

		private string description;
		[DataMember(Name = "description", IsRequired = false)]
		public string Description { get { return description; } private set { description = value; } }

		[DataMember(Name = "created_by", IsRequired = false)]
		public readonly string CreatedBy;

		[DataMember(Name = "idx", IsRequired = false)]
		public readonly string Idx;

		[DataMember(Name = "permissions", IsRequired = false)]
		private System.Collections.Generic.List<GroupPermission> permissions;
		public System.Collections.Generic.List<GroupPermission> Permissions
		{
			get
			{
				if (permissions == null)
					permissions = new System.Collections.Generic.List<GroupPermission>();
				return permissions;
			}
		}

		[Obsolete("use Description instead")]
		[DataMember(Name = "info", IsRequired = false)]
		public string Info { get { return Description; } private set { Description = value; } }

		[Obsolete("use ContactsCount instead")]
		[DataMember(Name = "numbers_count", IsRequired = false)]
		public uint NumbersCount { get { return (uint)ContactsCount; } private set { ContactsCount = (int)value; } }
	}
}
