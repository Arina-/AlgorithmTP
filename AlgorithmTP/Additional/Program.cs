using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Additional
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            foreach (string token in input.Split(' '))
            {
                Console.WriteLine(token);
            }
            

            Console.ReadLine();
        }
    }
}
