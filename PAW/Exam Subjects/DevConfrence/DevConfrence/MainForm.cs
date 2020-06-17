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

namespace DevConfrence
{
    public partial class MainForm : Form
    {
        private List<AccessPackage> packages;
        private List<Registration> registrations;
        public MainForm()
        {
            registrations = new List<Registration>();
            packages = new List<AccessPackage>();
            InitializeComponent();
            
        }

        private void LoadPackages()
        {
            using (StreamReader reader = File.OpenText("AccessPackages.txt"))
            {
                string line;
                while((line = reader.ReadLine()) != null)
                {
                    var arr = line.Split(',');
                    AccessPackage package = new AccessPackage(int.Parse(arr[0]), arr[1],double.Parse( arr[2]));
                    packages.Add(package);
                }

            }


        }

        private void displayRegistrations()
        {
            listView.Items.Clear();
            foreach (Registration registration in registrations)
            {
                ListViewItem item = new ListViewItem(registration.CompanyName);
                item.SubItems.Add(registration.NoOfPasses.ToString());
                var type = packages.First(x => registration.AccessPackageId == x.Id);
                item.SubItems.Add(type.ToString());
                item.Tag = registration;
                listView.Items.Add(item);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Registration registration = new Registration();
            EditRegistration editRegistration = new EditRegistration(packages, registration);
            if(editRegistration.ShowDialog() == DialogResult.OK)
            {
                registrations.Add(registration);
                displayRegistrations();


            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadPackages();
            XMLDeserialise();
            displayRegistrations();

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count != 1)
            {
                MessageBox.Show("Select one record to delete");
            }
            else
            {
                Registration registration =(Registration)listView.SelectedItems[0].Tag;
                registrations.Remove(registration);
                displayRegistrations();
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count != 1)
            {
                MessageBox.Show("Select one record to edit");
            }
            else
            {
                Registration registration = (Registration)listView.SelectedItems[0].Tag;
                EditRegistration registrationForm = new EditRegistration(packages, registration);
                if (registrationForm.ShowDialog() == DialogResult.OK)
                {
                    displayRegistrations();
                }
            }
        }


        private void XMLSerialize()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Registration>));
            using (FileStream stream = File.Create("Registeation.xml"))
            {
                serializer.Serialize(stream, registrations);
            }
        }

        private void XMLDeserialise()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Registration>));
            using (FileStream stream = File.OpenRead("Registeation.xml"))
            {
               registrations = (List<Registration>)serializer.Deserialize(stream);
            }

        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            XMLSerialize();
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            if(cbSortingOrder.Text == "Name")
            {
                CompareName name = new CompareName();
                registrations.Sort(name);
                displayRegistrations();
                  
            }
            else
            {
                CompareType type = new CompareType();
                registrations.Sort(type);
                displayRegistrations();
            }
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            StatisticsForm statisticsForm = new StatisticsForm(registrations);
            statisticsForm.Show();
        }
    }
}
