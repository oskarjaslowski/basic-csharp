using System;
namespace Pensja
{
    class Pracownik
    {
        private int _id;
        private string _imie;
        private string _nazwisko;
        private double _liczbaGodzin;
        private double _stawkaGodzinowa;
        //pole satytczne dotyczy całej klasy a nie pojedynczego obiektu
        public static int liczbaPracownikow;

        //konstruktor inicjujący wszystkie pola
        public Pracownik(string imie, string nazwisko, double liczbaGodzin, double stawkaGodzinowa)
        {
            _imie = imie;
            _nazwisko = nazwisko;
            _liczbaGodzin = liczbaGodzin;
            _stawkaGodzinowa = stawkaGodzinowa;
            liczbaPracownikow++;
            Id = liczbaPracownikow;
        }
        //konstruktor domyślny
        public Pracownik()
        {
            liczbaPracownikow++;
            Id = liczbaPracownikow;
        }
        //Konstruktor statyczny, inicjalizuje składnik statyczny
        //1. nie może mieć modyfikatorów dostępu
        //2. nie może przyjmować argumentów
        //jest wywoływany automatycznie przed tworzeniem obiektów
        static Pracownik()
        {
            liczbaPracownikow = 0;
        }
        //konstruktor kopiujący
        //przyjmuje jako parametr obiekt typu Pracownik
        public Pracownik(Pracownik kopia)
        {
            this._imie = kopia._imie;
            this._nazwisko = kopia._nazwisko;
            this._liczbaGodzin = kopia._liczbaGodzin;
            this._stawkaGodzinowa = kopia._stawkaGodzinowa;
            liczbaPracownikow++;
            Id = liczbaPracownikow;
        }

        public string Nazwisko
        {
            //pobiera wartości pól prywatnych
            get
            {
                //zanim zostanie zwrócona wartość można
                //np. sparwdzić czy użytkownik ma dostęp do danych osobowych 
                return _nazwisko;
            }
            //ustawia wartości pól prywatnych,
            //przed przypisaniem można np. foramtować wyświetlany tekst
            //lub walidować ustawianą wartość
            set
            {
                if (!String.IsNullOrEmpty(_nazwisko))
                    _nazwisko = value;
            }
        }
        public string Imie { get { return _imie; } set { _imie = value; } }
        public double LiczbaGodzin { get { return _liczbaGodzin; } set { _liczbaGodzin = value; } }
        public double StawkaGodzinowa { get { return _stawkaGodzinowa; } set { _stawkaGodzinowa = value; } }
        //właściwość automatyczna
        public string Adres { get; set; }

        public double Zasadnicza
        {
            get
            {
                return _liczbaGodzin * _stawkaGodzinowa;
            }
        }

        public int Id
        {
            get
            {
                return _id;
            }
            private set
            {
                //narzucam id wewnątrz klasy
                _id = value;
            }
        }
        public override string ToString()
        {
            return ($"{_id,-5} {_nazwisko,-20} {_imie,-10} {_liczbaGodzin,-10} {_stawkaGodzinowa,-10:c2} zasadnicza: {Zasadnicza,-10}");
        }
    }
}
