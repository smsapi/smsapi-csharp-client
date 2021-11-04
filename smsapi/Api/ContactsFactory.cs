using SMSApi.Api.Action;

namespace SMSApi.Api
{
    public class ContactsFactory : Factory
    {
        public ContactsFactory(ProxyAddress address = ProxyAddress.SmsApiPl)
            : base(address)
        { }

        public ContactsFactory(IClient client, ProxyAddress address = ProxyAddress.SmsApiPl)
            : base(client, address)
        { }

        public ContactsFactory(IClient client, Proxy proxy)
            : base(client, proxy)
        { }

        public BindContactToGroup BindContactToGroup(string contactId, string groupId)
        {
            var action = new BindContactToGroup(contactId, groupId);
            action.Client(client);
            action.Proxy(proxy);
            return action;
        }

        public CreateContact CreateContact()
        {
            var action = new CreateContact();
            action.Client(client);
            action.Proxy(proxy);
            return action;
        }

        public CreateField CreateField()
        {
            var action = new CreateField();
            action.Client(client);
            action.Proxy(proxy);
            return action;
        }

        public CreateGroup CreateGroup()
        {
            var action = new CreateGroup();
            action.Client(client);
            action.Proxy(proxy);
            return action;
        }

        public CreateGroupPermission CreateGroupPermission(string groupId)
        {
            var action = new CreateGroupPermission(groupId);
            action.Client(client);
            action.Proxy(proxy);
            return action;
        }

        public DeleteContact DeleteContact(string contactId)
        {
            var action = new DeleteContact(contactId);
            action.Client(client);
            action.Proxy(proxy);
            return action;
        }

        public DeleteField DeleteField(string fieldId)
        {
            var action = new DeleteField(fieldId);
            action.Client(client);
            action.Proxy(proxy);
            return action;
        }

        public DeleteGroup DeleteGroup(string groupId)
        {
            var action = new DeleteGroup(groupId);
            action.Client(client);
            action.Proxy(proxy);
            return action;
        }

        public DeleteGroupPermission DeleteGroupPermission(string groupId, string username)
        {
            var action = new DeleteGroupPermission(groupId, username);
            action.Client(client);
            action.Proxy(proxy);
            return action;
        }

        public EditContact EditContact(string contactId)
        {
            var action = new EditContact(contactId);
            action.Client(client);
            action.Proxy(proxy);
            return action;
        }

        public EditField EditField(string fieldId)
        {
            var action = new EditField(fieldId);
            action.Client(client);
            action.Proxy(proxy);
            return action;
        }

        public EditGroup EditGroup(string groupId)
        {
            var action = new EditGroup(groupId);
            action.Client(client);
            action.Proxy(proxy);
            return action;
        }

        public EditGroupPermission EditGroupPermission(string groupId, string username)
        {
            var action = new EditGroupPermission(groupId, username);
            action.Client(client);
            action.Proxy(proxy);
            return action;
        }

        public GetContact GetContact(string contactId)
        {
            var action = new GetContact(contactId);
            action.Client(client);
            action.Proxy(proxy);
            return action;
        }

        public GetContactGroup GetContactGroup(string contactId, string groupId)
        {
            var action = new GetContactGroup(contactId, groupId);
            action.Client(client);
            action.Proxy(proxy);
            return action;
        }

        public GetGroup GetGroup(string groupId)
        {
            var action = new GetGroup(groupId);
            action.Client(client);
            action.Proxy(proxy);
            return action;
        }

        public GetGroupPermission GetGroupPermission(string groupId, string username)
        {
            var action = new GetGroupPermission(groupId, username);
            action.Client(client);
            action.Proxy(proxy);
            return action;
        }

        public ListContactGroups ListContactGroups(string contactId)
        {
            var action = new ListContactGroups(contactId);
            action.Client(client);
            action.Proxy(proxy);
            return action;
        }

        public ListContacts ListContacts()
        {
            var action = new ListContacts();
            action.Client(client);
            action.Proxy(proxy);
            return action;
        }

        public ListFieldOptions ListFieldOptions(string fieldId)
        {
            var action = new ListFieldOptions(fieldId);
            action.Client(client);
            action.Proxy(proxy);
            return action;
        }

        public ListFields ListFields()
        {
            var action = new ListFields();
            action.Client(client);
            action.Proxy(proxy);
            return action;
        }

        public ListGroupPermissions ListGroupPermissions(string groupId)
        {
            var action = new ListGroupPermissions(groupId);
            action.Client(client);
            action.Proxy(proxy);
            return action;
        }

        public ListGroups ListGroups()
        {
            var action = new ListGroups();
            action.Client(client);
            action.Proxy(proxy);
            return action;
        }

        public UnbindContactFromGroup UnbindContactFromGroup(string contactId, string groupId)
        {
            var action = new UnbindContactFromGroup(contactId, groupId);
            action.Client(client);
            action.Proxy(proxy);
            return action;
        }
    }
}
