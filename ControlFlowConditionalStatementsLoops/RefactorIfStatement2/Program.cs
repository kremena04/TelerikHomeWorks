using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorIfStatement2
{
    public class Constants
    {
        public const int MIN_X = 10;
        public const int MAX_X = 100;

        public const int MIN_Y = 10;
        public const int MAX_Y = 100;
    }
    
    class Program
    {
        public static bool VisitCell()
        {
            bool shouldNotVisitCell = true;
            return shouldNotVisitCell;
        }

        static void Main(string[] args)
        {
           

           int x = int.Parse(Console.ReadLine());
           int y = int.Parse(Console.ReadLine());
           bool shouldNotVisitCell = false;

            if (x >= Constants.MIN_X && (x <= Constants.MAX_X && 
                ((Constants.MAX_Y >= y && Constants.MIN_Y <= y) && !shouldNotVisitCell)))
            {
                VisitCell();
            }
        }
    }
}
