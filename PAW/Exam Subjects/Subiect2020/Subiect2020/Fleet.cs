using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subiect2020
{
   public class Fleet
    {
        public List<Vehicle> vehicles;

        public Fleet()
        {
            vehicles = new List<Vehicle>();
        }
        

        public static Fleet operator+(Fleet fleet, Vehicle vehicle)
        {
            fleet.vehicles.Add(vehicle);
            return fleet;
        }

    }


}
