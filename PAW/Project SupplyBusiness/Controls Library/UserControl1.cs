using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controls_Library
{
    public partial class UserControl1 : UserControl
    {
        private double moneyAmount;
        public double MoneyAmount
        {
            get { return moneyAmount; }
            set
            {
                moneyAmount = value;
                Invalidate();
            }
        }
        public UserControl1()
        {
            InitializeComponent();
            moneyAmount = 10;
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text == "Euro")
            {
                double value = moneyAmount * 0.20649;
                textBox1.Text = value.ToString();
            }else if(comboBox1.Text == "Dollars")
            {
                double value = moneyAmount * 0.22667;
                textBox1.Text = value.ToString();
            }else if(comboBox1.Text == "GB Pounds")
            {
                double value = moneyAmount * 0.185568;
                textBox1.Text = value.ToString();
            }
        }
    }
}
