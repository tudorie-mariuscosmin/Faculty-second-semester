using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1065_Tudorie_Marius_Cosmin
{
   public class Members:IComparable<Members>
    {
        public static long counter = 1;
        public long Id { get; set; }
        public string Name { get; set; }
        public long Age { get; set; }
        public long Type { get; set; }

        public Members() {
            Id = counter;
            counter++;
        }

        public Members(string name, long age, long type)
        {
            Id = counter;
            Name = name;
            Age = age;
            Type = type;
            counter++;
        }

        public int CompareTo(Members other)
        {
            //if (Age < other.Age)
            //{
            //    return -1;
            //}
            //else if (Age == other.Age)
            //    return 0;
            //else return 1;

            return Name.CompareTo(other.Name);
          
        }
    }
}
