using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure
{
    public class QueueR<T>
    {
        private LinkedList<T> _items = new LinkedList<T>();
        public int Count
        {
            get
            {
                return _items.Count;
            }
        }

        public T Dequeue()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }
            T value = _items.Last.Value;
            _items.RemoveLast();
            return value;
        }

        public void Enqueue(T value)
        {
            _items.AddFirst(value);
        }

        public T Peek()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }
            return _items.Last.Value;
        }
    }
}
