using System;
using System.Collections.Generic;
using System.Text;
using Parking.Domain.Contracts;
namespace Parking.Domain.Models
{
    public class ParkingPlaceIdentityModel : IParkingPlaceIdentity
    {
        public int Id { get; }

        public ParkingPlaceIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}
