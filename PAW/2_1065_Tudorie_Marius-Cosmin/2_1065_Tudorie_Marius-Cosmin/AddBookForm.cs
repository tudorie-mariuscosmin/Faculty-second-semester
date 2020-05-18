using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2_1065_Tudorie_Marius_Cosmin
{
    public partial class AddBookForm : Form
    {
        Library library;
        public AddBookForm(Library library)
        {
            this.library = library;
            InitializeComponent();
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            string name = tbName.Text;
            int pages = int.Parse(tbNoPages.Text);
            Book book = new Book(name, pages, checkBox1.Checked);
            //library.addBook(book);
            library += book;
        }
    }
}
