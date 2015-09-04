using System;
using System.IO;

namespace SMSApi
{
    class Test
    {
        static void Main(string[] args)
        {
            var o = new Test();

            o.test_sms();
            o.test_smsParams();
            o.test_hlr();
            o.test_sender();
            o.test_user();
        }

        public SMSApi.Api.Client client()
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

        public void test_sender()
        {
            try
            {
                var senderApi = new SMSApi.Api.SenderFactory(client());

                string name = "testName";

                senderApi.ActionAdd(name).Execute();

                senderApi.ActionSetDefault("SMSAPI.com").Execute();

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
                        if (!result.List[i].isFinal())
                        {
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
				 * Errors associated with the action (excluding errors 101,102,103,105,110,1000,1001,8,666,999,201)
				 * https://www.smsapi.com/resp
				 */
				System.Console.WriteLine(e.Message);
			}
            catch (SMSApi.Api.ClientException e)
{
			/**
			 * 101 Invalid authorization info. ATTENTION! API password ma be different than web panel password.
			 * 102 Invalid username or password.
			 * 103 Insufficient credits on Your account.
			 * 105 Wrong IP address (for IP filter turned on).
			 * 110 Action not allowed on your account
			 * 1000 Action allowed only on main account
			 * 1001 Wrong action
			 */
			catch (SMSApi.Api.HostException e)
			{
				/* other errors
				 * 
				 * 8 - Error in request
				 * 666 - Internal system error
				 * 999 - Internal system error
				 * 201 - Internal system error
				 * SMSApi.Api.HostException.E_JSON_DECODE - problem with data parsing
				 */
				System.Console.WriteLine(e.Message);
			}
            catch (SMSApi.Api.ProxyException e)
			{
				// problem with connection between server and client
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
				 * Errors associated with the action (excluding errors 101,102,103,105,110,1000,1001,8,666,999,201)
				 * https://www.smsapi.com/resp
				 */
				System.Console.WriteLine(e.Message);
			}
			catch (SMSApi.Api.ClientException e)
			{
				/**
				 * 101 Invalid authorization info. ATTENTION! API password ma be different than web panel password.
				 * 102 Invalid username or password.
				 * 103 Insufficient credits on Your account.
				 * 105 Wrong IP address (for IP filter turned on).
				 * 110 Action not allowed on your account
				 * 1000 Action allowed only on main account
				 * 1001 Wrong action
				 */
				System.Console.WriteLine(e.Message);
			}
			catch (SMSApi.Api.HostException e)
			{
				/* other errors
				 * 
				 * 8 - Error in request
				 * 666 - Internal system error
				 * 999 - Internal system error
				 * 201 - Internal system error
				 * SMSApi.Api.HostException.E_JSON_DECODE - problem with data parsing
				 */
				System.Console.WriteLine(e.Message);
			}
			catch (SMSApi.Api.ProxyException e)
			{
				// problem with connection between server and client
				System.Console.WriteLine(e.Message);
			}
        }
    }
}
