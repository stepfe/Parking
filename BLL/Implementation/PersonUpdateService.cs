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
    public class PersonUpdateService : IPersonUpdateService
    {

        private IPersonDataAccess PersonDataAccess { get; }
        private IPersonGetService PersonGetService { get; }

        public PersonUpdateService(IPersonDataAccess personDataAccess, IPersonGetService personGetService)
        {
            this.PersonDataAccess = personDataAccess;
            this.PersonGetService = personGetService;
        }

        public Person UpdatePerson(PersonIdentityModel id, PersonUpdateModel person)
        {
            PersonGetService.ValidatePerson(person);
            return this.PersonDataAccess.Update(id, person);
        }
    }
}
