using System;
using System.Collections.Generic;
using System.Text;
using Parking;
using Parking.Domain.Models;
using Parking.Domain.Contracts;

namespace BLL.Contracts
{
    public interface IPersonGetService
    {
        Person GetPerson(PersonIdentityModel id);
        Person GetOwnerOfPlace(IPersonContainer container);
        public void ValidatePerson(PersonUpdateModel person);
    }
}
