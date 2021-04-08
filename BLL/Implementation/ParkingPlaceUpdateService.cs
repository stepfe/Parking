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
    public class ParkingPlaceUpdateService : IParkingPlaceUpdateService
    {
        private IParkingPlaceDataAccess ParkingPlaceDataAccess;

        public ParkingPlaceUpdateService(IParkingPlaceDataAccess parkingPlaceDataAccess)
        {
            this.ParkingPlaceDataAccess = parkingPlaceDataAccess;
        }
        public ParkingPlace UpdateParkingPlace(ParkingPlaceIdentityModel id, ParkingPlaceUpdateModel place)
        {
            return this.ParkingPlaceDataAccess.Update(id, place);
        }
    }
}
