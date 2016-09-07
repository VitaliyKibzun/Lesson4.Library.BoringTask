using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boring_task_Library_VK
{
    class Program
    {
        static void Main(string[] args)
        {
            Generator generator = new Generator();
            
            Library serializeLibrary = generator.GenerateLibrary();
            generator.SerializeLibrary(serializeLibrary, "library.xml");

            Library deserializedLibrary = generator.DeSerializeLibrary("library.xml");

            deserializedLibrary.AverageAmountOfBooks();
            deserializedLibrary.AverageMinMaxBooksMalesHave();
            deserializedLibrary.MostLeastPopularBook();

            Console.ReadKey();
        }
    }
}
