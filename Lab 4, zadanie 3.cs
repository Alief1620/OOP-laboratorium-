using System;
using System.Collections.Generic;

namespace Laboratorium_4__zadanie_3
{
    using System;
    using System.Collections.Generic;

    public interface IOsoba
    {
        string Imie { get; set; }
        string Nazwisko { get; set; }

        string ZwrocPelnaNazwe();
    }

    public interface IStudent : IOsoba
    {
        string Uczelnia { get; set; }
        string Kierunek { get; set; }
        int Rok { get; set; }
        int Semestr { get; set; }

        string WypiszPelnaNazweIUczelnie();
    }

    public class Student : IStudent
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Uczelnia { get; set; }
        public string Kierunek { get; set; }
        public int Rok { get; set; }
        public int Semestr { get; set; }

        public string ZwrocPelnaNazwe()
        {
            return $"{Imie} {Nazwisko}";
        }

        public virtual string WypiszPelnaNazweIUczelnie()
        {
            return $"{ZwrocPelnaNazwe()} – {Semestr}SEM-{Rok} {Kierunek} {Uczelnia}";
        }
    }

    public class StudentWSIiZ : Student
    {
        // Dodatkowe właściwości dla StudentWSIiZ, jeśli potrzebne

        public override string WypiszPelnaNazweIUczelnie()
        {
            // Przesłonięta metoda dla StudentWSIiZ
            return $"{ZwrocPelnaNazwe()} – {Rok} rok {Kierunek} na WSIiZ";
        }
    }

    class Program
    {
        static void Main()
        {
            List<IStudent> listaStudentow = new List<IStudent>();

            IStudent student1 = new Student
            {
                Imie = "Jan",
                Nazwisko = "Kowalski",
                Uczelnia = "WSIiZ",
                Kierunek = "Informatyka",
                Rok = 2018,
                Semestr = 4
            };

            IStudent studentWSIiZ1 = new StudentWSIiZ
            {
                Imie = "Katya",
                Nazwisko = "Adamovych",
                Uczelnia = "WSIiZ",
                Kierunek = "Psychologia",
                Rok = 2020,
                Semestr = 2
            };

            listaStudentow.Add(student1);
            listaStudentow.Add(studentWSIiZ1);

            Console.WriteLine("Lista studentów:");
            foreach (var student in listaStudentow)
            {
                Console.WriteLine(student.WypiszPelnaNazweIUczelnie());
            }
        }
    }
}
