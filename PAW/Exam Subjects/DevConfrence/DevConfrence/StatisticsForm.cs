using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevConfrence
{
    public partial class StatisticsForm : Form
    {
        private List<Registration> registrations;
        public StatisticsForm( List<Registration> registrations)
        {
            this.registrations = registrations;
            InitializeComponent();
        }

        private void StatisticsForm_Load(object sender, EventArgs e)
        {
            int[] array = new int[] { 0, 0, 0 };
            foreach(Registration reg in registrations)
            {
                if (reg.AccessPackageId == 1)
                {
                    array[0]++;
                }
                else if (reg.AccessPackageId == 2)
                {
                    array[1]++;
                }
                else
                    array[2]++;
            }
            barChart1.Data = array;
        }
    }
}
