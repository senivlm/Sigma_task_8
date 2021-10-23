using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sigma_task_4;

namespace Sigma_task_8
{

    public static class Sorter
    {
        public static IEnumerable<T> BubbleSort<T>(IEnumerable<T> inputElements, Func<T, T, int> comparer)
        {
            if (inputElements == null)
                throw new NullReferenceException("Incorrect argument. Collection can't be null.");

            var elements = inputElements.ToArray();

            bool arrayChanged = true;
            T tempObject = default;

            for (int i = 0; i < elements.Length - 1; ++i)
            {
                arrayChanged = false;
                for (int j = 0; j < elements.Length - 1; j++)
                {
                    if (comparer(elements[j], elements[j + 1]) > 0)
                    {
                        tempObject = elements[j];
                        elements[j] = elements[j + 1];
                        elements[j + 1] = tempObject;

                        arrayChanged = true;
                    }
                }
                if (!arrayChanged) return elements;
            }
            return elements;
        }


        /*   Перевантаження метода для object   */
        public static IEnumerable<object> BubbleSort(IEnumerable<object> inputElements, Func<object, object, int> comparer)
        {
            if (inputElements == null)
                throw new NullReferenceException("Incorrect argument. Collection can't be null.");

            var elements = inputElements.ToArray();
 
            bool arrayChanged = true;
            object tempObject = default;

            for (int i = 0; i < elements.Length - 1; ++i)
            {
                arrayChanged = false;
                for (int j = 0; j < elements.Length - 1; j++)
                {
                    if (comparer(elements[j], elements[j + 1]) > 0)
                    {
                        tempObject = elements[j];
                        elements[j] = elements[j + 1];
                        elements[j + 1] = tempObject;

                        arrayChanged = true;
                    }
                }
                if (!arrayChanged) return elements;
            }
            return elements;
        }
    }
}