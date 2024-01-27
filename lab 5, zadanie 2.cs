using System;
using System.IO;

namespace Laboratorium_5__zadanie_2
{
    class Program
    {
        static void Main()
        {
            Console.Write("Podaj nazwę pliku do wczytania: ");
            string nazwaPliku = Console.ReadLine();

            string zawartosc = WczytajPlik(nazwaPliku);

            Console.WriteLine("Zawartość pliku:");
            Console.WriteLine(zawartosc);
        }

        static string WczytajPlik(string nazwaPliku)
        {
            try
            {
                using (StreamReader sr = new StreamReader(nazwaPliku))
                {
                    return sr.ReadToEnd();
                }
            }
            catch (FileNotFoundException)
            {
                return "Plik o podanej nazwie nie istnieje.";
            }
            catch (Exception ex)
            {
                return $"Wystąpił błąd podczas wczytywania pliku: {ex.Message}";
            }
        }
    }
}
