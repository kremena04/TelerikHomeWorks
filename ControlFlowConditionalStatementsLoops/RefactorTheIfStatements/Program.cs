using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorTheIfStatements
{
    class Program
    {
        static void Main(string[] args)
        {
            Potato potato = new Potato();
            //... 
            if (potato != null)
            {
                if (!potato.HasNotBeenPeeled && !potato.IsRotten)
                {
                    Cook(potato);
                }
                    
            }
                
        }

        private static void Cook(Potato potato)
        {
            throw new NotImplementedException();
        }
    }
}
