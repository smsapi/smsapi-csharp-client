using System;
using System.IO;
using SMSApi.Api.Response;
using SMSApi.Api;

namespace SMSApi
{
    class Test
    {
        static void Main(string[] args)
        {
            var o = new Test();

            o.test_sms();
            o.test_smsParams();
            o.test_mms();
            o.test_vms();
            o.test_hlr();
            o.test_sender();
            o.test_phonebookgroup();
            o.test_phonebookcontact();
            o.test_user();
            //To test contacts You need to migrate your database via https://ssl.smsapi.pl/contacts/migrate
            o.test_contacts();
        }

        static public SMSApi.Api.Client client()
        {
            SMSApi.Api.Client client = new SMSApi.Api.Client("login");
            client.SetPasswordRAW("password");

            return client;
        }

        public Test() { }

        public void test_user()
        {
            var userApi = new SMSApi.Api.UserFactory(client());
            try
            {
                var points = userApi.ActionGetCredits().Execute();
                System.Console.WriteLine(points.Points);

                string usernName = "test_" + DateTime.Now.ToString("his");

                var user =
                    userApi.ActionAdd()
                        .SetUsername(usernName)
                        .SetPassword("7815696ecbf1c96e6894b779456d330e")
                        .Execute();

                user =
                    userApi.ActionEdit(usernName)
                        .SetInfo("edited info")
                        .Execute();

                var users = userApi.ActionList().Execute();

                foreach (var u in users.List) {
                    System.Console.WriteLine(u.Username);
                }
            }
            catch (SMSApi.Api.ClientException e)
            {
                System.Console.WriteLine(e.Message);
            }
        }

        public void test_phonebookgroup()
        {
            try
            {
                var phonebookApi = new SMSApi.Api.PhonebookFactory(client());

                string groupName = "new group123" + DateTime.Now.ToString("his");

                phonebookApi.ActionGroupAdd()
                    .SetInfo("ooo info")
                    .SetName(groupName)
                    .Execute();

                var group =
                    phonebookApi.ActionGroupEdit(groupName)
                        .SetName(groupName + "#edit")
                        .SetInfo("edited info")
                        .Execute();

                group =
                    phonebookApi.ActionGroupGet(group.Name)
                        .Execute();

                var groups = phonebookApi.ActionGroupList().Execute();

                foreach (var g in groups.List)
                {
                    System.Console.WriteLine(g.Name + " " + g.NumbersCount + " " + g.Info);
                }

                phonebookApi.ActionGroupDelete(group.Name)
                    .Contacts(false)
                    .Execute();
            }
            catch (SMSApi.Api.ClientException e)
            {
                System.Console.WriteLine(e.Message);
            }
        }

        public void test_phonebookcontact() {

            try
            {
                var phonebookApi = new SMSApi.Api.PhonebookFactory(client());

                var number = "xxxyyyzzz";

                var contact =
                    phonebookApi.ActionContactAdd(number)
                        .SetFirstName("Test contact" + DateTime.Now.ToString("his"))
                        .Execute();

                contact =
                    phonebookApi.ActionContactEdit(contact.Number)
                        .SetFirstName("Test contact" + DateTime.Now.ToString("his") + "#edited")
                        .SetNumber("xxxyyyzzz")
                        .Execute();

                var contacts = phonebookApi.ActionContactList().Execute();
                foreach (var c in contacts.List)
                {
                    System.Console.WriteLine(c.Number + " " + c.FirstName + " " + c.LastName + " " + c.Gender);
                }

                contact = phonebookApi.ActionContactGet(contact.Number).Execute();

                phonebookApi.ActionContactDelete(contact.Number).Execute();
            }
            catch (SMSApi.Api.ClientException e)
            {
                System.Console.WriteLine(e.Message);
            }
        }

        public void test_sender()
        {
            try
            {
                var senderApi = new SMSApi.Api.SenderFactory(client());

                string name = "testName";

                senderApi.ActionAdd(name).Execute();

                senderApi.ActionSetDefault("SMSAPI").Execute();

                var senders = senderApi.ActionList().Execute();
                foreach (var sender in senders.List)
                {
                    System.Console.WriteLine("Name: " + sender.Name + " " + sender.Status + " " + sender.Default);
                }

                senderApi.ActionDelete(name).Execute();
            }
            catch (SMSApi.Api.ClientException e)
            {
                System.Console.WriteLine(e.Message);
            }
        }

