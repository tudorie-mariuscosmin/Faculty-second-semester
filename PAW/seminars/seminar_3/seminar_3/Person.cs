using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seminar_3
{
    class Person : ICloneable
    {
        //am ajuns tarziu si nu stiu daca  e precis asa
        public string Name{get; set;}
        public int Age { get; set; }
        public int[] Marks { get; set; }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

         public object Clone()
         {
            var clone = (Person)MemberwiseClone();
            clone.Name = (string)Name.Clone();
            clone.Marks = (int[])Marks.Clone();
            return clone;
         }

         
        public static explicit operator string(Person p)
        {
            return p.Name;
        } 
        



    }
}
