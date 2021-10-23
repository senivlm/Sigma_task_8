using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma_task_8_C
{
    public static class TextEditor
    {
        /* Метод для утворення речень зі стрічок */
        public static IEnumerable<string> LinesToSentences(IEnumerable<string> inputLines)
        {
            string tempStr = string.Empty;
            var result = new List<string>();

            var lines = inputLines.ToArray();

            for (int i = 0; i < lines.Length; i++)
            {
                var parts = lines[i].Split('.');
                if(parts.Length == 1)
                {
                    tempStr += lines[i];
                }
                else
                {
                    tempStr += parts[0];
                    result.Add(tempStr);
                    for (int j = 1; j < parts.Length - 1; j++)
                        result.Add(parts[j]);
                    tempStr = parts[parts.Length - 1];
                }
            }
            return result;
        }
    }
}