        public void test_hlr()
        {
            try
            {
                var hlrApi = new SMSApi.Api.HLRFactory(client());

                var hlrs = hlrApi.ActionCheckNumber("xxxyyyzzz").Execute();

                foreach (var nrinfo in hlrs.List)
                {
                    System.Console.WriteLine("ID: " + nrinfo.ID + " Number: " + nrinfo.Number + " Status: " + nrinfo.Status + " " + nrinfo.Info);
                }
            }
            catch (SMSApi.Api.ClientException e)
            {
                System.Console.WriteLine(e.Message);
            }
        }

        public void test_sms()
        {
            try
            {
                var smsApi = new SMSApi.Api.SMSFactory(client());

                var result =
                    smsApi.ActionSend()
                        .SetText("test message")
                        .SetTo("xxxyyyzzz")
                        .SetDateSent(DateTime.Now.AddHours(2))
                        .Execute();

                System.Console.WriteLine("Send: " + result.Count);

                string[] ids = new string[result.Count];

                for (int i = 0, l = 0; i < result.List.Count; i++)
                {
                    if (!result.List[i].isError())
                    {
                        //Nie wystąpił błąd podczas wysyłki (numer|treść|parametry... prawidłowe)
                        if (!result.List[i].isFinal())
                        {
                            //Status nie jest koncowy, może ulec zmianie
                            ids[l] = result.List[i].ID;
                            l++;
                        }
                    }
                }

                System.Console.WriteLine("Get:");
                result =
                    smsApi.ActionGet()
                        .Ids(ids)
                        .Execute();

                foreach (var status in result.List)
                {
                    System.Console.WriteLine("ID: " + status.ID + " NUmber: " + status.Number + " Points:" + status.Points + " Status:" + status.Status + " IDx: " + status.IDx);
                }

                var deleted =
                    smsApi
                        .ActionDelete()
                            .Id(ids[0])
                            .Execute();

                System.Console.WriteLine("Deleted: " + deleted.Count);
            }
            catch (SMSApi.Api.ActionException e)
            {
                /**
                 * Błędy związane z akcją (z wyłączeniem błędów 101,102,103,105,110,1000,1001 i 8,666,999,201)
                 * http://www.smsapi.pl/sms-api/kody-bledow
                 */
                System.Console.WriteLine(e.Message);
            }
            catch (SMSApi.Api.ClientException e)
            {
                /**
                 * 101 Niepoprawne lub brak danych autoryzacji.
                 * 102 Nieprawidłowy login lub hasło
                 * 103 Brak punków dla tego użytkownika
                 * 105 Błędny adres IP
                 * 110 Usługa nie jest dostępna na danym koncie
                 * 1000 Akcja dostępna tylko dla użytkownika głównego
                 * 1001 Nieprawidłowa akcja
                 */
                System.Console.WriteLine(e.Message);
            }
            catch (SMSApi.Api.HostException e)
            {
                /* błąd po stronie servera lub problem z parsowaniem danych
                 * 
                 * 8 - Błąd w odwołaniu
                 * 666 - Wewnętrzny błąd systemu
                 * 999 - Wewnętrzny błąd systemu
                 * 201 - Wewnętrzny błąd systemu
                 * SMSApi.Api.HostException.E_JSON_DECODE - problem z parsowaniem danych
                 */
                System.Console.WriteLine(e.Message);
            }
            catch (SMSApi.Api.ProxyException e)
            {
                // błąd w komunikacji pomiedzy klientem a serverem
                System.Console.WriteLine(e.Message);
            }
        }

