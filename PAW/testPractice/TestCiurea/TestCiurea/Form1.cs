using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestCiurea
{
    public partial class Form1 : Form
    {

        private Licence licence;
        private Master master;

        public Form1()
        {
            InitializeComponent();
            licence = new Licence();
            master = new Master();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            
            string name = tbName.Text;
            float grade = 0;
            try
            {
                grade = float.Parse(tbGrade.Text);
            }catch(Exception)
            {
                MessageBox.Show("form contains errors");
            }
            string cnp = tbCnp.Text;

            string option = comboBox1.Text;

            Candidate candidate = new Candidate(name, grade, cnp);
            if (option == "Licence")
                licence += candidate;
            else if (option == "Master")
                master += candidate;
            else
                MessageBox.Show("Select a type!");



        }

        private void tbName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError((Control)sender, "Please enter a name");
            }
        }

        private void tbName_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError((Control)sender, string.Empty);
        }

        private void tbGrade_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbGrade.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError((Control)sender, "Enter a grade");
      
            }
        }

        private void tbGrade_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError((Control)sender, string.Empty);
        }

        private void tbGrade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar !=(char)Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            ViewForm form = new ViewForm(licence, master);
            form.Show();
        }
    }
}
