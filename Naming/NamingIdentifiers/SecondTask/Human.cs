using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondTask
{
    public class Human
    {
        public Gender Gender { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public void CreateHuman(int humanAge)
        {
            this.Age = humanAge;
            if (humanAge % 2 == 0)
            {
                this.Name = "Pesho";
                this.Gender = Gender.male;
            }
            else
            {
                this.Name = "Maria";
                this.Gender = Gender.female;
            }
        }
    }
}
