using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1065_6_2

{
    public partial class EditForm : Form
    {
        Participant participant;
        public EditForm(Participant participant)
        {
            InitializeComponent();
            this.participant = participant;
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            tbLastName.Text = participant.LastName;
            tbFirstName.Text = participant.FirstName;
            dtbBirthDate.Value = participant.BirthDate;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            participant.LastName = tbLastName.Text;
            participant.FirstName = tbFirstName.Text;
            participant.BirthDate = dtbBirthDate.Value;
            
        }
    }
}
