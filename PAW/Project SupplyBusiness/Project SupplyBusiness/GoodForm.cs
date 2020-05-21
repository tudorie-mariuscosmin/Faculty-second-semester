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
    public partial class GoodForm : Form
    {
        public Supplier Supplier { get; set; }
        private string connectionString = "Data Source=database.db";

    


        public GoodForm(Supplier supplier)
        {
            Supplier = supplier;
            InitializeComponent();
            
        }

        private void addGood(Good good)
        {
            string sql = "INSERT INTO good (g_name, g_price, g_description, taxable, supplier_id, category) VALUES(@name, @price, @description, @taxable, @supplier_id, @category); SELECT last_insert_rowid();";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            using(SQLiteCommand command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@name", good.Name);
                command.Parameters.AddWithValue("@price", good.Price);
                command.Parameters.AddWithValue("@description", good.Description);
                command.Parameters.AddWithValue("@taxable", good.Taxable.ToString());
                command.Parameters.AddWithValue("@supplier_id", Supplier.Id);
                command.Parameters.AddWithValue("@category", good.Category);


                connection.Open();
                long id =(long) command.ExecuteScalar();
                good.Id = id;
                Supplier.AddGood(good);
            }


        }

        private void BtnAddGood_Click(object sender, EventArgs e)
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
            string name = tbGoodName.Text;
            double price = double.Parse(tbPrice.Text);
            GoodCategory category;
            if (cbCategoty.Text == "Food")
                category = GoodCategory.Food;
            else if (cbCategoty.Text == "Electronics")
                category = GoodCategory.Electronics;
            else if (cbCategoty.Text == "Furniture")
                category = GoodCategory.Furniture;
            else if (cbCategoty.Text == "Pharmaceutical")
                category = GoodCategory.Pharmaceutical;
            else if (cbCategoty.Text == "Clothing")
                category = GoodCategory.Clothing;
            else if (cbCategoty.Text == "Tools")
                category = GoodCategory.Tools;
            else if (cbCategoty.Text == "CigarettesOrAlcohool")
                category = GoodCategory.CigarettesOrAlcohol;
            else category = GoodCategory.Food;

            string description = rtbDescription.Text;

            Good good = new Good(name, price, category, description, checkBoxTaxable.Checked);

            addGood(good);

            MessageBox.Show("Good added succesfully");
            

          
        }

        private void tbGoodName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbGoodName.Text.Trim()) || tbGoodName.Text.Length < 3)
            {
                e.Cancel = true;
                errorProvider.SetError((Control)sender, "Please enter a valid name!");
            }
        }

        private void tbGoodName_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError((Control)sender, string.Empty);
        }

        private void rtbDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(rtbDescription.Text.Trim()) || rtbDescription.Text.Length < 3)
            {
                e.Cancel = true;
                errorProvider.SetError((Control)sender, "Please enter a valid description");
            }

        }

        private void rtbDescription_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError((Control)sender, string.Empty);
        }
    }
}
