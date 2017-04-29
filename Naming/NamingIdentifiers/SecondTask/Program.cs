using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondTask
{
    class Program
    {
        public static void Main()
        {
            Human human = new Human();
            human.CreateHuman(1);
            Console.WriteLine(human.Name);
        }
    }
}