        public void test_smsParams()
        {
            try
            {
                var smsApi = new SMSApi.Api.SMSFactory(client());

                var result =
                    smsApi.ActionSend()
                        .SetText("test [%1%] message [%2%]")
                        .SetTo("xxxyyyzzz")
                        .SetParam(0, "par1")
                        .SetParam(1, "par2")
                        .SetTest(true)
                        .Execute();

                System.Console.WriteLine("Send: " + result.Count);
            }
            catch (SMSApi.Api.ActionException e)
            {
                /**
                 * Błędy związane z akcją (z wyłączeniem błędów 101,102,103,105,110,1000,1001 i 8,666,999,201)
                 * http://www.smsapi.pl/sms-api/kody-bledow
                 */
                System.Console.WriteLine(e.Message);
            }
            catch (SMSApi.Api.ClientException e)
            {
                /**
                 * 101 Niepoprawne lub brak danych autoryzacji.
                 * 102 Nieprawidłowy login lub hasło
                 * 103 Brak punków dla tego użytkownika
                 * 105 Błędny adres IP
                 * 110 Usługa nie jest dostępna na danym koncie
                 * 1000 Akcja dostępna tylko dla użytkownika głównego
                 * 1001 Nieprawidłowa akcja
                 */
                System.Console.WriteLine(e.Message);
            }
            catch (SMSApi.Api.HostException e)
            {
                /* błąd po stronie servera lub problem z parsowaniem danych
                 * 
                 * 8 - Błąd w odwołaniu
                 * 666 - Wewnętrzny błąd systemu
                 * 999 - Wewnętrzny błąd systemu
                 * 201 - Wewnętrzny błąd systemu
                 * SMSApi.Api.HostException.E_JSON_DECODE - problem z parsowaniem danych
                 */
                System.Console.WriteLine(e.Message);
            }
            catch (SMSApi.Api.ProxyException e)
            {
                // błąd w komunikacji pomiedzy klientem a serverem
                System.Console.WriteLine(e.Message);
            }
        }

        public void test_mms()
        {
            try
            {
                var mmsApi = new SMSApi.Api.MMSFactory(client());

                var result =
                    mmsApi.ActionSend()
                        .SetSubject("test subject")
                        .SetSmil("<smil><head><layout><root-layout height=\"600\" width=\"425\"/><region id=\"Image\" top=\"0\" left=\"0\" height=\"100%\" width=\"100%\" fit=\"meet\"/></layout></head><body><par dur=\"5000ms\"><img src=\"http://www.smsapi.pl/media/mms.jpg\" region=\"Image\"></img></par></body></smil>")
                        .SetTo("xxxyyyzzz")
                        .SetDateSent(DateTime.Now.AddHours(2))
                        .Execute();

                System.Console.WriteLine("Send: " + result.Count);

                string[] ids = new string[result.Count];

                for (int i = 0, l = 0; i < result.List.Count; i++)
                {
                    ids[l] = result.List[i].ID;
                    l++;
                }

                System.Console.WriteLine("Get:");
                result =
                    mmsApi.ActionGet()
                        .Ids(ids)
                        .Execute();

                foreach (var status in result.List)
                {
                    System.Console.WriteLine("ID: " + status.ID + " NUmber: " + status.Number + " Points:" + status.Points + " Status:" + status.Status + " IDx: " + status.IDx);
                }

                var deleted =
                    mmsApi
                        .ActionDelete()
                            .Ids(ids)
                            .Execute();

                System.Console.WriteLine("Deleted: " + deleted.Count);
            }
            catch (SMSApi.Api.ClientException e)
            {
                System.Console.WriteLine(e.Message);
            }
        }

        public void test_vms()
        {
            try
            {
//                Stream file = System.IO.File.OpenRead("tts.wav");

                var vmsApi = new SMSApi.Api.VMSFactory(client());

                var result =
                    vmsApi.ActionSend()
//                        .SetFile(file)
                        .SetTTS("test message")
                        .SetTo("xxxyyzz")
                        .SetDateSent(DateTime.Now.AddHours(2))
                        .SetTry(3)
                        .SetTryInterval(300)
                        .SetFrom("xxxyyzz")
                        .Execute();

                System.Console.WriteLine("Send: " + result.Count);

                string[] ids = new string[result.Count];

                for (int i = 0, l = 0; i < result.List.Count; i++)
                {
                    ids[l] = result.List[i].ID;
                    l++;
                }

                System.Console.WriteLine("Get:");
                result =
                    vmsApi.ActionGet()
                        .Ids(ids)
                        .Execute();

                foreach (var status in result.List)
                {
                    System.Console.WriteLine("ID: " + status.ID + " NUmber: " + status.Number + " Points:" + status.Points + " Status:" + status.Status + " IDx: " + status.IDx);
                }

                var deleted =
                    vmsApi
                        .ActionDelete()
                            .Ids(ids)
                            .Execute();

                System.Console.WriteLine("Deleted: " + deleted.Count);
            }
            catch (SMSApi.Api.ClientException e)
            {
                System.Console.WriteLine(e.Message);
            }
        }

		class ContactsTest
		{
			protected ContactsFactory api = null;

			public void SetApi(ContactsFactory api)
			{
				this.api = api;
			}

