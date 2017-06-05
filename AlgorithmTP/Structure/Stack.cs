using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// для реализации стека воспользуемся встроенным классом связных списков
namespace Structures
{
    class Stack<T>
    {
        private LinkedList<T> _items = new LinkedList<T>();
        public int Count
        {
            get
            {
                return _items.Count;
            }
        }

        public void push(T value)
        {
            _items.AddLast(value);
        }

        public T pop()
        {
            T value = _items.Last.Value;
            _items.RemoveLast();
            return value;
        }

        public T Peek()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }

            return _items.Last.Value;
        }


    }
}
