using System;
using System.Collections.Generic;
using System.Text;

namespace Parking
{
    public class ParkingPlace
    {
        public int Id { get; set; }
        public int Flor { get; set; }
        public int Number { get; set; }
        public string Auto { get; set; }
        public Person Owner { get; set; }
    }
}
