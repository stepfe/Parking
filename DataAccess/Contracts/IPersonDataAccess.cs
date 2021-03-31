using System;
using System.Collections.Generic;
using System.Text;
using Parking.Domain.Models;
using Parking.Domain.Contracts;
namespace DataAccess.Contracts
{
    public interface IPersonDataAccess
    {
        Parking.Person Insert(PersonUpdateModel person);
        Parking.Person Get(PersonIdentityModel id);
        Parking.Person GetOwnerOfPlace(IPersonContainer placeId);
        Parking.Person Update(PersonIdentityModel id, PersonUpdateModel person);
    }
}
