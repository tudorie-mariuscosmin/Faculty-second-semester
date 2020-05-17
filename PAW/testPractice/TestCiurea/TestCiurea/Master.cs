using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCiurea
{
  public  class Master
    {
        public List<Candidate> candidates;

        public Master()
        {
            this.candidates = new List<Candidate>();
        }

        public static Master operator +(Master master, Candidate candidate)
        {
            master.candidates.Add(candidate);
            return master;

        }
    }
}
