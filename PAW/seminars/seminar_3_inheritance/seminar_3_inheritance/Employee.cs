using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seminar_3_inheritance
{
   abstract class Employee : Person
    {
        public Employee(string name) : base(name)
        {
        }

        public abstract void abstractMethod();

        public virtual void VirtualMethod()
        {
            Console.WriteLine("**employee virtual method**");
        }

        public void NormalMethod()
        {
            Console.WriteLine("employee normal method");
        }
    }
}
