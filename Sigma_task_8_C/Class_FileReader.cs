using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Sigma_task_8_C
{
    public class FileReader
    {
        public readonly string PathToFile;
        public FileReader(string path)
        {
            if (path == null)
                throw new NullReferenceException("Path string can't be null referance.");
            if (!File.Exists(path))
                throw new FileNotFoundException("File has not been found.");
            PathToFile = path;
        }
        public  IEnumerable<string> ReadLines()
        {
            if (!File.Exists(PathToFile))
                throw new FileNotFoundException("Error! File hasn't existed longer.");
                
            var result = new List<string>();
            using (StreamReader reader = new StreamReader(PathToFile))
            {
                while (!reader.EndOfStream)
                    result.Add(reader.ReadLine());
            }
            return result;
        }
        public IEnumerable<string> ReadSenteces()
        {
            if (!File.Exists(PathToFile))
                throw new FileNotFoundException("Error! File hasn't existed longer.");

            MatchCollection sentenceMatches = default; 
            using (StreamReader reader = new StreamReader(PathToFile))
            {
                sentenceMatches = Regex.Matches(reader.ReadToEnd(), @"(?:\w|\s|\n|[(),\:\-])+\.");
               
            }

            return  from match in sentenceMatches
                            select match.Value;
        }
        public override string ToString()
        {
            return PathToFile;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                throw new ArgumentNullException("Object was null reference.");

            if (this.GetType() == obj.GetType())
                return false;

            return PathToFile.Equals((obj as FileReader).PathToFile);
        }
    }
}
