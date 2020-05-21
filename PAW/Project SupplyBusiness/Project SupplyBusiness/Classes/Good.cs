using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SupplyBusiness.Classes
{
    public enum GoodCategory
    {
        Food,
        Electronics,
        Furniture,
        Pharmaceutical,
        OfficeSupplies,
        Clothing,
        Tools,
        CigarettesOrAlcohol

    }
    [Serializable]
   public class Good
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public GoodCategory Category { get; set; }
        public string Description { get; set; }
        public bool Taxable { get; set; }
        private double tax;
        public double Tax { get { return tax; } }


        public Good() { }
        public Good(string name, double price, GoodCategory category, string description, bool taxable)
        {
            Name = name;
            Price = price;
            Category = category;
            Description = description;
            Taxable = taxable;

            if (this.Taxable == true)
            {
                if (Category == GoodCategory.Food || Category == GoodCategory.Pharmaceutical || Category == GoodCategory.Clothing)
                    tax = Price * 0.05;
                else if (Category == GoodCategory.Electronics || Category == GoodCategory.Furniture || Category == GoodCategory.OfficeSupplies || Category == GoodCategory.Tools)
                    tax = Price * 0.09;
                else if (Category == GoodCategory.CigarettesOrAlcohol)
                    tax = Price * 1.19;
            }
            else
            {
                tax = 0;
            }
        }
        public Good( long id, string name, double price, GoodCategory category, string description, bool taxable)
            :this(name, price, category, description, taxable)
        {
            Id = id;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(Name);
            builder.Append(": price- ");
            builder.Append(Price);
            builder.Append(" (");
            builder.Append(Description);
            builder.Append(")");
            return builder.ToString();
        }
    }
}
