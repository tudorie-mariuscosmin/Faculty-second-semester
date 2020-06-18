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

namespace _1065_Tudorie_Marius_Cosmin
{
    public partial class EditMemberForm : Form
    {
        private Members member;
        public EditMemberForm(Members member)
        {
            this.member = member;
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                MessageBox.Show("The form contains errors!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                DialogResult = DialogResult.Abort;
            }
            member.Name = tbName.Text;
            member.Age = (long)noAge.Value;
            member.Type = (long)noType.Value;
        }

        private void tbName_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(tbName.Text)|| tbName.Text.Length < 3)
            {
                e.Cancel = true;
                errorProvider.SetError((Control)sender, "Please enter a name largen than 3");
            }
        }

        private void tbName_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError((Control)sender, null);
        }

        private void noAge_Validating(object sender, CancelEventArgs e)
        {
            if(noAge.Value< 16)
            {
                e.Cancel = true;
                errorProvider.SetError((Control)sender, "You have to have an age bigger than 16");
            }
        }

        private void noAge_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError((Control)sender, null);
        }

        private void noType_Validating(object sender, CancelEventArgs e)
        {
            if (noType.Value >5)
            {
                e.Cancel = true;
                errorProvider.SetError((Control)sender, "we don't have types bigger than 5");
            }
        }

        private void noType_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError((Control)sender, null);
        }

        private void EditMemberForm_Load(object sender, EventArgs e)
        {
            tbName.Text = member.Name;
            noAge.Value = (decimal)member.Age;
            noType.Value = (decimal)member.Type;
        }


        
    }
}
