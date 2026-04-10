class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();

        int[] tablica = new int[100];

        for (int i = 0; i < tablica.Length; i++)
        {
            tablica[i] = random.Next(1, 1000);
        }

        Console.WriteLine("Zawartość tablicy:\n");

        for (int i = 0; i < tablica.Length; i++)
        {
            Console.Write(tablica[i] + "\t");

            if ((i + 1) % 10 == 0)
            {
                Console.Write("\n\n");
            }
        }

        Console.ReadLine();
    }
}