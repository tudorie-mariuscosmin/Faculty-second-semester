using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Subiect2020
{
    public partial class EditVehicle : Form
    {
        Vehicle vehicle;
        public EditVehicle(Vehicle vehicle)
        {
            this.vehicle = vehicle;
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            vehicle.Maker = tbMaker.Text;
            vehicle.Model = tbModel.Text;
            vehicle.Capacity = (int)tbCapacity.Value;
            vehicle.HorsePower = (int)tbHP.Value;
        }
    }
}
