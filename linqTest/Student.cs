using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linqTest
{
    internal class Student
    {

        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsMale { get; set; }



        public Student(string name, int age, bool isMale)
        {
            Name = name;
            Age = age;
            IsMale = isMale;
        }
    }
}
