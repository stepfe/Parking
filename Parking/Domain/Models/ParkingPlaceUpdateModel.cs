using System;
using System.Collections.Generic;
using System.Text;
using Parking.Domain.Contracts;
namespace Parking.Domain.Models
{
    public class ParkingPlaceUpdateModel : IPersonContainer, IParkingPlaceIdentity
    {
        public int Id { get; set; }
        public int Flor { get; set; }
        public int Number { get; set; }
        public string Auto { get; set; }
        public int? PersonId { get; set; }

    }
}
