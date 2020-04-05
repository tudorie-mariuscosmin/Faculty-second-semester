using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seminar_5_winForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void op2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int op1 = int.Parse( tbOp1.Text);
            int op2 = int.Parse(tbOp2.Text);
            int sum = op1 + op2;

            tbSum.Text = sum.ToString();
        }

        private void tbOp1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && Keys.Back !=(Keys)e.KeyChar)
            {
                e.Handled = true;
            }
        }
    }
}
