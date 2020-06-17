using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class Product:IComparable<Product>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long Units { get; set; }
        public double Price { get; set; }
        public long CategoryId { get; set; }

        public Product() { }
        public Product(long id, string name, long units, double price, long categoryId)
        {
            Id = id;
            Name = name;
            Units = units;
            Price = price;
            CategoryId = categoryId;
        }

        public static explicit operator double(Product product)
        {

            return product.Price * product.Units;
        }

        public int CompareTo(Product other)
        {
            return Name.CompareTo(other.Name);
        }
    }
}
