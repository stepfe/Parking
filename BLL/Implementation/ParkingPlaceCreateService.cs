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
    public class ParkingPlaceCreateService : IParkingPlaceCreateService
    {

        private IParkingPlaceDataAccess ParkingPlaceDataAccess;

        public ParkingPlaceCreateService(IParkingPlaceDataAccess parkingPlaceDataAccess)
        {
            this.ParkingPlaceDataAccess = parkingPlaceDataAccess;
        }

        public ParkingPlace CreateParkingPlace(ParkingPlaceUpdateModel place)
        {
            return this.ParkingPlaceDataAccess.Insert(place);
        }
    }
}
