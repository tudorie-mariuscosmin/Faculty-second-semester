using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

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
            lbParticipatsCount.Text = participants.Count.ToString();

            foreach(Participant participant in participants)
            {
                ListViewItem lvi = new ListViewItem(participant.LastName);
                lvi.SubItems.Add(participant.FirstName);
                lvi.SubItems.Add(participant.BirthDate.ToShortDateString());

                lvi.ImageKey = "stop.png";
                lvi.Tag = participant;

                lvParticipants.Items.Add(lvi);
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
                DateTime birthDate = dtpBirthDate.Value;

                try
                {
                    Participant participant = new Participant(lastName, firstName, birthDate);
                    participants.Add(participant);

                    DisplayParticipants();
                }
                catch (InvalidBithDateException ex)
                {
                    MessageBox.Show("Invalid birthDate: " + ex.BirthDate);
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            lvParticipants.View = View.List;
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            lvParticipants.View = View.Details;
        }

        private void btnSerializexml_Click(object sender, EventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Participant>));
            using(FileStream stream = File.Create("serialized.xml"))
            {
                serializer.Serialize(stream, participants);
            }
        }

        private void btnSerilizeBynary_Click(object sender, EventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            //FileStream stream = null;
            //try
            //{
            //    stream = File.Create("serialized.bin");
            //    formatter.Serialize(stream, participants);
            //}
            ////catch()
            //finally
            //{
            //    if (stream != null)
            //         stream.Dispose();
            //}

            using (FileStream stream = File.Create("serialized.bin"))
            {
                formatter.Serialize(stream, participants);
            }


        }

        private void btnDeserializeBinary_Click(object sender, EventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = File.OpenRead("serialized.bin"))
            {
               participants= (List<Participant>)formatter.Deserialize(stream);
                DisplayParticipants();
            }

        }

        private void btnDesirealizexml_Click(object sender, EventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Participant>));

            using(FileStream stream = File.OpenRead("serialized.xml"))
            {
                participants=(List<Participant>)serializer.Deserialize(stream);
                DisplayParticipants();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Save CSV as";
            dialog.Filter = "CSV file | *.csv";


            if(dialog.ShowDialog() == DialogResult.OK)
            {
                using (var writer = new StreamWriter(dialog.FileName))
                {
                    writer.WriteLine("LastName,FirstName,BirthDate");
                    foreach(var participant in participants)
                    {
                        writer.WriteLine($"{participant.LastName},{participant.FirstName},{participant.BirthDate}");
                    }
                }

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(lvParticipants.SelectedItems.Count != 1)
            {
                MessageBox.Show("Chose a participant");
            }
            else if(MessageBox.Show("are u sure", "delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning )== DialogResult.OK)
            {
                ListViewItem lvi = lvParticipants.SelectedItems[0];
                Participant participant = (Participant)lvi.Tag;

                participants.Remove(participant);
                DisplayParticipants();

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(lvParticipants.SelectedItems.Count != 1)
            {
                MessageBox.Show("Choose a participant!");
            }
            else
            {
                ListViewItem lvi = lvParticipants.SelectedItems[0];
                Participant participant = (Participant)lvi.Tag;

                EditForm editForm = new EditForm(participant);
                if(editForm.ShowDialog() == DialogResult.OK)
                {
                    DisplayParticipants();
                }
            }
        }
    }
}
