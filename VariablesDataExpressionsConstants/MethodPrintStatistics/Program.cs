using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodPrintStatistics
{
    public class Printer
    {
        public void PrintMaxValueInArray(double[] arr, int arrLenght)
        {
            double maxValueInArray = 0;

            for (int i = 0; i < arrLenght; i++)
            {
                if (arr[i] > maxValueInArray)
                {
                    maxValueInArray = arr[i];
                }
            }

            Console.WriteLine(maxValueInArray);
        }

        public void PrintMinValueInArray(double[] arr, int arrLenght)
        {
            double minvalueInArray = 0;

            for (int i = 0; i < arrLenght; i++)
            {
                if (arr[i] < minvalueInArray)
                {
                    minvalueInArray = arr[i];
                }
            }

            Console.WriteLine(minvalueInArray);
        }

        public void PrintAverageValueInArray(double[] arr, int arrLenght)
        {
            double temp = 0;

            for (int i = 0; i < arrLenght; i++)
            {
                temp += arr[i];
            }

            double averageValueInArray = temp / arrLenght;

            Console.WriteLine(averageValueInArray);
        }
    }   
}
