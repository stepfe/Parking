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
    public class PersonDeleteService : IPersonDeleteService
    {

        private IPersonDataAccess PersonDataAccess;

        public PersonDeleteService(IPersonDataAccess personDataAccess)
        {
            this.PersonDataAccess = personDataAccess;
        }
        public void DeletePerson(PersonIdentityModel id)
        {
            this.PersonDataAccess.Delete(id);
        }
    }
}
