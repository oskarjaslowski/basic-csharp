using System;
using System.Collections.Generic;

namespace Pensja
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Pracownik> listaPracownikow = new List<Pracownik>();

            Pracownik pDomyslny = new Pracownik();
            listaPracownikow.Add(pDomyslny);

            Pracownik pInicjujacy = new Pracownik("Małgorzata", "Kmak", 50, 40);
            listaPracownikow.Add(pInicjujacy);

            Pracownik pInicjujacy2 = new Pracownik("Jan", "Kowalski", 30, 60);
            listaPracownikow.Add(pInicjujacy2);

            Pracownik pKopiujacy = new Pracownik(pInicjujacy);
            listaPracownikow.Add(pKopiujacy);

            //Wyświtelanie listy pracowników
            Console.Clear();
            foreach (Pracownik p in listaPracownikow)
            {
                Console.WriteLine(p.ToString());
            }
            Console.ReadLine();
        }
    }
}
