namespace Pensja
{
    class Kierowca : Pracownik
    {
        public int LiczbaPrzejechanychKm { get; set; }
        public static double sredniaIloscKm = 8000;
		
        public double Premia
        {
            get
            {
                return Zasadnicza * (LiczbaPrzejechanychKm > sredniaIloscKm ? 0.2 : 0.1);
            }
        }
		
        public Kierowca(string imie, string nazwisko, double liczaGodzin, double stawka, int liczbaKm) : base(imie, nazwisko, liczaGodzin, stawka)
        {
            LiczbaPrzejechanychKm = liczbaKm;
        }

        public override string ToString()
        {
            return base.ToString() + $" liczba km: {LiczbaPrzejechanychKm,-10} premia: {Premia,-10:c2}";
        }
    }
}