			private ContactsTest nested = null;

			public void SetNested(ContactsTest nested)
			{
				this.nested = nested;
				if (api == null)
				{
					api = new SMSApi.Api.ContactsFactory(client());
				}
				nested.SetApi(api);
			}

			public virtual void Setup() {}

			public virtual void Cleanup() {}

			public void Test()
			{
				Setup();
				try
				{
					if (nested != null)
					{
						nested.contact = contact;
						nested.group = group;
						nested.field = field;
						nested.Test();
					}
				}
				catch (SMSApi.Api.Exception e)
				{
					Cleanup();
					throw;
				}
				Cleanup();
			}

			protected Contact contact = null;
			protected Group group = null;
			protected Field field = null;
		}

		class CreateContactTest : ContactsTest
		{
			private Contact createdContact;
			public override void Setup()
			{
				createdContact = api.CreateContact()
					.SetPhoneNumber("xxxyyyzzz")
						.Execute();
				contact = createdContact;
			}
			public override void Cleanup()
			{
				api.DeleteContact(createdContact.Id)
					.Execute();
			}
		}

		class ListContactsTest : ContactsTest
		{
			public override void Setup()
			{
				var contacts =  api.ListContacts()
					.Execute();

				System.Console.WriteLine("Contacts size: " + contacts.Size);
				foreach (var contact in contacts.Collection)
				{
					System.Console.WriteLine("Id: " + contact.Id +
					                         " Idx: " + contact.Idx +
					                         " FirstName: " + contact.FirstName +
					                         " LastName: " + contact.LastName +
					                         " BirthdayDate: " + contact.BirthdayDate +
					                         " PhoneNumber: " + contact.PhoneNumber +
					                         " Email: " + contact.Email +
					                         " Gender: " + contact.Gender +
					                         " City: " + contact.City +
					                         " Source: " + contact.Source +
					                         " DateCreated: " + contact.DateCreated +
					                         " DateUpdated: " + contact.DateUpdated +
					                         " Description: " + contact.Description);
				}
			}
		}

		class GetContactTest : ContactsTest
		{
			public override void Setup()
			{
				contact = api.GetContact(contact.Id)
					.Execute();
			}
		}

		class EditContactTest : ContactsTest
		{
			public override void Setup()
			{
				contact = api.EditContact(contact.Id)
					.SetFirstName("Tester")
					.Execute();
			}
		}

		class CreateGroupTest : ContactsTest
		{
			private Group createdGroup;
			public override void Setup()
			{
				createdGroup = api.CreateGroup()
					.SetName("GroupX")
					.Execute();
				group = createdGroup;
			}
			public override void Cleanup()
			{
				api.DeleteGroup(createdGroup.Id)
					.Execute();
			}
		}

		class ListGroupsTest : ContactsTest
		{
			public override void Setup()
			{
				var groups = api.ListGroups()
					.Execute();

				System.Console.WriteLine("Groups size: " + groups.Size);
				foreach (var group in groups.Collection)
				{
					System.Console.WriteLine("Id: " + group.Id +
					                         " Name: " + group.Name +
					                         " ContactsCount: " + group.ContactsCount +
					                         " DateCreated: " + group.DateCreated +
					                         " DateUpdated: " + group.DateUpdated +
					                         " Description: " + group.Description +
					                         " CreatedBy: " + group.CreatedBy +
					                         " Idx: " + group.Idx);
					foreach (var groupPermission in group.Permissions)
					{
						System.Console.WriteLine("GroupId: " + groupPermission.GroupId +
						                         " Username: " + groupPermission.Username +
						                         " Write: " + groupPermission.Write +
						                         " Read: " + groupPermission.Read +
						                         " Send: " + groupPermission.Send);
					}
				}
			}
		}

		class GetGroupTest : ContactsTest
		{
			public override void Setup()
			{
				group = api.GetGroup(group.Id)
					.Execute();
			}
		}

		class EditGroupTest : ContactsTest
		{
			public override void Setup()
			{
				group = api.EditGroup(group.Id)
					.SetName("GroupY")
					.Execute();
			}
		}

