using System;

namespace KalkulatorBMI
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                double waga = UzyskajDane("Podaj wagę w kilogramach (kg): ");
                double wysokosc = UzyskajDane("Podaj wzrost w centymetrach (cm): ");

                double bmi = ObliczBMI(waga, wysokosc);

                Console.WriteLine($"Twoje BMI wynosi: {bmi:F2}");

                string kategoria = OcenStan(bmi);
                Console.WriteLine($"Kategoria BMI: {kategoria}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Podano niepoprawne dane. Wprowadź liczbę.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wystąpił błąd: {ex.Message}");
            }
            finally
            {
                Console.ReadLine();
            }
        }

        static double UzyskajDane(string dana)
        {
            Console.Write(dana);
            double danaPrzekazana;
            while (!double.TryParse(Console.ReadLine(), out danaPrzekazana))
            {
                Console.WriteLine("Niepoprawna dana. Wprowadź liczbę.");
                Console.Write(dana);
            }
            return danaPrzekazana;
        }

        static double ObliczBMI(double waga, double wysokosc)
        {
            double wysokoscMetry = wysokosc / 100;
            return waga / (wysokoscMetry * wysokoscMetry);
        }

        static string OcenStan(double bmi)
        {
            if (bmi < 18.5)
                return "Niedowaga";
            else if (bmi >= 18.5 && bmi <= 24.9)
                return "Waga normalna";
            else if (bmi >= 25 && bmi <= 29.9)
                return "Nadwaga";
            else
                return "Otyłość";
        }
    }
}