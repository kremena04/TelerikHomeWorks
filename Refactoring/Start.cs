using System;

namespace WalkInMatrix
{
    internal class Start
    {
        internal static void Main(string[] args)
        {
            Console.WriteLine( "Enter a positive number " );
            string input = Console.ReadLine();
            int n = 0;
            while (!int.TryParse(input, out n) || n < 0 || n > 100)
            {
                Console.WriteLine("You haven't entered a correct positive number");
                input = Console.ReadLine();
            }

            int size = int.Parse(input);
            Matrix matrix = new Matrix(size);
            Console.WriteLine(matrix);

        }
    }
}
