using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sigma_task4_A;

namespace Sigma_task_8__B
{
    class Program
    {
        static void Main(string[] args)
        {
            Storage firstStorage = new Storage(),
                    secondStorage = new Storage();

            Console.WriteLine("Press to fill first storage : ");
            Console.Read();
            firstStorage.FillFromConsole();

            Console.WriteLine("Press to fill second storage : ");
            Console.Read();
            secondStorage.FillFromConsole();

            /* 1.Знайдіть всі спільні товари. */
            Console.WriteLine("Joint elements : ");
            var thirdStorage = new Storage(Enumerable.Intersect(firstStorage, secondStorage));
            Console.WriteLine(thirdStorage.ContentInfo());
            // Інший варіант вирішення : 
            //Console.WriteLine(firstStorage.Where(p => secondStorage.Contains(p)));

            /* 2.Знайдіть всі товари, які є в першому складі,  яких немає в 2 складі. */
            Console.WriteLine("Unique element in first storage : ");
            var fourthStorage = new Storage(firstStorage.Except(secondStorage));
            Console.WriteLine(fourthStorage.ContentInfo());

            /* 3.Знайдіть всі різні товари. */
            Console.WriteLine("All of the unique elements : ");
            var fifthStorage = new Storage(firstStorage.Concat(secondStorage).Distinct());
            Console.WriteLine(fifthStorage.ContentInfo());

            Console.Read();
        }
    }
}
