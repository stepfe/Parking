using System;
using System.Collections.Generic;
using System.Text;
using Parking;
using Parking.Domain.Models;

namespace BLL.Contracts
{
    public interface IParkingPlaceCreateService
    {
        ParkingPlace CreateParkingPlace(ParkingPlaceUpdateModel place);
    }
}
