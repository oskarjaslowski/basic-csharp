namespace Pensja
{
    class Sprzedawca : Pracownik
    {
        public double WartoscObrotu { get; set; }
        public static double sredniObrot = 10000;
		
		public double Premia
        {
            get
            {
                return Zasadnicza * (WartoscObrotu > sredniObrot ? 0.4 : 0.3);
            }
        }
		
        public Sprzedawca(string imie, string nazwisko, double liczaGodzin, double stawka, double wartoscObrotu) : base(imie, nazwisko, liczaGodzin, stawka)
        {
            WartoscObrotu = wartoscObrotu;
        }
        
        public override string ToString()
        {
            return base.ToString() + $" obrót: {WartoscObrotu,-10:c2} premia: {Premia,-10:c2}";
        }
    }  
}
