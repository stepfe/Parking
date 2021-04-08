using System;
using System.Collections.Generic;
using System.Text;
using Parking;
using Parking.Domain.Models;
namespace BLL.Contracts
{
    public interface IPersonUpdateService
    {
        Person UpdatePerson(PersonIdentityModel id, PersonUpdateModel person);
    }
}
