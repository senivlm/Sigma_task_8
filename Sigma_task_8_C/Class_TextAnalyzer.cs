using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma_task_8_C
{
    public static class TextAnalyzer
    {
        /*  Вважається, що клас може працювати тільки з масивом стрічок, в яких містяться речення.  */
        /*  Зучення містяться між стрічками і кожне розділене крапкою. Зляття стрічок заборонине.   */
        public static string FindOutМахAttachments(IEnumerable<string> inputLines)
        {
            if (inputLines == null || inputLines.Contains(null))
                throw new NullReferenceException("String array mustn't be null refernce.");

            var lines = inputLines.ToArray();

            var indexesOfSentence = (0, 0); // Індекс крапки речення з найбільшим вкладенням. 
            int maxLevel = 0, currentSentenceLevel = 0, currentSentenceMaxLevel = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    switch (lines[i][j])
                    {
                        case '(':
                            ++currentSentenceLevel;
                            if (currentSentenceLevel > currentSentenceMaxLevel)
                                currentSentenceMaxLevel = currentSentenceLevel;
                            break;
                        case ')':
                            --currentSentenceLevel;
                            break;
                        case '.':
                            if (currentSentenceMaxLevel > maxLevel)
                            {
                                maxLevel = currentSentenceMaxLevel;
                                indexesOfSentence = (i, j);
                            }
                            currentSentenceLevel = 0;
                            currentSentenceMaxLevel = 0;
                            break;
                    }
                }
            }
            return SentensByPoint(lines, indexesOfSentence);
        }

        private static string SentensByPoint(string[] inputLines, (int lineIndex, int signIndex) indexes)
        {
            string resultSentense = ".";
            for (int i = indexes.lineIndex; i >= 0; i--)
            {
                int index = inputLines[i].LastIndexOf('.', 
                    i == indexes.lineIndex ? indexes.signIndex - 1 : inputLines[i].Length - 1);
                resultSentense = inputLines[i]
                    Цю конструкцію я б хотіла обговорити
                    [(Math.Max(index + 1, 0))..(i == indexes.lineIndex ? indexes.signIndex : inputLines[i].Length)]
                + resultSentense;

                if (index >= 0)
                    break;
            }
            return resultSentense;
        }
    }
}
