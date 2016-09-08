using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Boring_task_Library_VK
{
    [XmlRoot]
    public class Library
    {
        public List<Person> Persons { get; set; }
        public List<Book> Books { get; set; }

        // Average amount of books that males and females separately have.
        public void AverageAmountOfBooks()
        {
            double averageMale = Persons
                .Where(person => person.Sex == SexEnum.Male)
                .Select(person => person.Books.Count)
                .Average();

            double averageFemale = Persons
                .Where(person => person.Sex == SexEnum.Female)
                .Select(person => person.Books.Count)
                .Average();

            Console.WriteLine("Average amount of books that males have {0}", averageMale);
            Console.WriteLine("Average amount of books that females have {0}", averageFemale);
        }

        // Average, min, max amount of books that have males in some age range 25-50
        public void AverageMinMaxBooksMalesHave()
        {
            IEnumerable<Person> malesInAgeRange = Persons
                .Where(person => person.Sex == SexEnum.Male)
                .Where(person => person.Age >= 25 && person.Age <= 50);
                
            double averageAmountOfBooks = Persons
                .Select(person => person.Books.Count).Average();

            int minAmountOfBooks = Persons
                .Select(person => person.Books.Count).Min();

            int maxAmountOfBooks = Persons
                .Select(person => person.Books.Count).Max();

            Console.WriteLine("Average amount of books that have males in some age range 25-50: {0}", averageAmountOfBooks);
            Console.WriteLine("Min amount of books that have males in some age range 25-50: {0}", minAmountOfBooks);
            Console.WriteLine("Max amount of books that have males in some age range 25-50: {0}", maxAmountOfBooks);
        }

        // Found most and least popular books.
        public void MostLeastPopularBook()
        {
            // go through books
            var amountOfEachBook = Books.Select
                (book => new
                {
                    Book = book,
                    Usage = Persons.Count(person => person.Books.Contains(book))
                }
                ).ToList();

            // Max and Min used books (count)
            int maxUsage = amountOfEachBook.Max(maxBookUsage => maxBookUsage.Usage);
            int minUsage = amountOfEachBook.Min(minBookUsage => minBookUsage.Usage);

            // take Max and Min used books (Title)
            var maxUsedBook = amountOfEachBook
                .Where(_maxUsedBook => _maxUsedBook.Usage == maxUsage)
                .Select(bookTitle => bookTitle.Book.Title)
                .ToArray();
            var minUsedBook = amountOfEachBook
                .Where(_minUsedBook => _minUsedBook.Usage == minUsage)
                .Select(bookTitle => bookTitle.Book.Title)
                .ToArray();
            Console.WriteLine("Maximum Used Book: {0} (amount of books: {1})", String.Join(", ", maxUsedBook), maxUsage);
            Console.WriteLine("Minimum Used Book: {0} (amount of books: {1})", String.Join(", ", minUsedBook), minUsage);
        }
    }
}