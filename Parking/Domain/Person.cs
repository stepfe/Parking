using System;
using System.Collections.Generic;
using System.Text;

namespace Parking
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public List<ParkingPlace> Places { get; } = new List<ParkingPlace>();
    }
}
