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

namespace Subiect2020
{
    public partial class MainForm : Form
    {
        Fleet fleet;
        public MainForm()
        {
            fleet = new Fleet();
            InitializeComponent();
        }

        private void displayVehicles()
        {
            listView.Items.Clear();

            foreach(var vehicle in fleet.vehicles)
            {
                ListViewItem item = new ListViewItem(vehicle.Maker);
                item.SubItems.Add(vehicle.Model);
                item.SubItems.Add(vehicle.Capacity.ToString());
                item.SubItems.Add(vehicle.HorsePower.ToString());
                item.Tag = vehicle;
                listView.Items.Add(item);
                
            }
        }

        private void BtnAddVechicle_Click(object sender, EventArgs e)
        {
            Vehicle vehicle = new Vehicle();
            EditVehicle edit = new EditVehicle(vehicle);
            if( edit.ShowDialog() == DialogResult.OK)
            {
                fleet += vehicle;
                displayVehicles();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(listView.SelectedItems.Count != 1)
            {
                MessageBox.Show("Please select a car!");
            }
            else if(MessageBox.Show("Are you sure you want to delete this vehicle?", "Delete car", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Vehicle vehicle = (Vehicle)listView.SelectedItems[0].Tag;
                fleet.vehicles.Remove(vehicle);
                displayVehicles();
                
            }
        }


        private void binarySerialize()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using(FileStream fileStream = File.Create("vehicles.bin"))
            {
                formatter.Serialize(fileStream, fleet.vehicles);
            }
        }

        private void binaryDeserialize()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = File.OpenRead("vehicles.bin"))
            {
                fleet.vehicles =(List<Vehicle>) formatter.Deserialize(stream);
                displayVehicles();
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            binarySerialize();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            binaryDeserialize();
        }

        private void btnChart_Click(object sender, EventArgs e)
        {
            barChart.Data = fleet;
        }
    }
}
