using System;
using System.Collections.Generic;

namespace Laboratorium_4__Zadanie_2
{
    public class Osoba
    {
        public string Imie { get; protected set; }
        public string Nazwisko { get; protected set; }
        public string Pesel { get; protected set; }

        public void SetFirstName(string imie)
        {
            Imie = imie;
        }

        public void SetLastName(string nazwisko)
        {
            Nazwisko = nazwisko;
        }

        public void SetPesel(string pesel)
        {
            Pesel = pesel;
        }

        public int GetAge()
        {
            return 0;
        }

        public char GetGender()
        {
            return ' ';
        }

        public virtual string GetEducationInfo()
        {
            return "Brak informacji o edukacji";
        }

        public string GetFullName()
        {
            return $"{Imie} {Nazwisko}";
        }

        public virtual bool CanGoAloneToHome()
        {
            return false;
        }
    }

    public class Uczen : Osoba
    {
        public string Szkola { get; private set; }
        public bool MozeSamWracacDoDomu { get; private set; }

        public void SetSchool(string szkola)
        {
            Szkola = szkola;
        }

        public void ChangeSchool(string nowaSzkola)
        {
            Szkola = nowaSzkola;
        }

        public void SetCanGoHomeAlone(bool canGoAlone)
        {
            MozeSamWracacDoDomu = canGoAlone;
        }

        public override string GetEducationInfo()
        {
            return $"Uczeń uczęszcza do szkoły {Szkola}";
        }

        public override bool CanGoAloneToHome()
        {
            if (GetAge() < 12 && !MozeSamWracacDoDomu)
            {
                return false;
            }
            return true;
        }
    }

    public class Nauczyciel : Osoba
    {
        public string TytulNaukowy { get; set; }
        public List<Uczen> PodwladniUczniowie { get; private set; }

        public Nauczyciel()
        {
            PodwladniUczniowie = new List<Uczen>();
        }

        public void AddStudent(Uczen uczen)
        {
            PodwladniUczniowie.Add(uczen);
        }

        public void WhichStudentCanGoHomeAlone(DateTime dateToCheck)
        {
            Console.WriteLine($"Uczniowie, którzy mogą iść sami do domu w dniu {dateToCheck.ToShortDateString()}:");
            foreach (var uczen in PodwladniUczniowie)
            {
                if (uczen.CanGoAloneToHome())
                {
                    Console.WriteLine($"{uczen.GetFullName()}");
                }
            }
        }
    }



    class Program
    {
        static void Main()
        {
            Uczen uczen1 = new Uczen();
            uczen1.SetFirstName("Kolya");
            uczen1.SetLastName("Kob");
            uczen1.SetPesel("47856996254");
            uczen1.SetSchool("Szkoła Podstawowa Nr 12");
            uczen1.SetCanGoHomeAlone(true);

            Uczen uczen2 = new Uczen();
            uczen2.SetFirstName("Anna");
            uczen2.SetLastName("Buka");
            uczen2.SetPesel("25413698754");
            uczen2.SetSchool("Szkoła Podstawowa Nr 54");
            uczen2.SetCanGoHomeAlone(false);

            Nauczyciel nauczyciel = new Nauczyciel();
            nauczyciel.SetFirstName("tanya");
            nauczyciel.SetLastName("Polyva");
            nauczyciel.SetPesel("14725836923");
            nauczyciel.TytulNaukowy = "mgr";

            nauczyciel.AddStudent(uczen1);
            nauczyciel.AddStudent(uczen2);

            nauczyciel.WhichStudentCanGoHomeAlone(DateTime.Now);
        }
    }

}
