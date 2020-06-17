using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subiect2020
{
    [Serializable]
   public class Vehicle
    {
        public string Maker { get; set; }
        public string Model { get; set; }
        public int Capacity { get; set; }
        public int HorsePower { get; set; }

        public Vehicle(string maker, string model, int capacity, int horsePower)
        {
            Maker = maker;
            Model = model;
            Capacity = capacity;
            HorsePower = horsePower;
        }
        public Vehicle() { }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(Maker);
            builder.Append(" : ");
            builder.Append(Model);
            builder.Append("(");
            builder.Append(Capacity);
            builder.Append(", ");
            builder.Append(HorsePower);
            builder.Append(" hp)");
            return builder.ToString();

        }
    }
}
