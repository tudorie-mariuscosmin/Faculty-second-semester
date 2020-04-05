using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1065_6_2
{
    class Participant
    {
        public string LastName { get; set; }
        public string FIrstName { get; set; }
        private DateTime birthDate { get; set; }


        public DateTime BirthDate
        {
            get { return birthDate}
        }
        public Participant(string lastName, string fIrstName, DateTime birthDate)
        {
            LastName = lastName;
            FIrstName = fIrstName;
            this.birthDate = birthDate;
        }
    }
}
