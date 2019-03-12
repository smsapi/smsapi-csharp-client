using System;

namespace SMSApi.Api
{
	public class ContactsFactory : Factory
	{
		public ContactsFactory(Client client) : base(client)
		{
			ProxyHTTP proxyHttp = new ProxyHTTP("http://api.smsapi.pl/");
			proxyHttp.BasicAuthentication(client);
			Proxy(proxyHttp);
		}

        public ContactsFactory(Client client, IProxy proxy) : base(client, proxy)
        {
            proxy.BasicAuthentication(client);
            Proxy(proxy);
        }

        public Action.ListContacts ListContacts()
		{
			Action.ListContacts action = new Action.ListContacts();
			action.Client(client);
			action.Proxy(proxy);
			return action;
		}

		public Action.CreateContact CreateContact()
		{
			Action.CreateContact action = new Action.CreateContact();
			action.Client(client);
			action.Proxy(proxy);
			return action;
		}

		public Action.DeleteContact DeleteContact(string contactId)
		{
			Action.DeleteContact action = new Action.DeleteContact(contactId);
			action.Client(client);
			action.Proxy(proxy);
			return action;
		}

		public Action.GetContact GetContact(string contactId)
		{
			Action.GetContact action = new Action.GetContact(contactId);
			action.Client(client);
			action.Proxy(proxy);
			return action;
		}

		public Action.EditContact EditContact(string contactId)
		{
			Action.EditContact action = new Action.EditContact(contactId);
			action.Client(client);
			action.Proxy(proxy);
			return action;
		}

		public Action.ListGroups ListGroups()
		{
			Action.ListGroups action = new Action.ListGroups();
			action.Client(client);
			action.Proxy(proxy);
			return action;
		}

		public Action.CreateGroup CreateGroup()
		{
			Action.CreateGroup action = new Action.CreateGroup();
			action.Client(client);
			action.Proxy(proxy);
			return action;
		}

		public Action.DeleteGroup DeleteGroup(string groupId)
		{
			Action.DeleteGroup action = new Action.DeleteGroup(groupId);
			action.Client(client);
			action.Proxy(proxy);
			return action;
		}

		public Action.GetGroup GetGroup(string groupId)
		{
			Action.GetGroup action = new Action.GetGroup(groupId);
			action.Client(client);
			action.Proxy(proxy);
			return action;
		}

		public Action.EditGroup EditGroup(string groupId)
		{
			Action.EditGroup action = new Action.EditGroup(groupId);
			action.Client(client);
			action.Proxy(proxy);
			return action;
		}
	
		public Action.ListGroupPermissions ListGroupPermissions(string groupId)
		{
			Action.ListGroupPermissions action = new Action.ListGroupPermissions(groupId);
			action.Client(client);
			action.Proxy(proxy);
			return action;
		}

		public Action.ListFields ListFields()
		{
			Action.ListFields action = new Action.ListFields();
			action.Client(client);
			action.Proxy(proxy);
			return action;
		}

		public Action.CreateField CreateField()
		{
			Action.CreateField action = new Action.CreateField();
			action.Client(client);
			action.Proxy(proxy);
			return action;
		}

		public Action.DeleteField DeleteField(string fieldId)
		{
			Action.DeleteField action = new Action.DeleteField(fieldId);
			action.Client(client);
			action.Proxy(proxy);
			return action;
		}

		public Action.EditField EditField(string fieldId)
		{
			Action.EditField action = new Action.EditField(fieldId);
			action.Client(client);
			action.Proxy(proxy);
			return action;
		}

		public Action.ListFieldOptions ListFieldOptions(string fieldId)
		{
			Action.ListFieldOptions action = new Action.ListFieldOptions(fieldId);
			action.Client(client);
			action.Proxy(proxy);
			return action;
		}

		public Action.BindContactToGroup BindContactToGroup(string contactId, string groupId)
		{
			Action.BindContactToGroup action = new Action.BindContactToGroup(contactId, groupId);
			action.Client(client);
			action.Proxy(proxy);
			return action;
		}

		public Action.UnbindContactFromGroup UnbindContactFromGroup(string contactId, string groupId)
		{
			Action.UnbindContactFromGroup action = new Action.UnbindContactFromGroup(contactId, groupId);
			action.Client(client);
			action.Proxy(proxy);
			return action;
		}

		public Action.ListContactGroups ListContactGroups(string contactId)
		{
			Action.ListContactGroups action = new Action.ListContactGroups(contactId);
			action.Client(client);
			action.Proxy(proxy);
			return action;
		}

		public Action.GetContactGroup GetContactGroup(string contactId, string groupId)
		{
			Action.GetContactGroup action = new Action.GetContactGroup(contactId, groupId);
			action.Client(client);
			action.Proxy(proxy);
			return action;
		}

		public Action.CreateGroupPermission CreateGroupPermission(string groupId)
		{
			Action.CreateGroupPermission action = new Action.CreateGroupPermission(groupId);
			action.Client(client);
			action.Proxy(proxy);
			return action;
		}

		public Action.DeleteGroupPermission DeleteGroupPermission(string groupId, string username)
		{
			Action.DeleteGroupPermission action = new Action.DeleteGroupPermission(groupId, username);
			action.Client(client);
			action.Proxy(proxy);
			return action;
		}

		public Action.GetGroupPermission GetGroupPermission(string groupId, string username)
		{
			Action.GetGroupPermission action = new Action.GetGroupPermission(groupId, username);
			action.Client(client);
			action.Proxy(proxy);
			return action;
		}

		public Action.EditGroupPermission EditGroupPermission(string groupId, string username)
		{
			Action.EditGroupPermission action = new Action.EditGroupPermission(groupId, username);
			action.Client(client);
			action.Proxy(proxy);
			return action;
		}
	}
}

