using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlyingKetchup.Models
{
    public class HolderObject
    {
        public string Flight { get; set; }
        public string SaleTotal { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string Carrier { get; set; }
        public string ArrivalTime { get; set; }
        public string DepartureTime { get; set; }
        public int? Duration { get; set; }
    }
}