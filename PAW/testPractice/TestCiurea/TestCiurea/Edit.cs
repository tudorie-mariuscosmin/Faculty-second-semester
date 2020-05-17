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
    public partial class Edit : Form
    {

        Candidate candidate;

        public Edit(Candidate candidate)
        {
            this.candidate = candidate;
            InitializeComponent();
        }

        private void Edit_Load(object sender, EventArgs e)
        {
            tbCnp.Text = candidate.Cnp;
            tbName.Text = candidate.Name;
            tbGrade.Text = candidate.Grade.ToString();

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            candidate.Name = tbName.Text;
            candidate.Grade = float.Parse(tbGrade.Text);
            candidate.Cnp = tbCnp.Text;
           
        }
    }
}
