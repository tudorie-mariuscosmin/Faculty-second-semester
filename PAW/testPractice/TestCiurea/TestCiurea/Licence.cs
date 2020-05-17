using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCiurea
{
   public class Licence
    {
        public List<Candidate> candidates;

        public Licence()
        {
            this.candidates = new List<Candidate>();
        }

        public static Licence operator + (Licence licence, Candidate candidate)
        {
            licence.candidates.Add(candidate);
            return licence;

        }

    }
}
