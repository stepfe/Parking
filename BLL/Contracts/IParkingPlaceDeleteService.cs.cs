using System;
using System.Collections.Generic;
using System.Text;
using Parking.Domain.Models;
using Parking;
namespace BLL.Contracts
{
    public interface IParkingPlaceDeleteService
    {
        void DeleteParkingPlace(ParkingPlaceIdentityModel id);
    }
}
