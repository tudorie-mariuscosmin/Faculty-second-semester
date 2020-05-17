using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SupplyBusiness.Classes
{
    [Serializable]
   public class Supplier
    {
        public string SupplierName { get; set; }
        
        public List<Good> Goods { get; set; }
        public int InregistrationNumber { get; set; }
        public string BankAccount { get; set; }
        public string HeadquartersAdress { get; set; }
        public string PhoneNumber { get; set; }
        public string RepresantativeEmploye { get; set; }

        public Supplier() { }
        public Supplier(string supplierName, int inregistrationNumber, string bankAccount, string headquartersAdress, string represantativeEmploye, string phoneNumber)
        {
            Goods = new List<Good>();
            SupplierName = supplierName;
            InregistrationNumber = inregistrationNumber;
            BankAccount = bankAccount;
            HeadquartersAdress = headquartersAdress;
            RepresantativeEmploye = represantativeEmploye;
            PhoneNumber = phoneNumber;
        }


        public void AddGood(Good good)
        {
            Goods.Add(good);
        }

        public override string ToString()
        {
            return SupplierName;
        }
    }
}
