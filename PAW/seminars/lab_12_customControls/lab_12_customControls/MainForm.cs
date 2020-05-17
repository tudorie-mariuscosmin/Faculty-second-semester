using ControlLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_12_customControls
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnUpdateChart_Click(object sender, EventArgs e)
        {
            var data = new BarChartValue[]
            {
                new BarChartValue("2020", 150),
                new BarChartValue("2021", 200),
                new BarChartValue("2022", 300),
                new BarChartValue("2023", 4000)
            };
            barChartControl1.Data = data;
        }
    }
}
