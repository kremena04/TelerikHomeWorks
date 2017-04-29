using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareAdvancedMaths
{
    class Program
    {
        static void Main(string[] args)
        {
            PerformanceTester.TestPerformance(Function.Sqrt);
            PerformanceTester.TestPerformance(Function.Log);
            PerformanceTester.TestPerformance(Function.Sin);
        }
    }
}
