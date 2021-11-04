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
    public class UserEdit : BaseSimple<User>
    {
        private const int PHONEBOOK_NOSHARE = 0;
        private const int PHONEBOOK_SHARE = 1;

        private const int SENDERS_NOSHARE = 0;
        private const int SENDERS_SHARE = 1;
        protected int active;
        protected string info;
        protected double limit;
        protected double monthLimit;
        protected string password;
        protected string passwordApi;
        protected int phonebook;
        protected int senders;

        protected string username;
        protected bool withoutPrefix;

        public UserEdit()
        {
            limit = -1;
            monthLimit = -1;
            active = -1;
            phonebook = -1;
            senders = -1;
        }

        public UserEdit SetActive(bool flag)
        {
            active = flag ? 1 : 0;
            return this;
        }

        public UserEdit SetInfo(string text)
        {
            info = text;
            return this;
        }

        public UserEdit SetLimit(double limit)
        {
            this.limit = limit;
            return this;
        }

        public UserEdit SetMonthLimit(double limit)
        {
            monthLimit = limit;
            return this;
        }

        public UserEdit SetPassword(string password)
        {
            this.password = password;
            return this;
        }

        public UserEdit SetPasswordApi(string password)
        {
            passwordApi = password;
            return this;
        }

        public UserEdit SetPhonebook(int flag)
        {
            phonebook = flag;
            return this;
        }

        public UserEdit SetSenders(int flag)
        {
            senders = flag;
            return this;
        }

        public UserEdit SetWithoutPrefix(bool flag)
        {
            withoutPrefix = flag;
            return this;
        }

        public UserEdit Username(string username)
        {
            this.username = username;
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
            collection.Add("set_user", username);
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

            if (active >= 0)
            {
                collection.Add("active", active > 0 ? "1" : "0");
            }

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
