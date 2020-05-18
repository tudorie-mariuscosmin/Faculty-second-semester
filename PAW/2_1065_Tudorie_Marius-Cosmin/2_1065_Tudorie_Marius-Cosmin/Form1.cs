using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace _2_1065_Tudorie_Marius_Cosmin
{
    public partial class Form1 : Form
    {
      public  Library Library { get; set; }


        public Form1()
        {
            Library = new Library();
            InitializeComponent();
        }

        private void displayBooks()
        {
            lvBooks.Items.Clear();
            Library.books.Sort();
            foreach(var book in Library.books)
            {
                ListViewItem item = new ListViewItem(book.Name);
                item.SubItems.Add(book.NoPages.ToString());
                item.SubItems.Add(book.Booked.ToString());
                item.SubItems.Add(book.ToString());
                item.Tag = book;
                lvBooks.Items.Add(item);
            }
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            AddBookForm form = new AddBookForm(Library);
           if(form.ShowDialog() == DialogResult.OK)
                displayBooks();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));
            using (FileStream stream = File.OpenRead("books.xml"))
            {
                Library.books = (List<Book>)serializer.Deserialize(stream);
                displayBooks();

            }
            displayBooks();
            
        }

        //private void editToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    Book book = lvBooks.SelectedItems[0].Tag;
        //}

        private void serializeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XmlSerializer serializerSupplier = new XmlSerializer(typeof(List<Book>));
            using (FileStream supStream = File.Create("books.xml"))
            {
                serializerSupplier.Serialize(supStream, Library.books);
            }
        }

        private void deserializeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));
            using (FileStream stream = File.OpenRead("books.xml"))
            {
                Library.books =(List<Book>)serializer.Deserialize(stream);
                displayBooks();

            }

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void Form1_Leave(object sender, EventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));
            using (FileStream stream = File.OpenRead("books.xml"))
            {
                Library.books = (List<Book>)serializer.Deserialize(stream);
                displayBooks();

            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));
            using (FileStream stream = File.OpenRead("books.xml"))
            {
                Library.books = (List<Book>)serializer.Deserialize(stream);
                displayBooks();

            }

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Book book = (Book)lvBooks.SelectedItems[0].Tag;
            editBook form = new editBook(book);
            if(form.s)
        }
    }
}
