using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassChef
{
    public class Program
    {
        public static void Main()
        {
            Cook cook = new Cook();
            Potato potato = new Potato();
            Carrot carrot = new Carrot();
            Bowl bowl = new Bowl();

            cook.PeelVegetables(carrot);
            cook.PeelVegetables(potato);
            cook.CutVegetables(carrot);
            cook.CutVegetables(potato);

            bowl.Add(carrot);
            bowl.Add(potato);
        }

    }
}

   


