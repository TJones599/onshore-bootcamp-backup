using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datastructure.Models
{
    public class Plane
    {
        public Plane(decimal wingspan)
        {
            this.wingspan = wingspan;
        }


        public decimal wingspan { get; set; }

        public int PassengerCapactiy { get; set; }

        public int FuelCapacity { get; set; }

        public int FuelLevel { get; set; }

        public string PlaneModel { get; set; }

        public int MaxAltitude { get; set; }

        public int MaxCarryWeight { get; set; }

    }
}
