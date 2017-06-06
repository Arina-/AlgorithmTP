using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// LinkedList<T>
// связный список реализует интерфейс ICollection<T>
// System.Collections.Generic.ICollection

// ArrayList<T>
// динамический массив реализует интерфейс IList<T>
// System.Collections.Generic.IList

// Stack
// стек: последний вошел, первый вышел
// имеем доступ только к последенему элементу коллекции
// в отличие от списка не можем получить доступ к произвольному элементу
// в реализации для хранения элементов используется LinkedList<T>

// Queue
// очередь: последний вошел, последний вышел
// не имеет доступа к произвольному элементу
// используется для реализации буфера, в который нужно сложить эелементы и забрать их в порядке поступления 
// в System реализована на основе массива

// Deque
// дек: двусторонняя очередь
// такое поведение полезно, например, в планировании поведения потоков

// двустороннюю очередь можно реализовать на основе массива    
// данные в таком случается храняться окально (в одном месте)
// это увеличивает производительность
// тогда имеет смысл реализовать стек с помощью двусторонней очереди


// ЗАМЕЧАНИЯ
// для разбияния строки на подмассивы   input.Split(new char[] { ' ' })
// foreach (string token in input.Split(new char[] { ' ' })

namespace Structures
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedListR<int> myLL = new LinkedListR<int>();
            Console.WriteLine("**** Fun with LinkedList ****");
            Console.WriteLine("**** Реализованная версия ****");
            myLL.PrintList();

            myLL.Add(1);
            myLL.Add(2);
            myLL.Add(3);
            myLL.PrintList();

            myLL.Remove(2);
            myLL.PrintList();

            Console.WriteLine("**** Встроенная версия ****");
            LinkedList<int> sysLL = new LinkedList<int>();
            sysLL.AddLast(1);
            sysLL.AddLast(2);
            sysLL.AddLast(3);
            Console.Write("Текущий список: ");

            LinkedListNode<int> node = new LinkedListNode<int>(0);
            node = sysLL.First;
            while (node != null)
            {
                Console.Write("{0} -> ", node.Value);
                node = node.Next;
            }

            Console.WriteLine();
            Console.WriteLine("**** Fun with Stack ****");
            Console.WriteLine("**** Польский калькулятор ****");
            Console.WriteLine("Для выхода введите quit");
            Console.WriteLine("Введите символы для счета: ");
            RpnLoop();
            Console.ReadLine();
        }

 //*****************************************************************************************  ПОЛЬСКИЙ КАЛЬКУЛТОР  *********
        static void RpnLoop()
        {
            while (true)
            {
                Console.Write("&gt; ");
                string input = Console.ReadLine();
                if (input.Trim().ToLower() == "quit")
                {
                    break;
                }

                // Стек еще не обработанных значений.
                Stack<int> values = new Stack<int>();

                foreach (string token in input.Split(new char[] { ' ' }))
                {
                    // Если значение - целое число...
                    int value;
                    if (int.TryParse(token, out value))
                    {
                        // ... положить его на стек.
                        values.Push(value);
                    }
                    else
                    {
                        // в противном случае выполнить операцию...
                        int rhs = values.Pop();
                        int lhs = values.Pop();

                        // ... и положить результат обратно.
                        switch (token)
                        {
                            case "+":
                                values.Push(lhs + rhs);
                                break;
                            case "-":
                                values.Push(lhs - rhs);
                                break;
                            case "*":
                                values.Push(lhs * rhs);
                                break;
                            case "/":
                                values.Push(lhs / rhs);
                                break;
                            case "%":
                                values.Push(lhs % rhs);
                                break;
                            default:
                                // Если операция не +, -, * или /
                                throw new ArgumentException(
                                    string.Format("Unrecognized token: {0}", token));
                        }
                    }
                }

                // Последний элемент на стеке и есть результат.
                Console.WriteLine(values.Pop());
            }
        }
    }
}
