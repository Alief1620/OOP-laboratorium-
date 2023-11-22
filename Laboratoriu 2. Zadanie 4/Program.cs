using System;
using System.Numerics;


namespace Laboratoriu_2._Zadanie_4
{
    class Liczba
    {
        private int[] cyfry;
        public Liczba(string napis)
        {
            UstawLiczbe(napis);
        }
        private void UstawLiczbe(string napis)
        {
            cyfry = new int[napis.Length];
            for (int i = 0; i < napis.Length; i++)
            {
                cyfry[i] = Convert.ToInt32(napis[i].ToString());
            }
        }

        public void Wypisz()
        {
            foreach (var cyfra in cyfry)
            {
                Console.Write(cyfra);
            }
            Console.WriteLine();
        }

        public void Pomnóż(int mnoznik)
        {
            BigInteger wynik = 0;

            for (int i = cyfry.Length - 1; i >= 0; i--)
            {
                wynik += cyfry[i] * mnoznik;
                mnoznik *= 10;
            }

            UstawLiczbe(wynik.ToString());
        }

        public BigInteger Silnia()
        {
            return SilniaRekurencyjnia(cyfry.Length);
        }

        private BigInteger SilniaRekurencyjnia(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            else
            {
                return n * SilniaRekurencyjnia(n - 1);
            }
        }
    }
    class Program
    {
        static void Main()
        {
            Liczba mojaLiczba = new Liczba("6");

            Console.WriteLine("Liczba:");
            mojaLiczba.Wypisz();

            Console.WriteLine("Mnożenie przez 5:");
            mojaLiczba.Pomnóż(5);
            mojaLiczba.Wypisz();

            Console.WriteLine("Silnia:");
            Console.WriteLine(mojaLiczba.Silnia());
        }
    }

}