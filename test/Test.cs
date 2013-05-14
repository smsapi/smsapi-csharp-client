using System;
using System.IO;

namespace SMSApi
{
    class Test
    {
        static void Main(string[] args)
        {
            var o = new Test();

//            o.test_sms();
//            o.test_mms();
//            o.test_vms();
//            o.test_hlr();
//            o.test_sender();
//            o.test_phonebookgroup();
            o.test_phonebookcontact();
        }

        public SMSApi.Api.Client client()
        {
            SMSApi.Api.Client client = new SMSApi.Api.Client("test");
            client.SetPasswordRAW("test");

            return client;
        }

        protected SMSApi.Api.SMSFactory SMSFactory;
        protected SMSApi.Api.MMSFactory MMSFactory;
        protected SMSApi.Api.VMSFactory VMSFactory;

        public Test()
        {
            SMSFactory = new SMSApi.Api.SMSFactory(client());
            MMSFactory = new SMSApi.Api.MMSFactory(client());
            VMSFactory = new SMSApi.Api.VMSFactory(client());
        }

        public void test_phonebookgroup()
        {
            var phonebook = new SMSApi.Api.PhonebookFactory(client());

            string groupName = "new group123" + DateTime.Now.ToString("his");

            phonebook.ActionGroupAdd()
                .SetInfo("ooo info")
                .SetName(groupName)
                .Execute();

            var group = 
                phonebook.ActionGroupEdit(groupName)
                    .SetName(groupName + "#edit")
                    .SetInfo("edited info")
                    .Execute();

            group = 
                phonebook.ActionGroupGet(group.Name)
                    .Execute();

            var groups = phonebook.ActionGroupList().Execute();

            foreach (var g in groups.List)
            {
                System.Console.WriteLine(g.Name + " " + g.NumbersCount + " " + g.Info);
            }

            phonebook.ActionGroupDelete(group.Name)
                .Contacts(false)
                .Execute();
        }

        public void test_phonebookcontact() {

            var phonebook = new SMSApi.Api.PhonebookFactory(client());

            var number = "694562821";

            var contact = 
                phonebook.ActionContactAdd(number)
                    .SetFirstName("Test contact" + DateTime.Now.ToString("his"))
                    .Execute();

            var contacts = phonebook.ActionContactList().Execute();
            foreach (var c in contacts.List)
            {
                System.Console.WriteLine(c.Number + " " + c.FirstName + " " + c.LastName + " " + c.Gender);
            }

            contact = phonebook.ActionContactGet(contact.Number).Execute();

            phonebook.ActionContactDelete(contact.Number).Execute();
        }

        public void test_sender()
        {
            var proxy = new SMSApi.Api.ProxyHTTP("http://smsapi.local/api/");

            var act = new SMSApi.Api.Action.SenderAdd();

            act.Client(client());
            act.Proxy(proxy);

            act.SetName("asdddggga");
            System.Console.WriteLine(act.Execute().Count);


            SMSApi.Api.Action.SenderList senders =
                new SMSApi.Api.Action.SenderList();

            senders.Client(client());
            senders.Proxy(proxy);

            var response = senders.Execute();
            System.Console.WriteLine(response.Count);
            foreach (var a in response)
            {
                System.Console.WriteLine("Name: " + a.Name + " " + a.Status + " " + a.Default);
            }


            var actDel = new SMSApi.Api.Action.SenderDelete();
            actDel.Client(client());
            actDel.Proxy(proxy);
            actDel.Name("asdddggaga");
            var dr = actDel.Execute();

            System.Console.WriteLine("Delete name " + dr.ErrorCode + " " + dr.ErrorMessage);

            var actDef = new SMSApi.Api.Action.SenderSetDefault();
            actDef.Client(client());
            actDef.Proxy(proxy);
            actDef.Name("UWAGA");
            var dfr = actDef.Execute();
        }

        public void test_hlr()
        {
            SMSApi.Api.Action.HLRCheckNumber hlr =
                new SMSApi.Api.Action.HLRCheckNumber();

            var proxy = new SMSApi.Api.ProxyHTTP("http://smsapi.local/api/");

            hlr.Client(client());
            hlr.Proxy(proxy);

            hlr.SetNumber("694562829");
            var r = hlr.Execute();

            foreach (var a in r.List)
            {
                System.Console.WriteLine("ID: " + a.ID + " Number: " + a.Number + " Status: " + a.Status + " " + a.Info);
            }
        }

        public void test_sms()
        {
            var result = 
                SMSFactory.ActionSend()
                    .SetText("test message")
                    .SetTo("694562829")
                    .SetDateSent(DateTime.Now.AddHours(2))
                    .Execute();

            System.Console.WriteLine("Send: " + result.Count);

            string[] ids = new string[result.Count];

            for (int i = 0, l = 0; i < result.List.Count; i++)
            {
                if (!result.List[i].isError() )
                {
                    if (!result.List[i].isFinal())
                    {
                        ids[l] = result.List[i].ID;
                        l++;
                    }
                }
            }

            System.Console.WriteLine("Get:");
            result =
                SMSFactory.ActionGet()
                    .Id(ids)
                    .Execute();

            foreach (var status in result.List)
            {
                System.Console.WriteLine("ID: " + status.ID + " NUmber: " + status.Number + " Points:" + status.Points + " Status:" + status.Status + " IDx: " + status.IDx);
            }       

            var deleted =
                SMSFactory
                    .ActionDelete()
                        .Id(ids)
                        .Execute();

            System.Console.WriteLine("Deleted: " + deleted.Count);
        }

        public void test_mms()
        {
            var result =
                MMSFactory.ActionSend()
                    .SetSubject("test subject")
                    .SetSmil("<smil><head><layout><root-layout height=\"600\" width=\"425\"/><region id=\"Image\" top=\"0\" left=\"0\" height=\"100%\" width=\"100%\" fit=\"meet\"/></layout></head><body><par dur=\"5000ms\"><img src=\"http://www.smsapi.pl/media/mms.jpg\" region=\"Image\"></img></par></body></smil>")
                    .SetTo("694562829")
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
                MMSFactory.ActionGet()
                    .Id(ids)
                    .Execute();

            foreach (var status in result.List)
            {
                System.Console.WriteLine("ID: " + status.ID + " NUmber: " + status.Number + " Points:" + status.Points + " Status:" + status.Status + " IDx: " + status.IDx);
            }

            var deleted =
                MMSFactory
                    .ActionDelete()
                        .Id(ids)
                        .Execute();

            System.Console.WriteLine("Deleted: " + deleted.Count);
        }

        public void test_vms()
        {
            Stream file = System.IO.File.OpenRead("tts.wav");

            var result =
                VMSFactory.ActionSend()
                    .SetFile(file)
                    .SetTo("694562829")
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
                VMSFactory.ActionGet()
                    .Id(ids)
                    .Execute();

            foreach (var status in result.List)
            {
                System.Console.WriteLine("ID: " + status.ID + " NUmber: " + status.Number + " Points:" + status.Points + " Status:" + status.Status + " IDx: " + status.IDx);
            }

            var deleted =
                VMSFactory
                    .ActionDelete()
                        .Id(ids)
                        .Execute();

            System.Console.WriteLine("Deleted: " + deleted.Count);
        }
    }
}
