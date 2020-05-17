using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestCiurea
{
    public partial class ViewForm : Form
    {

        private Licence licence;
        private Master master;

        public ViewForm( Licence licence, Master master)
        {
            this.licence = licence;
            this.master = master;
            InitializeComponent();
        }


        private void diplayContestants()
        {
            lbLicence.Items.Clear();
            lbMaster.Items.Clear();
            foreach(var item in licence.candidates)
            {
                lbLicence.Items.Add(item.ToString());
            }
            foreach (var item in master.candidates)
                lbMaster.Items.Add(item.ToString());
   
        }

        private void ViewForm_Load(object sender, EventArgs e)
        {
            diplayContestants(); 
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = lbLicence.SelectedIndex;

            Edit edit = new Edit(licence.candidates[index]);
            if(edit.ShowDialog() == DialogResult.OK)
            {
                diplayContestants();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = lbLicence.SelectedIndex;
            licence.candidates.Remove(licence.candidates[index]);
            diplayContestants();

        }

        private void editdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = lbMaster.SelectedIndex;

            Edit edit = new Edit(master.candidates[index]);
            if (edit.ShowDialog() == DialogResult.OK)
            {
                diplayContestants();
            }

        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int index = lbMaster.SelectedIndex;
            licence.candidates.Remove(master.candidates[index]);
            diplayContestants();
        }
    }
}
