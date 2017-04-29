using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherInfo { get; set; }

        public bool IsOlderThan(Student other)
        {
            DateTime currentStudentBirthday =
                DateTime.Parse(this.OtherInfo.Substring(this.OtherInfo.Length - 10));
            DateTime otherStudentBirthday =
                DateTime.Parse(other.OtherInfo.Substring(other.OtherInfo.Length - 10));

            bool isOlderThan = currentStudentBirthday > otherStudentBirthday;

            return isOlderThan;
        }
    }
}