		class ListGroupPermissionsTest : ContactsTest
		{
			public override void Setup()
			{
				var groupPermissions = api.ListGroupPermissions(group.Id)
					.Execute();

				System.Console.WriteLine("Group permissions size: " + groupPermissions.Size);
				foreach (var groupPermission in groupPermissions.Collection)
				{
					System.Console.WriteLine("GroupId: " + groupPermission.GroupId +
					                         " Username: " + groupPermission.Username +
					                         " Read: " + groupPermission.Read +
					                         " Write: " + groupPermission.Write +
					                         " Send: " + groupPermission.Send);
				}
			}
		}

		class CreateFieldTest : ContactsTest
		{
			private Field createdField;
			public override void Setup()
			{
				createdField = api.CreateField()
					.SetName("FieldX")
					.SetType(Field.TextType)
					.Execute();
				field = createdField;
			}
			public override void Cleanup()
			{
				api.DeleteField(createdField.Id)
					.Execute();
			}
		}

		class ListFieldsTest : ContactsTest
		{
			public override void Setup()
			{
				var fields = api.ListFields()
					.Execute();

				System.Console.WriteLine("Fields size: " + fields.Size);
				foreach (var field in fields.Collection)
				{
					System.Console.WriteLine("Name: " + field.Name +
					                         " Type: " + field.Type);
				}
			}
		}

		class EditFieldTest : ContactsTest
		{
			public override void Setup()
			{
				api.EditField(field.Id)
					.SetName("FieldY")
					.Execute();
			}
		}

		class ListFieldOptionsTest : ContactsTest
		{
			public override void Setup()
			{
				var fieldOptions = api.ListFieldOptions(field.Id)
					.Execute();

				System.Console.WriteLine("Field options size: " + fieldOptions.Size);
				foreach (var fieldOption in fieldOptions.Collection)
				{
					System.Console.WriteLine("Name: " + fieldOption.Name +
					                         " Value: " + fieldOption.Value);
				}
			}
		}

		class BindContactToGroupTest : ContactsTest
		{
			private Contact bindedContact;
			private Group bindedGroup;
			public override void Setup()
			{
				api.BindContactToGroup(contact.Id, group.Id)
					.Execute();
				bindedContact = contact;
				bindedGroup = group;
			}
			public override void Cleanup()
			{
				api.UnbindContactFromGroup(bindedContact.Id, bindedGroup.Id)
					.Execute();
			}
		}

		class GetContactGroupTest : ContactsTest
		{
			public override void Setup()
			{
				group = api.GetContactGroup(contact.Id, group.Id)
					.Execute();
			}
		}

		class ListContactGroupsTest : ContactsTest
		{
			public override void Setup()
			{
				var groups = api.ListContactGroups(contact.Id)
					.Execute();

				System.Console.WriteLine("Contact groups size: " + groups.Size);
			}
		}

		class CreateGroupPermissionTest : ContactsTest
		{
			private Group permissionedGroup;
			public override void Setup()
			{
				api.CreateGroupPermission(group.Id)
					.SetUsername("username")
					.SetRead(true)
					.SetWrite(false)
					.SetSend(false)
					.Execute();
				permissionedGroup = group;
			}
			public override void Cleanup()
			{
				api.DeleteGroupPermission(permissionedGroup.Id, "username")
					.Execute();
			}
		}

		class GetGroupPermissionTest : ContactsTest
		{
			public override void Setup()
			{
				api.GetGroupPermission(group.Id, "username")
					.Execute();
			}
		}

		class EditGroupPermissionTest : ContactsTest
		{
			public override void Setup()
			{
				api.EditGroupPermission(group.Id, "username")
					.SetRead(true)
					.SetWrite(true)
					.SetSend(true)
					.Execute();
			}
		}

		public void test_contacts()
		{
			var tests = new[] {
				new ContactsTest(), //dummy

				new CreateContactTest(),
				new GetContactTest(),
				new EditContactTest(),
				new ListContactsTest(),

				new CreateGroupTest(),
				new GetGroupTest(),
				new EditGroupTest(),
				new ListGroupsTest(),

				new BindContactToGroupTest(),
				new GetContactGroupTest(),
				new ListContactGroupsTest(),

				new CreateGroupPermissionTest(),
				new GetGroupPermissionTest(),
				new EditGroupPermissionTest(),
				new ListGroupPermissionsTest(),

				new CreateFieldTest(),
				new EditFieldTest(),
				new ListFieldsTest(),
				//new ListFieldOptionsTest(),
			};

			for (int i = 1; i < tests.Length; ++i)
			{
				tests[i-1].SetNested(tests[i]);
			}

			tests[0].Test();
		}
    }
}
