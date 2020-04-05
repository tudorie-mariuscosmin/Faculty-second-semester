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
    public partial class MainForm : Form
    {

        List<Participant> participants;

        public MainForm()
        {
            InitializeComponent();
            participants = new List<Participant>();
        }

        void DisplayParticipants()
        {
            lvParticipants.Items.Clear();
            foreach(Participant participant in participants)
            {
                ListViewItem lvi = new ListViewItem(participant.LastName);
                lvi.SubItems.Add(participant.FIrstName);
                lvi.SubItems.Add(participant.BirthDate.ToShortDateString());
                lvParticipants.Items.Add(lvi);
                lvi.ImageKey = "ttj";
            }
        }

        private void tbLastName_Validating(object sender, CancelEventArgs e)
        {
            //if (tbLastName.Text.Trim() != string.Empty)
            if(string.IsNullOrWhiteSpace(tbLastName.Text))
            {
                errorProvider.SetError(tbLastName, "Last Name is mandatory!");
                e.Cancel = true;
            }
        }

        private void tbLastName_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(tbLastName, null);
        }

        private void tbFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (tbFirstName.Text.Trim().Length < 3)
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
                MessageBox.Show(
                    "The form contains errors!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                string lastName = tbLastName.Text.Trim();
                string firstName = tbFirstName.Text.Trim();
                DateTime birthDate = dtpBirthday.Value;
                Participant participant = new Participant(lastName, firstName, birthDate);
                participants.Add(participant);
                DisplayParticipants();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnList_Click(object sender, EventArgs e)
        {
            lvParticipants.View = View.List;


        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            lvParticipants.View = View.Details;
        }
    }
}
