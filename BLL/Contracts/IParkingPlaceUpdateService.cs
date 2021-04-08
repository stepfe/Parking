using System;
using System.Collections.Generic;
using System.Text;
using Parking;
using Parking.Domain.Models;
namespace BLL.Contracts
{
    public interface IParkingPlaceUpdateService
    {
        ParkingPlace UpdateParkingPlace(ParkingPlaceIdentityModel id, ParkingPlaceUpdateModel place);
    }
}
