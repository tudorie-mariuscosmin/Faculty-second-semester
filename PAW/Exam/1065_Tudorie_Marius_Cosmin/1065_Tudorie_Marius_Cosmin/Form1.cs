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
using System.Xml.Serialization;

namespace _1065_Tudorie_Marius_Cosmin
{
    public partial class Form1 : Form
    {
        private string connectionString = "Data Source = database.db";
        public Gym gym;
        public Form1()
        {
            this.gym = new Gym();
            InitializeComponent();
        }

        private void displayMembers()
        {
            lvMembers.Items.Clear();
            gym.members.Sort();
            foreach(Members member in gym.members)
            {
                ListViewItem item = new ListViewItem(member.Id.ToString());
                item.SubItems.Add(member.Name);
                item.SubItems.Add(member.Age.ToString());
                item.SubItems.Add(member.Type.ToString());
                item.Tag = member;
                lvMembers.Items.Add(item);
            }
        }

        private void insertDatabase()
        {
            string deleteQuerry = "delete from members ";
            using(SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                SQLiteCommand command = new SQLiteCommand(deleteQuerry, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }

            foreach(Members member in gym.members)
            {
                string sql = "Insert into members(id, name, age, type) values( @id,@name, @age, @type);";
                using(SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    SQLiteCommand command = new SQLiteCommand(sql, connection);
                    command.Parameters.AddWithValue("@id", member.Id);
                    command.Parameters.AddWithValue("@name", member.Name);
                    command.Parameters.AddWithValue("@age", member.Age);
                    command.Parameters.AddWithValue("@type", member.Type);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Members member = new Members();
            EditMemberForm editMemberForm = new EditMemberForm(member);
            if(editMemberForm.ShowDialog() == DialogResult.OK)
            {
                gym.members.Add(member);
                displayMembers();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            xmlDeserializer();
            displayMembers();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvMembers.SelectedItems.Count == 1)
            {
                Members member = (Members)lvMembers.SelectedItems[0].Tag;
                EditMemberForm editMemberForm = new EditMemberForm(member);
                if (editMemberForm.ShowDialog() == DialogResult.OK)
                {
                    displayMembers();
                }
            }

            

        }

        private void BtnSaveDatabase_Click(object sender, EventArgs e)
        {
            insertDatabase();
        }


        private void XmlSerialiezer()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Members>));
            using (FileStream stream = File.Create("serialized.xml"))
            {
                serializer.Serialize(stream, gym.members);
            }
        }

        private void xmlDeserializer()
        {
           
                XmlSerializer serializer = new XmlSerializer(typeof(List<Members>));
            if (File.Exists("serialized.xml"))
            {
                using (FileStream stream = File.OpenRead("serialized.xml"))
                {
                    gym.members = (List<Members>)serializer.Deserialize(stream);
                }
            }
                
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            XmlSerialiezer();
        }
    }
}
