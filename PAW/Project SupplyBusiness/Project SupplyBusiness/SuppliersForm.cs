using Project_SupplyBusiness.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_SupplyBusiness
{
    public partial class SuppliersForm : Form
    {
        private string connectionString = "Data source=database.db";
       public List<Supplier> Suppliers { get; private set; }

        public SuppliersForm( List<Supplier> suppliers)
        {
            InitializeComponent();
            Suppliers = suppliers;
        }
        #region validations
        private void tbSupplierName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbSupplierName.Text.Trim()) || tbSupplierName.Text.Length < 3)
            {
                e.Cancel = true;
                errorProvider.SetError((Control)sender, "Please enter a valid name!");
            }
        }

        private void tbSupplierName_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError((Control)sender, string.Empty);
        }

        private void tbInregistrationNo_Validating(object sender, CancelEventArgs e)
        {
            if (tbInregistrationNo.Text == "0" || tbInregistrationNo.Text.Length != 7)
            {
                e.Cancel = true;
                errorProvider.SetError((Control)sender, "Please enter a valid 7 digit inregistration number!");
            }
        }

        private void tbInregistrationNo_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError((Control)sender, string.Empty);
        }

        private void tbInregistrationNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && Keys.Back != (Keys)e.KeyChar)
            {
                e.Handled = true;
            }
        }

        private void tbBankAccount_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError((Control)sender, string.Empty);
        }

        private void tbBankAccount_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbBankAccount.Text.Trim()) || tbBankAccount.Text.Length != 16)
            {
                e.Cancel = true;
                errorProvider.SetError((Control)sender, "Please enter a valid 16 digit bank account!");
            }
        }

        private void tbHeadquatersAdress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbHeadquatersAdress.Text.Trim()) || tbHeadquatersAdress.Text.Length < 10)
            {
                e.Cancel = true;
                errorProvider.SetError((Control)sender, "Please enter a valid adress");
            }
        }

        private void tbHeadquatersAdress_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError((Control)sender, string.Empty);
        }

        private void tbRepresentativeEmployee_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbRepresentativeEmployee.Text.Trim()) || tbRepresentativeEmployee.Text.Length < 10)
            {
                e.Cancel = true;
                errorProvider.SetError((Control)sender, "Please enter a valid name");
            }
        }

        private void tbRepresentativeEmployee_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError((Control)sender, string.Empty);
        }

        private void tbPhone_Validating(object sender, CancelEventArgs e)
        {
            if (tbPhone.Text == "0" || tbPhone.Text.Length != 10)
            {
                e.Cancel = true;
                errorProvider.SetError((Control)sender, "Please enter a valid phone number!");
            }
        }

        private void tbPhone_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError((Control)sender, string.Empty);
        }

        private void tbPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && Keys.Back != (Keys)e.KeyChar)
            {
                e.Handled = true;
            }
        }
        #endregion
        #region methods
        private void DisplaySuppliers()
        {
            lvSuppliers.Items.Clear();
            suppliersCount.Text = Suppliers.Count.ToString();
            foreach (var supplier in Suppliers)
            {
                var lvItem = new ListViewItem(supplier.SupplierName);
                lvItem.SubItems.Add(supplier.InregistrationNumber.ToString());
                lvItem.SubItems.Add(supplier.BankAccount);
                lvItem.SubItems.Add(supplier.HeadquartersAdress);
                lvItem.SubItems.Add(supplier.RepresantativeEmploye);
                lvItem.SubItems.Add(supplier.PhoneNumber);
                lvItem.Tag = supplier;
                lvSuppliers.Items.Add(lvItem);
            }
        }

        private void AddSupplier(Supplier supplier)
        {
            string sql = "INSERT INTO supplier (s_name, s_inregistration, s_bank, headquaters, s_phone, employee) " +
                " VALUES(@s_name, @s_inregistration, @s_bank, @headquaters, @s_phone, @employee); " +
                "SELECT last_insert_rowid();";


            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                var command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("@s_name", supplier.SupplierName);
                command.Parameters.AddWithValue("@s_inregistration", supplier.InregistrationNumber);
                command.Parameters.AddWithValue("@s_bank", supplier.BankAccount);
                command.Parameters.AddWithValue("@headquaters", supplier.HeadquartersAdress);
                command.Parameters.AddWithValue("@s_phone", supplier.PhoneNumber);
                command.Parameters.AddWithValue("@employee", supplier.RepresantativeEmploye);

                connection.Open();
                long id = (long)command.ExecuteScalar();
                supplier.Id = id;
                Suppliers.Add(supplier);
            }
        }

        
        #endregion
        #region events

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                //An ErrorProvider control should
                MessageBox.Show("The form contains errors!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }
            string name = tbSupplierName.Text;
            int inregistration = int.Parse(tbInregistrationNo.Text);
            string bank = tbBankAccount.Text;
            string headquaters = tbHeadquatersAdress.Text;
            string employee = tbRepresentativeEmployee.Text;
            string phone = tbPhone.Text;

            Supplier supplier = new Supplier(name, inregistration, bank, headquaters, employee, phone);
            AddSupplier(supplier);
            MessageBox.Show("New supplier added succesfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            DisplaySuppliers();

        }

        private void btnAddGood_Click(object sender, EventArgs e)
        {
           if(lvSuppliers.SelectedItems.Count == 0)
            {
                MessageBox.Show("Choose a Supplier");
            }
            else
            {
                var supplier =(Supplier) lvSuppliers.SelectedItems[0].Tag;
                GoodForm goodForm = new GoodForm(supplier);
                goodForm.ShowDialog();
            }
        }

        private void SuppliersForm_Load(object sender, EventArgs e)
        {
            
            DisplaySuppliers();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvSuppliers.SelectedItems.Count == 0)
            {
                MessageBox.Show("Choose a Supplier");
            }
            else
            {
                var supplier = (Supplier)lvSuppliers.SelectedItems[0].Tag;
                EditSupplierForm form = new EditSupplierForm(supplier);
                if (form.ShowDialog() == DialogResult.OK)
                    DisplaySuppliers();

                
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvSuppliers.SelectedItems.Count == 0)
            {
                MessageBox.Show("Choose a Supplier");
                return;
            }
            if(MessageBox.Show("Are you sure?", "Delete Participant", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)== DialogResult.Yes)
            {
                Suppliers.Remove((Supplier)lvSuppliers.SelectedItems[0].Tag);
                DisplaySuppliers();
            }
            

        }

        private void addGoodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvSuppliers.SelectedItems.Count > 0)
            {
                GoodForm goodForm = new GoodForm((Supplier)lvSuppliers.SelectedItems[0].Tag);
                goodForm.ShowDialog();
            }
        }


        #endregion

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvSuppliers.SelectedItems.Count > 0)
            {
                EditSupplierForm form = new EditSupplierForm((Supplier)lvSuppliers.SelectedItems[0].Tag);
                if (form.ShowDialog() == DialogResult.OK)
                    DisplaySuppliers();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvSuppliers.SelectedItems.Count > 0)
            {
                Suppliers.Remove((Supplier)lvSuppliers.SelectedItems[0].Tag);
                DisplaySuppliers();

            }
            

        }
    }
}
