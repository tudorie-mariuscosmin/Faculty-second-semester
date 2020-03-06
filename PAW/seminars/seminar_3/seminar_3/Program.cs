using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seminar_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person("test1", 10);
            p1.Marks = new int[] { 10, 10 };
            //Person p2 = p1;
            Person p2 = (Person)p1.Clone();
            p1.Age = 20;
            Console.WriteLine(p1.Age);
            Console.WriteLine(p2.Age);
            p2.Name = "test2";
            Console.WriteLine(p1.Name);
            Console.WriteLine(p2.Name);
            p1.Marks[0] = 9;
            Console.WriteLine(string.Join(", ", p1.Marks));
            Console.WriteLine(string.Join(", ", p2.Marks));

            string name = (string)p1;
            Console.WriteLine(name);
            

        }
    }
}
