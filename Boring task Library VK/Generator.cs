using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Xml.Serialization;

namespace Boring_task_Library_VK
{
    public class Generator
    {
        private static List<string> firstNamesMales = 
            new List<string>(){"vitaliy"};
        
        private static List<string> firstNamesFemales =
            new List<string>(){"irina"};

        private static List<string> lastNames =
            new List<string>(){"kibzun"};

        private static Random random = new Random();

        // Generates library
        public Library GenerateLibrary()
        {
            Library library = new Library();
            library.Books = GenerateBooks();
            library.Persons = GeneratePersons(library.Books);
            
            return library;
        }

        // Generates Persons
        public List<Person> GeneratePersons(List<Book> listOfBooks )
        {
            List<Person> listOfPersons = new List<Person>();

            foreach (var lastName in lastNames)
            {
                foreach (var Male in firstNamesMales)
                {
                    listOfPersons.Add(CreatePerson(firstNamesMales + lastName, SexEnum.Male, listOfBooks));
                }

                foreach (var Female in firstNamesFemales)
                {
                    listOfPersons.Add(CreatePerson(firstNamesFemales + lastName, SexEnum.Female, listOfBooks));
                }
                return listOfPersons;
            }
            return listOfPersons;
        }

        // Generate Books
        public List<Book> GenerateBooks()
        {
            List<Book> listOfBooks = new List<Book>();
            for (int i = 1; i <= 10; i++)
            {
                listOfBooks.Add(new Book(){Title = "BookTitle" + i});
            }
            return listOfBooks;
        }

        // Creates Person
        private Person CreatePerson(string personName, SexEnum sex, List<Book> listOfBooks )
        {
            Person person = new Person()
            {
                PersonName = personName,
                Age = random.Next(5, 80), 
                Sex = sex, 
                Books = GetRandomBooks(listOfBooks)
            };
            return person;
        }

        // Get Random books
        private List<Book> GetRandomBooks(List<Book> listOfBooks)
        {
            List<Book> randomBooks = new List<Book>();
            List<int> indexOfBooks = new List<int>();

            for (int i = 0; i < listOfBooks.Count; i++)
            {
                indexOfBooks.Add(i);
            }

            int booksQuantity = random.Next(1, indexOfBooks.Count+1);

            for (int i = 1; i <= booksQuantity; i++)
            {
                int bookIndex = random.Next(indexOfBooks.Count);
                int bookIndexFromLibrary = indexOfBooks[bookIndex];
                randomBooks.Add(listOfBooks[bookIndexFromLibrary]);
                indexOfBooks.RemoveAt(bookIndex);
            }
            return randomBooks;
        }

        // Serialize Library to xml.
        public void SerializeLibrary(Library library, string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Library));
            using (TextWriter writer = new StreamWriter(fileName))
            {
                serializer.Serialize(writer, library);
            }
        }

        // Deserialize Library from xml.
        public Library DeSerializeLibrary(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Library));
            using (TextReader reader = new StreamReader(fileName))
            {
                return serializer.Deserialize(reader) as Library;
            }
        }
    }
}