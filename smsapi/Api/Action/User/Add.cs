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
    public class UserAdd : BaseSimple<Response.User>
    {
        public UserAdd()
        {
            _limit = -1;
            _monthLimit = -1;
            _active = false;
            _phonebook = -1;
            _senders = -1;
        }

        protected override string Uri() => "user.do";

        const int SENDERS_NOSHARE = 0;
        const int SENDERS_SHARE = 1;

        const int PHONEBOOK_NOSHARE = 0;
        const int PHONEBOOK_SHARE = 1;

        private string _newUsername;
        private string _password;
        private string _passwordApi;
        private double _limit;
        private double _monthLimit;
        private int _senders;
        private int _phonebook;
        private bool _active;
        private string _info;
        private bool _withoutPrefix = false;

        protected override NameValueCollection Values()
        {
            NameValueCollection collection = new NameValueCollection
            {
                {"format", "json"},
                {"username", client.GetUsername()},
                {"password", client.GetPassword()},
                {"add_user", _newUsername}
            };

            if (_password != null) collection.Add("pass", _password);
            if (_passwordApi != null) collection.Add("pass_api", _passwordApi);
            if (_limit >= 0) collection.Add("limit", _limit.ToString());
            if (_monthLimit >= 0) collection.Add("month_limit", _monthLimit.ToString());
            if (_senders >= 0) collection.Add("senders", _senders.ToString());
            if (_phonebook >= 0) collection.Add("phonebook", _phonebook.ToString());
            collection.Add("active", (_active == true ? "1" : "0"));
            if (_info != null) collection.Add("info", _info);
            if (_withoutPrefix) collection.Add("without_prefix", "1");

            return collection;
        }

        public UserAdd SetUsername(string username)
        {
            _newUsername = username;
            return this;
        }

        public UserAdd SetPassword(string password)
        {
            _password = password;
            return this;
        }

        public UserAdd SetPasswordApi(string password)
        {
            _passwordApi = password;
            return this;
        }

        public UserAdd SetLimit(double limit)
        {
            _limit = limit;
            return this;
        }

        public UserAdd SetMonthLimit(double limit)
        {
            _monthLimit = limit;
            return this;
        }

        public UserAdd SetSenders(int flag)
        {
            _senders = flag;
            return this;
        }

        public UserAdd SetPhonebook(int flag)
        {
            _phonebook = flag;
            return this;
        }

        public UserAdd SetActive(bool flag)
        {
            _active = flag;
            return this;
        }

        public UserAdd SetInfo(string text)
        {
            _info = text;
            return this;
        }

        public UserAdd SetWithoutPrefix(bool flag)
        {
            _withoutPrefix = flag;
            return this;
        }
    }
}