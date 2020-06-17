using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festival
{
   public class Participant:IComparable<Participant>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string[] Concerts { get; set; }

        public Participant()
        {
            BirthDate = DateTime.Now;
        }

        public Participant( string name, string email, DateTime birthDate, string[] concerts)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
            Concerts = concerts;
        }

        public Participant(long id, string name, string email, DateTime birthDate, string[] concerts)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            Concerts = concerts;
        }

        public static explicit operator int(Participant participant)
        {
            int noConcerts = 0;
            foreach(var concert in participant.Concerts)
            {
                if (!string.IsNullOrEmpty(concert))
                {
                    noConcerts += 1;
                }
            }
            return noConcerts;
        }

        public int CompareTo(Participant other)
        {
            return Name.CompareTo(other.Name);
        }
    }
}
