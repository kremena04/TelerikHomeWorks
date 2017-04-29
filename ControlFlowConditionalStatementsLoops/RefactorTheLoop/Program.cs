using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorTheLoop
{
    class Program
    {
        static void Main(string[] args)
        {
            int expectedValue = 6;
            int[] array = { 1, 2, 3, 4, 5, 6 };

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(array[i]);

                if (i % 10 == 0)
                {
                    if (array[i] == expectedValue)
                    {
                        Console.WriteLine("Value Found");
                    }
                }
            }
        }
    }
}
