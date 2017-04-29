using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareSimpleMaths
{
    class Program
    {
        static void Main(string[] args)
        {
            PerformanceTester.TestPerformance(Operation.Addition);
            PerformanceTester.TestPerformance(Operation.Subtraction);
            PerformanceTester.TestPerformance(Operation.Multiplication);
            PerformanceTester.TestPerformance(Operation.Division);
        }
    }
}
