using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_1065_Tudorie_Marius_Cosmin
{
  public  class Library
    {
        public List<Book> books { get; set; }

        public Library()
        {
            this.books = new List<Book>();
        }


        public void addBook(Book book)
        {
            books.Add(book);
        }


        public static Library operator +(Library library, Book book)
        {
            library.addBook(book);
            return library;
        }
    }
}
