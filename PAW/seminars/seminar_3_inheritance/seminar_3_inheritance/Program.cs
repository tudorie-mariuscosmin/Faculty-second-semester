using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seminar_3_inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Contractor c = new Contractor("contractor1");
            Manager m = new Manager("manager1");
            SoftwareDev s = new SoftwareDev("developer1");
            Person[] people = new Person[] { c, m, s };

            foreach (Person p in people)
            {
                if(p is Employee)
                {
                    Employee e = (Employee)p;
                    //e.abstractMethod();
                    // e.VirtualMethod();
                    e.NormalMethod();
                }
            }

        }
    }
}
