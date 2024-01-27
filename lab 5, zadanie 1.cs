using System;
using System.IO;

namespace Laboratorium__5_
{
    class Program
    {
        static void Main()
        {
            Console.Write("Podaj swój numer albumu: ");
            string numerAlbumu = Console.ReadLine();

            ZapiszDoPliku("numer_albumu.txt", numerAlbumu);

            Console.WriteLine("Numer albumu został zapisany do pliku.");
        }

        static void ZapiszDoPliku(string nazwaPliku, string zawartosc)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(nazwaPliku))
                {
                    sw.WriteLine(zawartosc);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wystąpił błąd podczas zapisu do pliku: {ex.Message}");
            }  
        }
    }
}
