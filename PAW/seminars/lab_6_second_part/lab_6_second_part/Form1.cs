using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_6_second_part
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tbLastName_Validating(object sender, CancelEventArgs e)
        {
            //if(tbLastName.Text.Trim() != string.Empty)
            if (string.IsNullOrWhiteSpace(tbLastName.Text))
            {
                errorProvider.SetError(tbLastName, "Please enter the last name!");
                e.Cancel = true;
            }
        }

        private void tbLastName_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(tbLastName, null);
        }

        private void tbFirstName_Validating(object sender, CancelEventArgs e)
        {
            if(tbFirstName.Text.Trim().Length<3)
            {
                errorProvider.SetError(tbFirstName, "At least 3 chars!");
                e.Cancel = true;
            }
        }

        private void tbFirstName_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(tbFirstName, null);
        }

        private void btnAddParticipant_Click(object sender, EventArgs e)
        {
            if(!ValidateChildren())
            {
                MessageBox.Show("The form contains errors!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
