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
    public partial class editBook : Form
    {
        Book book;

        public editBook(Book book)
        {
            InitializeComponent();
            
            this.book = book;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbName.Text = book.Name;
            tbPages.Text = book.NoPages.ToString();
            checkBox1.Checked = book.Booked;

        }

        private void editBook_Load(object sender, EventArgs e)
        {
            book.Name = tbName.Text;
            book.NoPages = int.Parse(tbPages.Text);
            book.Booked = checkBox1.Checked;

          

        }
    }
}
