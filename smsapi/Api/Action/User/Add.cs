using System.Collections.Specialized;
using SMSApi.Api.Response;

/**
 * add_user * Nazwa dodawanego podużytkownika bez prefiksu użytkownika głównego
 * pass * Hasło do panelu klienta SMSAPI dodawanego podużytkownika zakodowane w md5
 * pass_api Hasło do interfejsu API dla podużytkownika zakodowane w md5
 * limit Limit punktów przydzielony podużytkownikowi
 * month_limit Ilość punktów która będzie przypisana do konta podużytkownika każdego pierwszego dnia 
 * senders Udostępnienie pól nadawców konta głównego (dostępne wartości: 1 – udostępniaj, 0 – nie udostępniaj, domyślnie wartość równa 0)
 * phonebook Udostępnienie grup książki telefonicznej konta głównego (dostępne wartości: 1 – udostępniaj, 0 – nie udostępniaj, domyślnie wartość równa 0). Po udostępnieniu 
 *      książki podużytkownik będzie mógł wysyłać do grup wiadomości nie będzie jednak widział poszczególnych kontaktów w książce telefonicznej.
 * active Aktywowanie konta podużytkownika (dostępne wartości: 1 – aktywne, 0 – nieaktywne, domyślnie wartość równa 0)
 * info Dodatkowy opis podużytkownika
 */
namespace SMSApi.Api.Action
{
    public class UserAdd : BaseSimple<User>
    {
        private const int PHONEBOOK_NOSHARE = 0;
        private const int PHONEBOOK_SHARE = 1;

        private const int SENDERS_NOSHARE = 0;
        private const int SENDERS_SHARE = 1;
        protected bool active;
        protected string info;
        protected double limit;
        protected double monthLimit;

        protected string newUsername;
        protected string password;
        protected string passwordApi;
        protected int phonebook;
        protected int senders;
        protected bool withoutPrefix;

        public UserAdd()
        {
            limit = -1;
            monthLimit = -1;
            active = false;
            phonebook = -1;
            senders = -1;
        }

        public UserAdd SetActive(bool flag)
        {
            active = flag;
            return this;
        }

        public UserAdd SetInfo(string text)
        {
            info = text;
            return this;
        }

        public UserAdd SetLimit(double limit)
        {
            this.limit = limit;
            return this;
        }

        public UserAdd SetMonthLimit(double limit)
        {
            monthLimit = limit;
            return this;
        }

        public UserAdd SetPassword(string password)
        {
            this.password = password;
            return this;
        }

        public UserAdd SetPasswordApi(string password)
        {
            passwordApi = password;
            return this;
        }

        public UserAdd SetPhonebook(int flag)
        {
            phonebook = flag;
            return this;
        }

        public UserAdd SetSenders(int flag)
        {
            senders = flag;
            return this;
        }

        public UserAdd SetUsername(string username)
        {
            newUsername = username;
            return this;
        }

        public UserAdd SetWithoutPrefix(bool flag)
        {
            withoutPrefix = flag;
            return this;
        }

        protected override string Uri()
        {
            return "user.do";
        }

        protected override NameValueCollection Values()
        {
            var collection = new NameValueCollection();

            collection.Add("format", "json");
            collection.Add("add_user", newUsername);
            if (password != null)
            {
                collection.Add("pass", password);
            }

            if (passwordApi != null)
            {
                collection.Add("pass_api", passwordApi);
            }

            if (limit >= 0)
            {
                collection.Add("limit", limit.ToString());
            }

            if (monthLimit >= 0)
            {
                collection.Add("month_limit", monthLimit.ToString());
            }

            if (senders >= 0)
            {
                collection.Add("senders", senders.ToString());
            }

            if (phonebook >= 0)
            {
                collection.Add("phonebook", phonebook.ToString());
            }

            collection.Add("active", active ? "1" : "0");
            if (info != null)
            {
                collection.Add("info", info);
            }

            if (withoutPrefix)
            {
                collection.Add("without_prefix", "1");
            }

            return collection;
        }
    }
}
