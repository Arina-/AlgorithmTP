using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// LinkedList<T>
// связный список реализует интерфейс ICollection<T>
// System.Collections.Generic.ICollction

// ArrayList<T>
// динамический массив реализует интерфейс IList<T>
// System.Collections.Generic.IList

// Stack
// стек: последний вошел, первый вышел
// имеем доступ только к последенему элементу коллекции
// в отличие от списка не можем получить доступ к произвольному элементу
// в реализации для хранения элементов используется LinkedList<T>
namespace Structures
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> myLL = new LinkedList<int>();
            Console.WriteLine("**** Fun with LinkedList ****");

            myLL.PrintList();

            myLL.Add(1);
            myLL.Add(2);
            myLL.Add(3);
            myLL.PrintList();

            myLL.Remove(2);
            myLL.PrintList();
            Console.ReadLine();
        }
    }
}
