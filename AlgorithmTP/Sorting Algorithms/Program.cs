using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// СОРТИРОВКА ПУЗЫРЬКОМ
//         в худшем случае    в среднем    в лучшем случае
// время:       О(n^2)           O(n^2)          O(n) 
// память:      O(1)             O(1)            O(1)
// проходит по массиву несколько раз, каждый раз помещая самое большое из неотсортированных значений
// в конец массива
//
// СОРТИРОВКА ВСТАВКАМИ
//         в худшем случае    в среднем    в лучшем случае
// время:       О(n^2)           O(n^2)          O(n) 
// память:      O(1)             O(1)            O(1)
//
// СОРТИРОВКА ВЫБОРОМ
//         в худшем случае    в среднем    в лучшем случае
// время:       О(n^2)           O(n^2)          O(n) 
// память:      O(1)             O(1)            O(1)
//
// СОРТИРОВКА СЛИЯНИЕМ
// метод разделяй и властвуй
// использует метод merge, который производит правильное слияние кусочков
//         в худшем случае    в среднем    в лучшем случае
// время:     О(n*logn)       O(n*logn)       O(n*logn) 
// память:      O(n)             O(n)            O(n) 
// в отличие от линейных алгоритмов будет делить массив и склеивать его 
// независимо от того был тот отсортирован изначально или нет
// поэтому время работы алгоритма в лучшем случае такое же как и в других
// 

namespace Sorting_Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("******** FUN with SORT ********");

            Console.WriteLine();
            Console.WriteLine("******** СОРТИРОВКА ПУЗЫРЬКОМ ********");
            int[] items1 = CreateRndArray(10, 0, 100);
            PrintItems(items1);
            Sort<int>.Bubble(items1);
            PrintItems(items1);

            Console.WriteLine();
            Console.WriteLine("******** СОРТИРОВКА ВСТАВКАМИ ********");
            int[] items3 = CreateRndArray(10, 0, 100);
            PrintItems(items3);
            Sort<int>.Insertion(items3);
            PrintItems(items3);

            Console.WriteLine();
            Console.WriteLine("******** СОРТИРОВКА СЛИЯНИЕМ ********");
            int[] items4 = CreateRndArray(10, 0, 100);
            PrintItems(items4);
            Sort<int>.Merger(items4);
            PrintItems(items4);

            Console.WriteLine();
            Console.WriteLine("******** БЫСТРАЯ СОРТИРОВКА ********");
            int[] items2 = CreateRndArray(10, 0, 100);
            PrintItems(items2);
            Sort<int>.Quick(items2);
            PrintItems(items2);

            Console.ReadLine();
        }

        static void PrintItems<T>(T[] items)
        {           
            Console.Write("Текущий массив: ");
            foreach (T item in items)
            {
                Console.Write("{0} ", item);
            }
            Console.WriteLine();
        }

        static int[] CreateRndArray(int N, int min, int max)
        {
            Random rnd = new Random();
            int[] result = new int[N];
            for (int i = 0; i < N; i++)
            {
                result[i] = rnd.Next(min, max);
            }
            return result;
        }
    }
}
