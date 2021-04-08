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
    public class ParkingPlaceDeleteService : IParkingPlaceDeleteService
    {

        private IParkingPlaceDataAccess ParkingPlaceDataAccess;

        public ParkingPlaceDeleteService(IParkingPlaceDataAccess parkingPlacelaceDataAccess)
        {
            this.ParkingPlaceDataAccess = parkingPlacelaceDataAccess;
        }
        public void DeleteParkingPlace(ParkingPlaceIdentityModel id)
        {
            this.ParkingPlaceDataAccess.Delete(id);
        }
    }
}
