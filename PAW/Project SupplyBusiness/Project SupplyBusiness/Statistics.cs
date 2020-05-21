using Controls_Library;
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
    public partial class Statistics : Form
    {
        private BindingList<Contract> contracts;
        private double totalRevenues = 200;

        public Statistics(BindingList<Contract> contracts)
        {
            InitializeComponent();
            this.contracts = contracts;
        }

        private void Statistics_Load(object sender, EventArgs e)
        {
            
            int[] scores = new int[8];
            for(int i=0; i<contracts.Count; i++)
            {
                totalRevenues += contracts[i].totalPrice;
                int cat = (int)contracts[i].orderedGood.Category;
                switch (cat)
                {
                    case 0:
                        scores[0]++;
                        break;
                    case 1:
                        scores[1]++;
                        break;
                    case 2:
                        scores[2]++;
                        break;
                    case 3:
                        scores[3]++;
                        break;
                    case 4:
                        scores[4]++;
                        break;
                    case 5:
                        scores[5]++;
                        break;
                    case 6:
                        scores[6]++;
                        break;
                    case 7:
                        scores[7]++;
                        break;
                        
                }
     
           
            }








            var data = new BarChartValues[]
            {
                new BarChartValues("Food", scores[0]),
                new BarChartValues("Electronics", scores[1]),
                new BarChartValues("Furniture", scores[2]),
                new BarChartValues("Pharmaceutical", scores[3]),
                new BarChartValues("OfficeSupplies", scores[4]),
                new BarChartValues("Clothing", scores[5]),
                new BarChartValues("Tools", scores[6]),
                new BarChartValues("CigarettesOrAlcohol", scores[7]),
            };
            
            barChart.Data = data;
            userControl.MoneyAmount = totalRevenues;
            label2.Text = totalRevenues.ToString();
        }

        
    }
}
