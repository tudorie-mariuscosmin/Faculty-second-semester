using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1065_6_2
{
    class InvalidBithDateException : Exception
    {
        public DateTime BirthDate { get; set; }

        public InvalidBithDateException(DateTime birthDate)
        {
            BirthDate = birthDate;
        }
    }
}
