using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevConfrence
{
   public class AccessPackage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public AccessPackage(int id, string name, double price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return Name + " : " + Price;
        }
    }
}
