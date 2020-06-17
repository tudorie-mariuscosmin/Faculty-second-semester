using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shop
{
    public partial class EditProductForm : Form
    {
        private List<Category> categories;
        private Product product;
        public EditProductForm(List<Category> categories, Product product)
        {
            this.categories = categories;
            this.product = product;
            InitializeComponent();
        }

        private void EditProductForm_Load(object sender, EventArgs e)
        {
            cbCategories.DataSource = categories;

            tbName.Text = product.Name;
            noUnits.Value = product.Units;
            noPrice.Value =(decimal) product.Price;
            Category selectedCategory = categories.FirstOrDefault(x => product.CategoryId == x.Id);
            cbCategories.SelectedItem = selectedCategory;

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            product.Name = tbName.Text;
            product.Units =(long)noUnits.Value;
            product.Price = (double)noPrice.Value;
            var category = (Category)cbCategories.SelectedValue;
            product.CategoryId = category.Id;

        }
    }
}
