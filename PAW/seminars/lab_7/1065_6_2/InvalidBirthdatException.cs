using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1065_6_2
{
    class InvalidBirthdatException: Exception
    {
        public DateTime BirthDare { get; set; }

        public InvalidBirthdatException(DateTime birthDare)
        {
            BirthDare = birthDare;
        }
    }
}
