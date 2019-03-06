using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*  1.  Попробовать оптимизировать пузырьковую сортировку.Сравнить количество операций сравнения оптимизированной и неоптимизированной программы.
        Написать функции сортировки, которые возвращают количество операций.
    2.  *Реализовать шейкерную сортировку.
    3.  Реализовать бинарный алгоритм поиска в виде функции, которой передаётся отсортированный массив. 
        Функция возвращает индекс найденного элемента или –1, если элемент не найден.
    4.  *Подсчитать количество операций для каждой из сортировок и сравнить его с асимптотической сложностью алгоритма.

    Александр Кушмилов
*/

namespace GB_Algorithms_3
{
    class Program
    {
        /// <summary>
        /// Метод пузырьковой сортировки массива со счетчиком операций (перемещение маркера + перестановка эл. массива)
        /// </summary>
        /// <param name="inArray">Сортируемый массив</param>
        /// <returns></returns>
        static int BubbleSort(ref int[] inArray)
        {
            int buf = 0;
            int counter = 0;
            for (int i = 0; i < inArray.Length; i++)
            {
                for (int j = 0; j < inArray.Length - 1; j++)
                {
                    counter++;
                    if (inArray[j] > inArray[j + 1])
                    {
                        counter++;
                        buf = inArray[j];
                        inArray[j] = inArray[j + 1];
                        inArray[j + 1] = buf;
                    }
                }
            }
            return counter;
        }

        /// <summary>
        /// Метод оптимизированной(распознает отсортированный массив) пузырьковой сортировки массива со счетчиком операций (перемещение маркера + перестановка эл. массива)
        /// </summary>
        /// <param name="inArray"></param>
        /// <returns></returns>
        static int BubbleSortOptimized(ref int[] inArray)
        {
            int buf = 0;
            int counter = 0;
            bool done = false;
            for (int i = 0; i < inArray.Length; i++)
            {
                if (done) break;
                done = true;
                for (int j = 0; j < inArray.Length - 1; j++)
                {
                    counter++;
                    if (inArray[j] > inArray[j + 1])
                    {
                        counter++;
                        buf = inArray[j];
                        inArray[j] = inArray[j + 1];
                        inArray[j + 1] = buf;
                        done = false;
                    }
                }
            }
            return counter;
        }

        /// <summary>
        /// Метод оптимизированной пузырьковой сортировки(распознает отсортированный массив, не проверяет уже отсортированные эл.) массива со счетчиком операций (перемещение маркера + перестановка эл. массива)
        /// </summary>
        /// <param name="inArray"></param>
        /// <returns></returns>
        static int BubbleSortOptimized2(ref int[] inArray)
        {
            int buf = 0;
            int counter = 0;
            bool done = false;
            int x = inArray.Length-1;
            for (int i = 0; i < inArray.Length; i++)
            {
                if (done) break;
                done = true;
                for (int j = 0; j < x; j++)
                {
                    counter++;
                    if (inArray[j] > inArray[j + 1])
                    {
                        counter++;
                        buf = inArray[j];
                        inArray[j] = inArray[j + 1];
                        inArray[j + 1] = buf;
                        done = false;
                    }
                }
                x--;
            }
            return counter;
        }

        /// <summary>
        /// Метод шейкерной сортировки
        /// </summary>
        /// <param name="inArray"></param>
        /// <returns></returns>
        static int ShakerSort(ref int[] inArray)
        {
            int buf = 0;
            int counter = 0;
            int rightMarker = inArray.Length - 1;
            int leftMarker = 0;
            while (leftMarker <= rightMarker)
            {
                for (int j = leftMarker; j < rightMarker; j++)
                {
                    counter++;
                    if (inArray[j] > inArray[j + 1])
                    {
                        counter++;
                        buf = inArray[j];
                        inArray[j] = inArray[j + 1];
                        inArray[j + 1] = buf;
                    }
                }
                for (int k = rightMarker; k > leftMarker; k--)
                {
                    counter++;
                    if (inArray[k] < inArray[k - 1])
                    {
                        counter++;
                        buf = inArray[k];
                        inArray[k] = inArray[k - 1];
                        inArray[k - 1] = buf;
                    }
                }
                leftMarker++;
                rightMarker--;
            }
            return counter;
        }


        /// <summary>
        /// Выводит массив в консоль
        /// </summary>
        /// <param name="arr"></param>
        static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i], 3} ");
            }
        }

        static void Main(string[] args)
        {
            Random rnd = new Random();
            int lenght = 20;
            int[] referenceArray = new int[lenght];
            for (int i = 0; i < referenceArray.Length; i++)
            {
                referenceArray[i] = rnd.Next(0, 60);
            }
            Console.Write($"{"Сортируемый массив: ", -35}");
            PrintArray(referenceArray);
            Console.WriteLine();

            int[] testArray = new int[lenght];
            Array.Copy(referenceArray, testArray, lenght);
            int numberOfOperations = BubbleSort(ref testArray);
            Console.Write($"{"Пузырьковая сортировка: ",-35}");
            PrintArray(testArray);
            Console.WriteLine();
            Console.WriteLine($"Кол-во операций: {numberOfOperations}");

            Array.Copy(referenceArray, testArray, lenght);
            numberOfOperations = BubbleSortOptimized(ref testArray);
            Console.Write($"{"Оптим. пузырьковая сортировка: ",-35}");
            PrintArray(testArray);
            Console.WriteLine();
            Console.WriteLine($"Кол-во операций: {numberOfOperations}");

            Array.Copy(referenceArray, testArray, lenght);
            numberOfOperations = BubbleSortOptimized2(ref testArray);
            Console.Write($"{"Оптим. пузырьковая сортировка v2: ",-35}");
            PrintArray(testArray);
            Console.WriteLine();
            Console.WriteLine($"Кол-во операций: {numberOfOperations}");

            Array.Copy(referenceArray, testArray, lenght);
            numberOfOperations = ShakerSort(ref testArray);
            Console.Write($"{"Шейкерная сортировка: ",-35}");
            PrintArray(testArray);
            Console.WriteLine();
            Console.WriteLine($"Кол-во операций: {numberOfOperations}");

            Console.ReadKey();
        }
    }
}
