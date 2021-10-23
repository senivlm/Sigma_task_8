using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Sigma_task4_A;

namespace Sigma_task_8
{
    class Program
    {
        static void Main(string[] args)
        {
            var myStorage = new Storage();
            myStorage.FillFromConsole();

            /* Sorting by price: */
            var sortedStorageByPrice = new Storage(Sorter.BubbleSort(myStorage, (first, second) =>
               first.Price.CompareTo(second.Price)));

            /* Sorting by weight IN DESCENDING ORDER: */
            var sortedStorageByWeightDec = new Storage(Sorter.BubbleSort(myStorage, (first, second) =>
                second.Weight.CompareTo(first.Weight)));

            string paragraphLine = new string('*', 100) + "\n";

            Console.WriteLine(paragraphLine + "My storage originaly : ");
            Console.WriteLine(myStorage.ContentInfo());

            Console.WriteLine(paragraphLine + "My storage sorted by price: ");
            Console.WriteLine(sortedStorageByPrice.ContentInfo());

            Console.WriteLine(paragraphLine + "My storage sorted by weight descending : ");
            Console.WriteLine(sortedStorageByWeightDec.ContentInfo());
            Console.Read();
        }
    }
}
