using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Contracts;
using Parking.Domain.Contracts;
using Parking.Domain.Models;
using Parking;
using BLL.Contracts;

namespace BLL.Implementation
{
    public class ParkingPlaceGetService : IParkingPlaceGetService
    {
        private IParkingPlaceDataAccess ParkingPlaceDataAccess;

        public ParkingPlaceGetService(IParkingPlaceDataAccess parkingPlaceDataAccess)
        {
            this.ParkingPlaceDataAccess = parkingPlaceDataAccess;
        }

        public ParkingPlace Get(ParkingPlaceIdentityModel id)
        {
            return this.ParkingPlaceDataAccess.Get(id);
        }

        public List<ParkingPlace> GetPersonsPlaces(PersonIdentityModel personId)
        {
            return this.ParkingPlaceDataAccess.GetPersonPlaces(personId);
        }
    }
}
