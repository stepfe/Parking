using System;
using System.Collections.Generic;
using System.Text;
using Parking.Domain.Models;

namespace DataAccess.Contracts
{
    public interface IParkingPlaceDataAccess
    {
        Parking.ParkingPlace Insert(ParkingPlaceUpdateModel place);
        Parking.ParkingPlace Get(ParkingPlaceIdentityModel id);
        IEnumerable<Parking.ParkingPlace> GetPersonPlaces(PersonIdentityModel id);
        Parking.ParkingPlace Update(ParkingPlaceIdentityModel id, ParkingPlaceUpdateModel place);

    }
}
