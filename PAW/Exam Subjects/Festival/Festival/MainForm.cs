using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Festival
{
    public partial class Form1 : Form
    {
        private List<Participant> participants;
        private string[] concertArray = new string[] { "Concert1", "Concert2", "Concert3", "Concert4", "Concert5" };
        private string connectionString = "Data Source = database.db";
        public Form1()
        {
            this.participants = new List<Participant>();
            InitializeComponent();
        }

        private void AddParticipantToDb(Participant participant)
        {
            string sql = "INSERT INTO Participants(name, email, birthdate, concert) VALUES(@name, @email, @birthDate, @concert); select last_insert_rowid();";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                var command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("@name", participant.Name);
                command.Parameters.AddWithValue("email", participant.Email);
                command.Parameters.AddWithValue("@birthDate", participant.BirthDate);
                command.Parameters.AddWithValue("@concert", string.Join(",", participant.Concerts));
                connection.Open();
                long id = (long)command.ExecuteScalar();
                participant.Id = id;

            }
        }

        private void UpdateDatabase(Participant participant)
        {
            string sql = "Update participants set name=@name, email=@email, birthdate=@birthdate, concert=@concert where id = @id;";
            using(SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                var command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("@name", participant.Name);
                command.Parameters.AddWithValue("@email", participant.Email);
                command.Parameters.AddWithValue("@birthdate", participant.BirthDate);
                command.Parameters.AddWithValue("@concert", string.Join(",", participant.Concerts));
                command.Parameters.AddWithValue("@id", participant.Id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void DeleteDatabase(Participant participant)
        {
            string sql = "DELETE FROM PARTICIPANTS WHERE ID = @ID";

            using(SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                var command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("@ID", participant.Id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void LoadParticipantsFromDb()
        {
            string querry = "select* from participants;";
            using(SQLiteConnection connection =  new SQLiteConnection(connectionString))
            {
                var command = new SQLiteCommand(querry, connection);
                connection.Open();

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    long id = (long)reader["id"];
                    string name =(string) reader["name"];
                    string email = (string)reader["email"];
                    DateTime birthdate = DateTime.Parse(reader["birthdate"].ToString());
                    string concerts = (string)reader["concert"];

                    Participant participant = new Participant(id, name, email, birthdate, concerts.Split(','));
                    participants.Add(participant);
                }

            }
        }


        public void displayParticipants()
        {
            dgvParticipants.Rows.Clear();
            participants.Sort();
            foreach(var participant in participants)
            {
                string concerts = string.Join(",", participant.Concerts);
                int index = dgvParticipants.Rows.Add(new object[]
                {
                    participant.Id,
                    participant.Name,
                    participant.Email,
                    participant.BirthDate,
                    concerts
                });
                dgvParticipants.Rows[index].Tag = participant;

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadParticipantsFromDb();
            displayParticipants();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Participant participant = new Participant();
            EditParticipant editParticipant = new EditParticipant(participant, concertArray);
            if(editParticipant.ShowDialog()== DialogResult.OK)
            {
                AddParticipantToDb(participant);
                participants.Add(participant);
                displayParticipants();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvParticipants.SelectedRows.Count == 1)
            {
                Participant participant =(Participant)dgvParticipants.SelectedRows[0].Tag;
                DeleteDatabase(participant);
                participants.Remove(participant);
                displayParticipants();

            }
            else
            {
                MessageBox.Show("Please select a row!");
            }
        }

        private void dgvParticipants_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvParticipants.SelectedRows.Count == 1)
            {
                Participant participant = (Participant)dgvParticipants.SelectedRows[0].Tag;
                EditParticipant editForm = new EditParticipant(participant, concertArray);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    UpdateDatabase(participant);
                    displayParticipants();
                }
            }

        }

        private void btnNoParticipants_Click(object sender, EventArgs e)
        {
            int sum = 0;
            foreach(var participant in participants)
            {
                sum += (int)participant;
            }
            tbNoParticipants.Text = sum.ToString();
        }

        private void saveAndExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save raport as";
            saveFileDialog.Filter = "text file |*.txt";
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using(StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName))
                {
                    streamWriter.WriteLine("Raport from " + DateTime.Now);
                    streamWriter.WriteLine("----------------------------------------");
                    foreach(Participant participant in participants)
                    {
                        streamWriter.WriteLine("Name: " + participant.Name);
                        streamWriter.WriteLine("Email: "+ participant.Email);
                        streamWriter.WriteLine("Birthdate: " + participant.BirthDate.ToShortDateString());
                        streamWriter.WriteLine("Concerts: " + string.Join(",",participant.Concerts));
                        streamWriter.WriteLine("-------------------------------------");
                    }
                }
            }

            Close();
        }
    }
}
