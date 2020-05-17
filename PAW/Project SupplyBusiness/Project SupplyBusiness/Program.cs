using Project_SupplyBusiness.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_SupplyBusiness
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Good good = new Good("Telefon", 1200.03, GoodCategory.Electronics, "you can call people with it", true);
            //Good good2 = new Good("Paine", 5.5, GoodCategory.Food, "sustenance", false);
            //Good good3 = new Good("birou", 5.5, GoodCategory.Furniture, "big and hard", true);

            //Supplier supplier = new Supplier("Samsung", 112112, "ro65765", "str.Marasesti 35", "Tudorie Marius", "0757668697");
            //Supplier supplier2 = new Supplier("supplier", 112112342, "ro6576255", "str.Marasesti 35", "nume nume", "0757668697");

            //supplier.AddGood(good);
            //supplier.AddGood(good2);
            //supplier2.AddGood(good3);

            //Contract contract = new Contract("Teo", "07587456987", "vda579813", supplier, 1, 20);
            //Contract contract2 = new Contract("laala", "07587456987", "vda579813", supplier2, 0, 100);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
