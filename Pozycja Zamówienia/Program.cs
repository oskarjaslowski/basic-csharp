using System;

namespace PozycjaZamowienia
{
    public class PozycjaZamowienia
    {
        private string nazwa;
        private int ilosc;
        private decimal cenaNetto;
        private decimal vat;
        private int _id;

        public static int liczbaPozycji;

        // Konstruktory
        public PozycjaZamowienia(string nazwa, int ilosc, decimal cenaNetto, decimal vat, int id)
        {
            this.nazwa = nazwa;
            this.ilosc = ilosc;
            this.cenaNetto = cenaNetto;
            this.vat = vat;
            this._id = id;
            liczbaPozycji++;
        }

        public PozycjaZamowienia()
        {
            liczbaPozycji++;
        }

        static PozycjaZamowienia()
        {
            liczbaPozycji = 0;
        }

        public PozycjaZamowienia(PozycjaZamowienia pozycja)
        {
            this.nazwa = pozycja.nazwa;
            this.ilosc = pozycja.ilosc;
            this.cenaNetto = pozycja.cenaNetto;
            this.vat = pozycja.vat;
            this._id = pozycja._id;
            liczbaPozycji++;
        }
        public string Nazwa
        {
            get { return nazwa; }
            set { nazwa = value; }
        }

        public int Ilosc
        {
            get { return ilosc; }
            set { ilosc = value; }
        }

        public decimal CenaNetto
        {
            get { return cenaNetto; }
            set { cenaNetto = value; }
        }

        public decimal Vat
        {
            get { return vat; }
            set { vat = value; }
        }

        public decimal WartoscBrutto
        {
            get { return (1 + vat / 100) * ilosc * cenaNetto; }
        }

        public int Id
        {
            get { return _id; }
            private set { _id = value; }
        }

        public override string ToString()
        {
            return $"Nazwa: {nazwa}, Ilość: {ilosc}, Cena Netto: {cenaNetto}, VAT: {vat}, Id: {_id}";
        }
    }
    public class Produkt : PozycjaZamowienia
    {
        private static decimal iloscRabat = 5;

        public Produkt(string nazwa, int ilosc, decimal cenaNetto, decimal vat, int id) : base(nazwa, ilosc, cenaNetto, vat, id)
        {
        }

        public decimal Rabat
        {
            get
            {
                if (Ilosc < iloscRabat)
                    return WartoscBrutto * 0.05m;
                else
                    return WartoscBrutto * 0.1m;
            }
        }

        public override string ToString()
        {
            return base.ToString() + $", Kwota: {Rabat}";
        }
    }

    public class Usluga : PozycjaZamowienia
    {
        private static decimal kwotaRabat = 100;

        public Usluga(string nazwa, int ilosc, decimal cenaNetto, decimal vat, int id) : base(nazwa, ilosc, cenaNetto, vat, id)
        {
        }

        public decimal Rabat
        {
            get
            {
                if (WartoscBrutto < kwotaRabat)
                    return WartoscBrutto * 0.1m;
                else
                    return WartoscBrutto * 0.2m;
            }
        }

        public override string ToString()
        {
            return base.ToString() + $", Rabat: {Rabat}";
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            PozycjaZamowienia pozycja1 = new PozycjaZamowienia("Produkt1", 5, 10.00m, 23, 1);
            PozycjaZamowienia pozycja2 = new PozycjaZamowienia("Produkt2", 10, 20.00m, 23, 2);
            PozycjaZamowienia pozycja3 = new PozycjaZamowienia("Usługa1", 2, 50.00m, 8, 3);

            Produkt produkt1 = new Produkt("Produkt1", 5, 10.00m, 23, 4);
            Usluga usługa1 = new Usluga("Usługa1", 2, 50.00m, 8, 5);

            Console.WriteLine("Pozycja 1:");
            Console.WriteLine($"Nazwa: {pozycja1.Nazwa}, Ilość: {pozycja1.Ilosc}, Cena Netto: {pozycja1.CenaNetto}, VAT: {pozycja1.Vat}");
            Console.WriteLine();

            Console.WriteLine("Pozycja 2:");
            Console.WriteLine($"Nazwa: {pozycja2.Nazwa}, Ilość: {pozycja2.Ilosc}, Cena Netto: {pozycja2.CenaNetto}, VAT: {pozycja2.Vat}");
            Console.WriteLine();

            Console.WriteLine("Pozycja 3:");
            Console.WriteLine($"Nazwa: {pozycja3.Nazwa}, Ilość: {pozycja3.Ilosc}, Cena Netto: {pozycja3.CenaNetto}, VAT: {pozycja3.Vat}");
            Console.WriteLine();

            Console.WriteLine($"Liczba pozycji zamówienia: {PozycjaZamowienia.liczbaPozycji}");

            Console.WriteLine();

            Console.WriteLine("Produkt 1:");
            Console.WriteLine($"Nazwa: {produkt1.Nazwa}, Ilość: {produkt1.Ilosc}, Cena Netto: {produkt1.CenaNetto}, VAT: {produkt1.Vat}, Rabat: {produkt1.Rabat}");
            Console.WriteLine();

            Console.WriteLine("Usługa 1:");
            Console.WriteLine($"Nazwa: {usługa1.Nazwa}, Ilość: {usługa1.Ilosc}, Cena Netto: {usługa1.CenaNetto}, VAT: {usługa1.Vat}, Rabat: {usługa1.Rabat}");
            Console.WriteLine();
        }
    }
}