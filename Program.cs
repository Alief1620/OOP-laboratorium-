using System;
using System.Collections.Generic;

namespace Laboratorium_3
{
    class Person
    {
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private int Age { get; set; }

        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public virtual void View()
        {
            Console.WriteLine($"Person: {FirstName} {LastName}, Age: {Age}");
        }

        public string GetFirstName() => FirstName;
        public string GetLastName() => LastName;
        public int GetAge() => Age;
    }

    class Book
    {
        protected string Title { get; set; }
        protected Person Author { get; set; }
        protected DateTime ReleaseDate { get; set; }

        public Book(string title, Person author, DateTime releaseDate)
        {
            Title = title;
            Author = author;
            ReleaseDate = releaseDate;
        }

        public string GetTitle() => Title;

        public virtual void View()
        {
            Console.WriteLine($"Book: {Title}, Author: {Author.GetFirstName()} {Author.GetLastName()}, Release Date: {ReleaseDate.ToShortDateString()}");
        }
    }

    class AdventureBook : Book
    {
        public string Setting { get; set; }

        public AdventureBook(string title, Person author, DateTime releaseDate, string setting)
            : base(title, author, releaseDate)
        {
            Setting = setting;
        }

        public override void View()
        {
            base.View();
            Console.WriteLine($"Setting: {Setting}");
        }
    }

    class DocumentaryBook : Book
    {
        public string Topic { get; set; }

        public DocumentaryBook(string title, Person author, DateTime releaseDate, string topic)
            : base(title, author, releaseDate)
        {
            Topic = topic;
        }

        public override void View()
        {
            base.View();
            Console.WriteLine($"Topic: {Topic}");
        }
    }

    class Reader : Person
    {
        protected List<Book> ReadBooks { get; set; }

        public Reader(string firstName, string lastName, int age) : base(firstName, lastName, age)
        {
            ReadBooks = new List<Book>();
        }

        public void AddBook(Book book)
        {
            ReadBooks.Add(book);
        }

        public override void View()
        {
            Console.WriteLine($"Person: {GetFirstName()} {GetLastName()}, Age: {GetAge()}");
            ViewBooks();
        }

        private void ViewBooks()
        {
            Console.WriteLine($"Books read by {GetFirstName()} {GetLastName()}:");
            foreach (var book in ReadBooks)
            {
                book.View();
            }
            Console.WriteLine();
        }
    }

    class Reviewer : Reader
    {
        private Random random;

        public Reviewer(string firstName, string lastName, int age) : base(firstName, lastName, age)
        {
            random = new Random();
        }

        public void PrintReviews()
        {
            Console.WriteLine($"Reviews by {GetFirstName()} {GetLastName()}:");
            foreach (var book in ReadBooks)
            {
                int rating = random.Next(1, 6); 
                Console.WriteLine($"{book.GetTitle()} - Rating: {rating}");
            }
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main()
        {
            AdventureBook adventureBook = new AdventureBook("Journey to the Center of the Earth", new Person("Jules", "Verne", 40), new DateTime(1864, 11, 25), "Underground");
            DocumentaryBook documentaryBook = new DocumentaryBook("The Elegant Universe", new Person("Brian", "Greene", 55), new DateTime(1999, 10, 15), "Physics");


            Reader reader = new Reader("Alice", "Johnson", 28);

            reader.AddBook(adventureBook);
            reader.AddBook(documentaryBook);

            reader.View();

            Reviewer reviewer = new Reviewer("Sophia", "Jones", 27);

            reviewer.AddBook(adventureBook);
            reviewer.AddBook(documentaryBook);

            reviewer.View();
            reviewer.PrintReviews();
        }
    }
}

        



