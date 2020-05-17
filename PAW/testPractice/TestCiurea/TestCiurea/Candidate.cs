using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCiurea
{
   public class Candidate
    {
        public string Name { get; set; }
        public float Grade { get; set; }
        public string Cnp { get; set; }

        public Candidate(string name, float grade, string cnp)
        {
            Name = name;
            Grade = grade;
            Cnp = cnp;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Candidate ");
            builder.Append(Name);
            builder.Append(" with cnp ");
            builder.Append(Cnp);
            builder.Append(" has a grade of ");
            builder.Append(Grade);
            return builder.ToString();
        }
    }
}
