using System;

namespace SMSApi.Api
{
	public class ContactsFactory : Factory
	{
		public ContactsFactory(ProxyAddress address = ProxyAddress.SmsApiPl)
			: base(address)
		{
		}

		public ContactsFactory(IClient client, ProxyAddress address = ProxyAddress.SmsApiPl) 
			: base(client, address)
		{
		}

        public ContactsFactory(IClient client, Proxy proxy) : base(client, proxy)
        {
        }

        public SMSApi.Api.Action.ListContacts ListContacts()
		{
			SMSApi.Api.Action.ListContacts action = new SMSApi.Api.Action.ListContacts();
			action.Client(client);
			action.Proxy(proxy);
			return action;
		}

		public SMSApi.Api.Action.CreateContact CreateContact()
		{
			SMSApi.Api.Action.CreateContact action = new SMSApi.Api.Action.CreateContact();
			action.Client(client);
			action.Proxy(proxy);
			return action;
		}

		public SMSApi.Api.Action.DeleteContact DeleteContact(string contactId)
		{
			SMSApi.Api.Action.DeleteContact action = new SMSApi.Api.Action.DeleteContact(contactId);
			action.Client(client);
			action.Proxy(proxy);
			return action;
		}

		public SMSApi.Api.Action.GetContact GetContact(string contactId)
		{
			SMSApi.Api.Action.GetContact action = new SMSApi.Api.Action.GetContact(contactId);
			action.Client(client);
			action.Proxy(proxy);
			return action;
		}

		public SMSApi.Api.Action.EditContact EditContact(string contactId)
		{
			SMSApi.Api.Action.EditContact action = new SMSApi.Api.Action.EditContact(contactId);
			action.Client(client);
			action.Proxy(proxy);
			return action;
		}

		public SMSApi.Api.Action.ListGroups ListGroups()
		{
			SMSApi.Api.Action.ListGroups action = new SMSApi.Api.Action.ListGroups();
			action.Client(client);
			action.Proxy(proxy);
			return action;
		}

		public SMSApi.Api.Action.CreateGroup CreateGroup()
		{
			SMSApi.Api.Action.CreateGroup action = new SMSApi.Api.Action.CreateGroup();
			action.Client(client);
			action.Proxy(proxy);
			return action;
		}

		public SMSApi.Api.Action.DeleteGroup DeleteGroup(string groupId)
		{
			SMSApi.Api.Action.DeleteGroup action = new SMSApi.Api.Action.DeleteGroup(groupId);
			action.Client(client);
			action.Proxy(proxy);
			return action;
		}

		public SMSApi.Api.Action.GetGroup GetGroup(string groupId)
		{
			SMSApi.Api.Action.GetGroup action = new SMSApi.Api.Action.GetGroup(groupId);
			action.Client(client);
			action.Proxy(proxy);
			return action;
		}

		public SMSApi.Api.Action.EditGroup EditGroup(string groupId)
		{
			SMSApi.Api.Action.EditGroup action = new SMSApi.Api.Action.EditGroup(groupId);
			action.Client(client);
			action.Proxy(proxy);
			return action;
		}
	
		public SMSApi.Api.Action.ListGroupPermissions ListGroupPermissions(string groupId)
		{
			SMSApi.Api.Action.ListGroupPermissions action = new SMSApi.Api.Action.ListGroupPermissions(groupId);
			action.Client(client);
			action.Proxy(proxy);
			return action;
		}

		public SMSApi.Api.Action.ListFields ListFields()
		{
			SMSApi.Api.Action.ListFields action = new SMSApi.Api.Action.ListFields();
			action.Client(client);
			action.Proxy(proxy);
			return action;
		}

		public SMSApi.Api.Action.CreateField CreateField()
		{
			SMSApi.Api.Action.CreateField action = new SMSApi.Api.Action.CreateField();
			action.Client(client);
			action.Proxy(proxy);
			return action;
		}

		public SMSApi.Api.Action.DeleteField DeleteField(string fieldId)
		{
			SMSApi.Api.Action.DeleteField action = new SMSApi.Api.Action.DeleteField(fieldId);
			action.Client(client);
			action.Proxy(proxy);
			return action;
		}

		public SMSApi.Api.Action.EditField EditField(string fieldId)
		{
			SMSApi.Api.Action.EditField action = new SMSApi.Api.Action.EditField(fieldId);
			action.Client(client);
			action.Proxy(proxy);
			return action;
		}

		public SMSApi.Api.Action.ListFieldOptions ListFieldOptions(string fieldId)
		{
			SMSApi.Api.Action.ListFieldOptions action = new SMSApi.Api.Action.ListFieldOptions(fieldId);
			action.Client(client);
			action.Proxy(proxy);
			return action;
		}

		public SMSApi.Api.Action.BindContactToGroup BindContactToGroup(string contactId, string groupId)
		{
			SMSApi.Api.Action.BindContactToGroup action = new SMSApi.Api.Action.BindContactToGroup(contactId, groupId);
			action.Client(client);
			action.Proxy(proxy);
			return action;
		}

		public SMSApi.Api.Action.UnbindContactFromGroup UnbindContactFromGroup(string contactId, string groupId)
		{
			SMSApi.Api.Action.UnbindContactFromGroup action = new SMSApi.Api.Action.UnbindContactFromGroup(contactId, groupId);
			action.Client(client);
			action.Proxy(proxy);
			return action;
		}

		public SMSApi.Api.Action.ListContactGroups ListContactGroups(string contactId)
		{
			SMSApi.Api.Action.ListContactGroups action = new SMSApi.Api.Action.ListContactGroups(contactId);
			action.Client(client);
			action.Proxy(proxy);
			return action;
		}

		public SMSApi.Api.Action.GetContactGroup GetContactGroup(string contactId, string groupId)
		{
			SMSApi.Api.Action.GetContactGroup action = new SMSApi.Api.Action.GetContactGroup(contactId, groupId);
			action.Client(client);
			action.Proxy(proxy);
			return action;
		}

		public SMSApi.Api.Action.CreateGroupPermission CreateGroupPermission(string groupId)
		{
			SMSApi.Api.Action.CreateGroupPermission action = new SMSApi.Api.Action.CreateGroupPermission(groupId);
			action.Client(client);
			action.Proxy(proxy);
			return action;
		}

		public SMSApi.Api.Action.DeleteGroupPermission DeleteGroupPermission(string groupId, string username)
		{
			SMSApi.Api.Action.DeleteGroupPermission action = new SMSApi.Api.Action.DeleteGroupPermission(groupId, username);
			action.Client(client);
			action.Proxy(proxy);
			return action;
		}

		public SMSApi.Api.Action.GetGroupPermission GetGroupPermission(string groupId, string username)
		{
			SMSApi.Api.Action.GetGroupPermission action = new SMSApi.Api.Action.GetGroupPermission(groupId, username);
			action.Client(client);
			action.Proxy(proxy);
			return action;
		}

		public SMSApi.Api.Action.EditGroupPermission EditGroupPermission(string groupId, string username)
		{
			SMSApi.Api.Action.EditGroupPermission action = new SMSApi.Api.Action.EditGroupPermission(groupId, username);
			action.Client(client);
			action.Proxy(proxy);
			return action;
		}
	}
}

