using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_1065_Tudorie_Marius_Cosmin
{
   public class Book:IComparable<Book>
    {
        public string Name { get; set; }
        public int NoPages { get; set; }
        public bool Booked { get; set; }

        public Book() { }

        public Book(string name, int noPages, bool booked)
        {
            Name = name;
            NoPages = noPages;
            Booked = booked;
        }
       

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Book: ");
            builder.Append(Name);
            builder.Append(" has ");
            builder.Append(NoPages);
            builder.Append(" no of pages");
            return builder.ToString();
        }

        public int CompareTo(Book other)
        {
            if (other.NoPages > NoPages)
                return -1;
            else if (other.NoPages == NoPages)
                return 0;
            else return 1;
        }
    }
}
