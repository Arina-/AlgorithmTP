using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algorithms
{
    class Sort<T> where T : IComparable
    {
        static public void Bubble(T[] items)
        {
            bool ready = true;

            do
            {
                ready = true;
                for (int i = 0; i < items.Length - 1; i++)
                {
                    if (items[i].CompareTo(items[i + 1]) > 0)
                    {
                        Swap(items, i, i + 1);
                        ready = false;
                    }
                }
            } while (ready == false);
        }

        static public void Insertion(T[] items)
        {
            int sortedRangeEndIndex = 1;

            while (sortedRangeEndIndex < items.Length)
            {
                if (items[sortedRangeEndIndex].CompareTo(items[sortedRangeEndIndex - 1]) < 0)
                {
                    int insertIndex = FindInsertionIndex(items, items[sortedRangeEndIndex]);
                    Insert(items, insertIndex, sortedRangeEndIndex);
                }

                sortedRangeEndIndex++;
            }
        }

        static private int FindInsertionIndex(T[] items, T valueToInsert)
        {
            for (int i = 0; i < items.Length; i++) {
                if (items[i].CompareTo(valueToInsert) > 0)
                {
                    return i;
                }
            }

            throw new InvalidOperationException("The insertion index was not found");
        }

        static private void Insert(T[] itemArray, int indexInsertingAt, int indexInsertingFrom)
        {
            // Сохраняем элемент на место которого будет вставка
            T temp = itemArray[indexInsertingAt];

            // Вставляем элемент
            itemArray[indexInsertingAt] = itemArray[indexInsertingFrom];

            // Сдвигаем элементы
            for (int i = indexInsertingFrom; i > indexInsertingAt; i--)
            {
                itemArray[i] = itemArray[i - 1];
            }

            // Возвращаем вырезанный элемент
            itemArray[indexInsertingAt + 1] = temp;
        }
            static public void Quick(T[] items)
        {
        }

        static private void Swap(T[] items, int left, int right)
        {
            if (left != right)
            {
                T temp = items[left];
                items[left] = items[right];
                items[right] = temp;
            }
        }

        static public void Merger(T[] items)
        {
            if (items.Length <= 1)
            {
                return;
            }

            int leftSize = items.Length / 2;
            int rightSize = items.Length - leftSize;

            T[] left = new T[leftSize];
            T[] right = new T[rightSize];

            Array.Copy(items, 0, left, 0, leftSize);
            Array.Copy(items, leftSize, right, 0, rightSize);

            Merger(left);
            Merger(right);
            Merge(items, left, right);
        }

        /*private void Merge(T[] items, T[] left, T[] right)
        {
            int leftIndex = 0; 
            int rightIndex = 0; 
            int targetIndex = 0; 
            
            int remaining = left.Length + right.Length; 
            while (remaining > 0)
            {
                if (leftIndex >= left.Length)
                {
                    items[targetIndex] = right[rightIndex++];
                }
                else if (rightIndex >= right.Length)
                {
                    items[targetIndex] = left[leftIndex++];
                }
                else if (left[leftIndex].CompareTo(right[rightIndex]) < 0)
                {
                    items[targetIndex] = left[leftIndex++];
                }
                else
                {
                    items[targetIndex] = right[rightIndex++];
                }

                targetIndex++;
                remaining--;
            }
        }*/

        static private void Merge(T[] items, T[] left, T[] right)
        {
            int leftIndex = 0;
            int rightIndex = 0;
            int itemsIndex = 0;
            while (itemsIndex < items.Length)
            {
                if (leftIndex >= left.Length)
                {
                    items[itemsIndex] = right[rightIndex];
                    itemsIndex++;
                    rightIndex++;
                }
                else if (rightIndex >= right.Length)
                {
                    items[itemsIndex] = left[leftIndex];
                    itemsIndex++;
                    leftIndex++;
                }
                else if (left[leftIndex].CompareTo(right[rightIndex]) < 0)
                {
                    items[itemsIndex] = left[leftIndex];
                    itemsIndex++;
                    leftIndex++; 
                }
                else
                {
                    items[itemsIndex] = right[rightIndex];
                    itemsIndex++;
                    rightIndex++;
                }
            }
        }
    }
}
