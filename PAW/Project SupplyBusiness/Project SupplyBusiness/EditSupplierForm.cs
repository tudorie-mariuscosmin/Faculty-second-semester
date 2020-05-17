using Project_SupplyBusiness.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_SupplyBusiness
{
    public partial class EditSupplierForm : Form
    {
        private Supplier supplier;


        public EditSupplierForm( Supplier supplier)
        {
            this.supplier = supplier;
            InitializeComponent();
        }

        private void EditSupplierForm_Load(object sender, EventArgs e)
        {
            tbName.Text = supplier.SupplierName;
            tbBank.Text = supplier.BankAccount;
            tbEmployee.Text = supplier.RepresantativeEmploye;
            tbAdress.Text = supplier.HeadquartersAdress;
            tbPhone.Text = supplier.PhoneNumber;
            tbInregistration.Text = supplier.InregistrationNumber.ToString();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            supplier.SupplierName = tbName.Text;
            supplier.BankAccount = tbBank.Text;
            supplier.RepresantativeEmploye = tbEmployee.Text;
            supplier.HeadquartersAdress = tbAdress.Text;
            supplier.PhoneNumber = tbPhone.Text;
            supplier.InregistrationNumber = int.Parse(tbInregistration.Text);

        }
    }
}
