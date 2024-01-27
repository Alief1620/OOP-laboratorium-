using System;
using System.IO;

class Program
{
    static void Main()
    {
        string nazwaPliku = "file.txt";

        string[] pesele = WczytajPeseleZPliku(nazwaPliku);

        int iloscZenskichPeseli = IleZenskichPeseli(pesele);
        Console.WriteLine($"Ilość żeńskich PESELi w pliku: {iloscZenskichPeseli}");
    }

    static string[] WczytajPeseleZPliku(string nazwaPliku)
    {
        try
        {
            if (File.Exists(nazwaPliku))
            {
                return File.ReadAllLines(nazwaPliku);
            }
            else
            {
                Console.WriteLine($"Plik o nazwie {nazwaPliku} nie istnieje.");
                return new string[0];
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wystąpił błąd podczas odczytu pliku: {ex.Message}");
            return new string[0];
        }
    }

    static int IleZenskichPeseli(string[] pesele)
    {
        int iloscZenskich = 0;

        foreach (var pesel in pesele)
        {
            int ostatniaCyfra = int.Parse(pesel[pesel.Length - 1].ToString());
            if (ostatniaCyfra % 2 == 0)
            {
                iloscZenskich++;
            }
        }

        return iloscZenskich;
    }
}
