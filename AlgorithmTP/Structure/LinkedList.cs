using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structures
{
    public class LinkedList<T> : ICollection<T>
    {

        private LinkedListNode<T> _head;
        private LinkedListNode<T> _tail;

        public int Count
        {
            get;
            private set;
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public void Add(T value)
        {
            LinkedListNode<T> node = new LinkedListNode<T>(value);

            if (_head == null)
            {
                _head = node;
                _tail = node;
            }
            else
            {
                _tail.Next = node;
                _tail = node;
            }

            Count++;
        }

        public void Clear()
        {
            _head = null;
            _tail = null;
            Count = 0;
        }

        // проверка на наличие элемента в списке
        public bool Contains(T item)
        {
            LinkedListNode<T> current = _head;
            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }


        public void CopyTo(T[] array, int arrayIndex)
        {
            LinkedListNode<T> current = _head;
            while (current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }

        // удаление конкретного элемента
        public bool Remove(T item)
        {
            LinkedListNode<T> previous = null;
            LinkedListNode<T> current = _head;

            // 1: Пустой список: ничего не делать.
            // 2: Один элемент: установить Previous = null.
            // 3: Несколько элементов:
            //    a: Удаляемый элемент первый.
            //    b: Удаляемый элемент в середине или конце.

            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    // Узел в середине или в конце.
                    if (previous != null)
                    {
                        // Случай 3b.

                        // До:    Head -&gt; 3 -&gt; 5 -&gt; null
                        // После: Head -&gt; 3 ------&gt; null
                        previous.Next = current.Next;

                        // Если в конце, то меняем _tail.
                        if (current.Next == null)
                        {
                            _tail = previous;
                        }
                    }
                    else
                    {
                        // Случай 2 или 3a.

                        // До:    Head -&gt; 3 -&gt; 5
                        // После: Head ------&gt; 5

                        // Head -&gt; 3 -&gt; null
                        // Head ------&gt; null
                        _head = _head.Next;

                        // Список теперь пустой?
                        if (_head == null)
                        {
                            _tail = null;
                        }
                    }

                    Count--;

                    return true;
                }

                previous = current;
                current = current.Next;
            }

            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            LinkedListNode<T> current = _head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        public void PrintList()
        {
            LinkedListNode<T> node = _head;
            Console.Write("Текущий список: ");
            while (node != null)
            {
                Console.Write("{0} -> ", node.Value);
                node = node.Next;
            }
            Console.Write("null");
            Console.WriteLine();
        }
    }

    //**************************************************************************************************  УЗЕЛ  **********
    // класс узла
    public class LinkedListNode<T>
    {
        ///
        /// Конструктор нового узла со значением Value.
        ///
        public LinkedListNode(T value)
        {
            Value = value;
        }

        ///
        /// Поле Value.
        ///
        public T Value { get; internal set; }

        ///
        /// Ссылка на следующий узел списка (если узел последний, то null).
        ///
        public LinkedListNode<T> Next { get; internal set; }
    }

}

