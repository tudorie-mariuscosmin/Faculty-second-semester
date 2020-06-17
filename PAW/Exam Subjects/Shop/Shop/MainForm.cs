using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shop
{
    public partial class MainForm : Form
    {
        private List<Category> categories;
        private List<Product> products;
        private string connectionString = "Data Source=database.db";
        public MainForm()
        {
            categories = new List<Category>();
            products = new List<Product>();
            InitializeComponent();
        }

        private void LoadCategories()
        {
            using (StreamReader reader = File.OpenText("Categories.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var tokens = line.Split(',');
                    Category category = new Category(int.Parse(tokens[0]), tokens[1]);
                    categories.Add(category);
                }
            }
        }

        private void displayProducts()
        {
            dgvProducts.Rows.Clear();
            products.Sort();
            foreach(var product in products)
            {
                var category = categories.First(x => x.Id == product.CategoryId);
                int index = dgvProducts.Rows.Add(new object[]{
                    product.Id,
                    product.Name,
                    product.Units,
                    product.Price,
                    category.Name

                });
                dgvProducts.Rows[index].Tag = product;
            }
        }

        private void insertProduct(Product product)
        {
            string sql = "insert into products(name, units, price, categoryid) values(@name, @units, @price, @categoryId); select last_insert_rowid()";
            using(SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                var command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("@name", product.Name);
                command.Parameters.AddWithValue("@units", product.Units);
                command.Parameters.AddWithValue("@price", product.Price);
                command.Parameters.AddWithValue("@categoryId", product.CategoryId);
                connection.Open();
                long id = (long)command.ExecuteScalar();
                product.Id = id;
            }
        }

        private void loadProducts()
        {
            string querry = "Select * from products;";
            using(SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                var command = new SQLiteCommand(querry, connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        long id = (long)reader["id"];
                        string name = (string)reader["name"];
                        long units = (long)reader["units"];
                        double price = (double)reader["price"];
                        long categoryId = (long)reader["categoryId"];
                        Product product = new Product(id, name, units, price, categoryId);
                        products.Add(product);

                    }
                    
                }
            }
        }

        private void deleteProduct(Product product)
        {
            string sql = "Delete from products where id = @id";
            using(SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                var command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("@id", product.Id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void updateProduct(Product product)
        {
            string sql = "Update products set name = @name, price = @price, units = @units, categoryId = @categoryId where id = @id;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                var command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("@name", product.Name);
                command.Parameters.AddWithValue("@price", product.Price);
                command.Parameters.AddWithValue("@units", product.Units);
                command.Parameters.AddWithValue("@categoryId", product.CategoryId);
                command.Parameters.AddWithValue("@id", product.Id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadCategories();
            loadProducts();
            displayProducts();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            EditProductForm editProductForm = new EditProductForm(categories, product);
            if(editProductForm.ShowDialog()== DialogResult.OK)
            {
                insertProduct(product);
                products.Add(product);
                displayProducts();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 1)
            {
                Product product =(Product)dgvProducts.SelectedRows[0].Tag;
                deleteProduct(product);
                products.Remove(product);
                displayProducts();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 1)
            {
                Product product = (Product)dgvProducts.SelectedRows[0].Tag;
                EditProductForm editProductForm = new EditProductForm(categories, product);
                if(editProductForm.ShowDialog()== DialogResult.OK)
                {
                    updateProduct(product);
                    displayProducts();
                }
                
            }

        }

        private void computeCostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double sum = 0;
            foreach(Product product in products)
            {
                sum += (double)product;
                   
            }

            MessageBox.Show($"Total price is {sum}");
        }

        private void btnChart_Click(object sender, EventArgs e)
        {
            Chart chart = new Chart(products, categories);
            chart.Show();
        }
    }
}
