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
            Contractor c = new Contractor("contractor1", new[] {"python", "C#" });
            Manager m = new Manager("manager1");
            SoftwareDev s = new SoftwareDev("developer1", new[] { "java", "c#"});
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


            // people that do software development

            foreach(Person p in people)
            {
                if(p is IDeveloper)
                {
                    IDeveloper id = (IDeveloper)p;
                    Console.WriteLine($"{p.Name}: {string.Join(", ", id.Languages)}");

                }
            }

            //python

            foreach(Person p in people)
            {
                //IDeveloper id = (IDeveloper)p;
                IDeveloper id = p as IDeveloper;

                if(id!=null && id.knows("python"))
                {
                    Console.WriteLine(p.Name);
                }
            }




        }
    }
}
