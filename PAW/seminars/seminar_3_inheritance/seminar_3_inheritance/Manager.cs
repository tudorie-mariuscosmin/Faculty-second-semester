using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seminar_3_inheritance
{
    class Manager : Employee
    {
        public Manager(string name) : base(name)
        {
        }

        public override void abstractMethod()
        {
            Console.WriteLine("manager - abstract method");
        }
    }
}
