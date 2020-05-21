using Project_SupplyBusiness.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Project_SupplyBusiness
{
    public partial class MainForm : Form
    {
        private string connectionString = "Data source=database.db";
        private List<Supplier> suppliers;
        private BindingList<Contract> contracts; 
        public MainForm()
        {
            InitializeComponent();
            suppliers = new List<Supplier>();
            contracts = new BindingList<Contract>();
        }
        #region methods
        private void displaySupplers()
        {
            treeViewSuppliers.Nodes.Clear();
            int i = 0;
            foreach(var suppier in suppliers)
            {
                treeViewSuppliers.Nodes.Add(suppier.SupplierName);
                int j = 0;
                foreach(Good good in suppier.Goods)
                {
                    treeViewSuppliers.Nodes[i].Nodes.Add(good.ToString());
                    treeViewSuppliers.Nodes[i].Nodes[j].Tag = suppier;
                    j++;
                }
                i++;
            }
        }


        private void CreateContract(Contract contract)
        {
            string sql = "INSERT INTO contract(c_name, c_phone, c_bank, supplier_id, good_id, no_goods, c_date) VALUES(@name, @phone, @bank,@supplier_id,@g_id, @noGoods, @date);" +
                "SELECT last_insert_rowid();";

            SQLiteConnection connection = new SQLiteConnection(connectionString);
            using(SQLiteCommand command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@name", contract.ClientName);
                command.Parameters.AddWithValue("@phone", contract.ClientPhoneNumber);
                command.Parameters.AddWithValue("@bank", contract.ClientBank);
                command.Parameters.AddWithValue("@bank", contract.ClientBank);
                command.Parameters.AddWithValue("@supplier_id", contract.Supplier.Id);
                command.Parameters.AddWithValue("@g_id", contract.orderedGood.Id);
                command.Parameters.AddWithValue("@noGoods", contract.NoGoods);
                command.Parameters.AddWithValue("@date", contract.Date);

                connection.Open();
                long id = (long)command.ExecuteScalar();
                contract.ContractNo = id;
                contracts.Add(contract);

            }

        }

        private void loadContracts()
        {
            string querry = "SELECT * FROM contract c JOIN supplier s on  c.supplier_id=s.id join good g on c.good_id = g.g_id; ";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            using (SQLiteCommand command = new SQLiteCommand(querry, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        long c_id = (long)reader["c_id"];
                        string c_name = (string)reader["c_name"];
                        string c_phone = (string)reader["c_phone"];
                        string c_bank = (string)reader["c_bank"];
                        int noGoods =Convert.ToInt32(reader["no_goods"]);
                        DateTime c_date = DateTime.Parse(reader["c_date"].ToString());


                        string s_name = (string)reader["s_name"];
                        int s_inregistration = Convert.ToInt32(reader["s_inregistration"]);
                        string s_bank = (string)reader["s_bank"];
                        string s_headquaters = (string)reader["headquaters"];
                        string s_phone = (string)reader["s_phone"];
                        string s_employee = (string)reader["employee"];

                        string g_name = (string)reader["g_name"];
                        double g_price = Convert.ToDouble(reader["g_price"]);
                        string g_description = (string)reader["g_description"];
                        bool g_taxable = bool.Parse(reader["taxable"].ToString());
                        GoodCategory g_category = (GoodCategory)Convert.ToInt32(reader["category"]);

                        Supplier supplier = new Supplier(s_name, s_inregistration, s_bank, s_headquaters, s_employee, s_phone);
                        Good good = new Good(g_name, g_price, g_category, g_description, g_taxable);
                        Contract contract = new Contract(c_id, c_name, c_phone, c_bank, supplier, noGoods, good, c_date);


                        contracts.Add(contract);



                    }
                }
            }
        }

        private void LoadSuppliers()
        {
            string querry = "SELECT * FROM supplier";
            SQLiteConnection connection = new SQLiteConnection(connectionString);

            using (SQLiteCommand command = new SQLiteCommand(querry, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        long id = (long)reader["id"];
                        string s_name = (string)reader["s_name"];
                        int inregistration = Convert.ToInt32(reader["s_inregistration"]);
                        string bank = (string)reader["s_bank"];
                        string headquaters = (string)reader["headquaters"];
                        string phone = (string)reader["s_phone"];
                        string employee = (string)reader["employee"];
                        Supplier supplier = new Supplier(id, s_name, inregistration, bank, headquaters, employee, phone);
                       
                        string goodsQuerry = $"Select * from good where supplier_id={id}";
                        using(SQLiteCommand goodCommand = new SQLiteCommand(goodsQuerry, connection))
                        {
                            using(var goodReader = goodCommand.ExecuteReader())
                            {
                                while (goodReader.Read())
                                {
                                    long g_id = (long)goodReader["g_id"];
                                    string g_name = (string)goodReader["g_name"];
                                    double price = Convert.ToDouble(goodReader["g_price"]);
                                    string description = (string)goodReader["g_description"];
                                    bool taxable = bool.Parse(goodReader["taxable"].ToString());
                                    GoodCategory category = (GoodCategory)Convert.ToInt32(goodReader["category"]);
                                    Good good = new Good(g_id, g_name, price, category, description, taxable);
                                    supplier.AddGood(good);
                                }
                            }
                        }
                        
                        suppliers.Add(supplier);

                    }
                }
            }

        }
        #endregion
        #region events
        private void suppliersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SuppliersForm suppliersForm = new SuppliersForm(suppliers);
            suppliersForm.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = contracts;
            LoadSuppliers();
            loadContracts();
        }

       

        private void tabPage1_Click(object sender, EventArgs e)
        {
            displaySupplers();
        }

        private void btnAddContract_Click(object sender, EventArgs e)
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
            string name = tbClientName.Text;
            string bank = tbBankAccount.Text;
            string phone = tbPhone.Text;
            int noGoods =(int)numericUpDown1.Value;

            Supplier supplier = null;
            int goodIndex = 0;

            if (treeViewSuppliers.SelectedNode == null )
            {
                MessageBox.Show("Please select a good", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                supplier = (Supplier)treeViewSuppliers.SelectedNode.Tag;
                 goodIndex = treeViewSuppliers.SelectedNode.Index;
            }
            

            Contract contract = new Contract(name, phone, bank, supplier, goodIndex, noGoods);
            CreateContract(contract);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            displaySupplers();
        }

        private void btnBinarySerialization_Click(object sender, EventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using( FileStream suppliersStream = File.Create("binaries/suppliers.bin"))
            {
                formatter.Serialize(suppliersStream, suppliers);
            }
            using(FileStream contractStream = File.Create("binaries/contracts.bin"))
            {
                formatter.Serialize(contractStream, contracts);
            }


        }

        private void btnBinaryDeserialization_Click(object sender, EventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using(FileStream supStream = File.OpenRead("binaries/suppliers.bin"))
            {
                suppliers = (List<Supplier>)formatter.Deserialize(supStream);
                displaySupplers();
            }
            using(FileStream contStream = File.OpenRead("binaries/contracts.bin"))
            {
                contracts = (BindingList<Contract>) formatter.Deserialize(contStream);
                dataGridView1.DataSource = contracts;
            }
        }

        private void btnXMLSerialization_Click(object sender, EventArgs e)
        {
            XmlSerializer serializerSupplier = new XmlSerializer(typeof(List<Supplier>));
            using(FileStream supStream = File.Create("XML/suppliers.xml"))
            {
                serializerSupplier.Serialize(supStream, suppliers);
            }

            XmlSerializer serializerContract = new XmlSerializer(typeof(BindingList<Contract>));
            using (FileStream contrStream = File.Create("XML/contracts.xml"))
            {
                serializerContract.Serialize(contrStream, contracts);
            }


        }

        private void btnXMLDeserialization_Click(object sender, EventArgs e)
        {
            XmlSerializer serializerSupplier = new XmlSerializer(typeof(List<Supplier>));
            using (FileStream supStream = File.OpenRead("XML/suppliers.xml"))
            {
              suppliers = (List<Supplier>)serializerSupplier.Deserialize(supStream);
              displaySupplers();

            }

            XmlSerializer serializerContract = new XmlSerializer(typeof(BindingList<Contract>));
            using (FileStream contrStream = File.OpenRead("XML/contracts.xml"))
            {
                contracts= (BindingList<Contract>) serializerContract.Deserialize(contrStream);
                dataGridView1.DataSource = contracts;

            }

        }
        private void exportCsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Save file as";
            dialog.Filter = "CSV file| *.csv";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(dialog.FileName))
                {
                    writer.WriteLine("Contract No.,Client Name,Client Phone,Client Bank,Supplier Name, Supplier Inregistration No.,Supplier Bank,Headquaters Adress,Representative Employee,Supplier Phone,Good,Price/unit,Category,Description,Total(without tax),Tax,Total(with tax),Date");
                    foreach (Contract contract in contracts)
                    {
                        if (contract.Supplier != null)
                        {
                            writer.WriteLine($"{contract.ContractNo},{contract.ClientName},{contract.ClientPhoneNumber},{contract.ClientBank},{contract.Supplier.SupplierName},{contract.Supplier.InregistrationNumber},{contract.Supplier.BankAccount},{contract.Supplier.HeadquartersAdress},{contract.Supplier.RepresantativeEmploye},{contract.Supplier.PhoneNumber},{contract.orderedGood.Name},{contract.orderedGood.Price},{contract.orderedGood.Category},{contract.orderedGood.Description},{contract.totalGoods},{contract.totalTax},{contract.totalPrice},{contract.Date}");
                        }
                    }

                }


            }
        }
        private void exporttxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Save text report as";
            dialog.Filter = "Text File | *.txt";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(dialog.FileName))
                {
                    writer.WriteLine($"Report from the date:{DateTime.Now}");
                    writer.WriteLine();
                    writer.WriteLine("-------------------------------------------------------------------------");
                    foreach (var contract in contracts)
                    {
                        writer.WriteLine($"Contract No: {contract.ContractNo}");
                        writer.WriteLine($"Client Name: {contract.ClientName}");
                        writer.WriteLine($"Client Phone: {contract.ClientPhoneNumber}");
                        writer.WriteLine($"Client Bank: {contract.ClientBank}");
                        writer.WriteLine($"Supplier Name: {contract.Supplier.SupplierName}");
                        writer.WriteLine($"Supplier Inreistration No: {contract.Supplier.InregistrationNumber}");
                        writer.WriteLine($"Supplier Bank: {contract.Supplier.BankAccount}");
                        writer.WriteLine($"Supplier Headquaters: {contract.Supplier.HeadquartersAdress}");
                        writer.WriteLine($"Representative Employee: {contract.Supplier.RepresantativeEmploye}");
                        writer.WriteLine($"Supplier Phone: {contract.Supplier.PhoneNumber}");
                        writer.WriteLine($"Good: {contract.orderedGood.Name}");
                        writer.WriteLine($"Price/unit: {contract.orderedGood.Price}");
                        writer.WriteLine($"Category: {contract.orderedGood.Category}");
                        writer.WriteLine($"Description: {contract.orderedGood.Description}");
                        writer.WriteLine($"Total(without tax): {contract.totalGoods}");
                        writer.WriteLine($"Tax: {contract.totalTax}");
                        writer.WriteLine($"Total(with tax): {contract.totalPrice}");
                        writer.WriteLine($"Date(with tax): {contract.Date}");
                        writer.WriteLine($"-------------------------------------------------------------------------");
                    }
                }
            }
        }
        #endregion
        #region validations
        private void tbClientName_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(tbClientName.Text.Trim()) || tbClientName.Text.Length < 3)
            {
                e.Cancel = true;
                errorProvider1.SetError((Control)sender, "Enter a valid name!");

            }
        }

        private void tbClientName_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError((Control)sender, string.Empty);
        }

        private void tbBankAccount_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace( tbBankAccount.Text.Trim()) || tbBankAccount.Text.Length != 16)
            {
                e.Cancel = true;
                errorProvider1.SetError((Control)sender, "Please enter a valid 16 digit bank account!");
            }
        }

        private void tbBankAccount_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError((Control)sender, string.Empty);
        }

        private void tbPhone_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbPhone.Text.Trim()) || tbPhone.Text.Length != 10)
            {
                e.Cancel = true;
                errorProvider1.SetError((Control)sender, "Please enter a valid phone number!");
            }
        }

        private void tbPhone_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError((Control)sender, string.Empty);
        }

        private void tbPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && Keys.Back != (Keys)e.KeyChar)
            {
                e.Handled = true;
            }
        }


        #endregion

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SuppliersForm suppliersForm = new SuppliersForm(suppliers);
            suppliersForm.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Statistics form = new Statistics(contracts);
            form.Show();
        }
    }
}
