using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sigma_task_8_C
{
    class Program
    {
        static void Main(string[] args)
        {
            FileReader reader;

            Console.Write("Enter path to file :");
            try
            {
                reader = new FileReader(Console.ReadLine());
            }
            catch(Exception exeption)
            {
                Console.WriteLine("Error : " + exeption.Message);
                Console.Read();
                return;
            }

            var linesFromFile = reader.ReadLines();

            Console.WriteLine("Lines from file : ");
            foreach (var line in linesFromFile)
                Console.WriteLine(line);

            Console.WriteLine("\nLine with deepest attachment : " 
                + TextAnalyzer.FindOutМахAttachments(linesFromFile));

            var sortedLines = Enumerable.OrderBy(TextEditor.LinesToSentences(linesFromFile), (str) => str.Length);
            Console.WriteLine("Sorted lines from file : ");
            foreach (var line in sortedLines)
                Console.WriteLine(line + '.');

            Console.ReadLine();        
        }
    }
}
