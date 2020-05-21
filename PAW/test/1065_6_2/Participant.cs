using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1065_6_2
{
    [Serializable]
   public class Participant
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }

        private DateTime birthDate;
        public DateTime BirthDate { 
            get { return birthDate; }
            set {
                if (value > DateTime.Now)
                    throw new InvalidBithDateException(value);

                birthDate = value; 
            } 
        }
        public Participant()
        {

        }

        public Participant(string lastName, string firstName, DateTime birthDate)
        {
            LastName = lastName;
            FirstName = firstName;
            BirthDate = birthDate;
        }
    }
}
