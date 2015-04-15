using System.Collections.Specialized;

/**
 * add_user * Nazwa dodawanego podużytkownika bez prefiksu użytkownika głównego
 * pass * Hasło do panelu klienta SMSAPI dodawanego podużytkownika zakodowane w md5
 * pass_api Hasło do interfejsu API dla podużytkownika zakodowane w md5, brak tego parametru spowoduje ustawienie jako hasła do API kopii hasła do panelu klienta
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
    public class UserEdit : BaseSimple<SMSApi.Api.Response.User>
    {
        public UserEdit()
            : base() 
        {
            limit = -1;
            monthLimit = -1;
            active = -1;
            phonebook = -1;
            senders = -1;
        }

        protected override string Uri() { return "user.do"; }

        const int SENDERS_NOSHARE = 0;
        const int SENDERS_SHARE = 1;

        const int PHONEBOOK_NOSHARE = 0;
        const int PHONEBOOK_SHARE = 1;

        protected string username;
        protected string password;
        protected string passwordApi;
        protected double limit;
        protected double monthLimit;
        protected int senders;
        protected int phonebook;
        protected int active;
        protected string info;
        protected bool withoutPrefix = false;

        protected override NameValueCollection Values()
        {
            NameValueCollection collection = new NameValueCollection();

            collection.Add("format", "json");

            collection.Add("username", client.GetUsername());
            collection.Add("password", client.GetPassword());

            collection.Add("set_user", username);
            if (password != null) collection.Add("pass", password);
            if (passwordApi != null) collection.Add("pass_api", passwordApi);
            if (limit >= 0) collection.Add("limit", limit.ToString());
            if (monthLimit >= 0) collection.Add("month_limit", monthLimit.ToString());
            if (senders >= 0) collection.Add("senders", senders.ToString());
            if (phonebook >= 0) collection.Add("phonebook", phonebook.ToString());
            if (active >= 0) collection.Add("active", (active > 0 ? "1" : "0"));
            if (info != null) collection.Add("info", info);
            if (withoutPrefix) collection.Add("without_prefix", "1");

            return collection;
        }

        public UserEdit Username(string username)
        {
            this.username = username;
            return this;
        }

        public UserEdit SetPassword(string password)
        {
            this.password = password;
            return this;
        }

        public UserEdit SetPasswordApi(string password)
        {
            this.passwordApi = password;
            return this;
        }

        public UserEdit SetLimit(double limit)
        {
            this.limit = limit;
            return this;
        }

        public UserEdit SetMonthLimit(double limit)
        {
            this.monthLimit = limit;
            return this;
        }

        public UserEdit SetSenders(int flag)
        {
            this.senders = flag;
            return this;
        }

        public UserEdit SetPhonebook(int flag)
        {
            this.phonebook = flag;
            return this;
        }

        public UserEdit SetActive(bool flag)
        {
            this.active = (flag ? 1 : 0);
            return this;
        }

        public UserEdit SetInfo(string text)
        {
            this.info = text;
            return this;
        }

        public UserEdit SetWithoutPrefix(bool flag)
        {
            this.withoutPrefix = flag;
            return this;
        }
    }
}
