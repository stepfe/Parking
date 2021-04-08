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
    public class PersonCreateService : IPersonCreateService
    {
        private IPersonDataAccess PersonDataAccess { get; }
        private IPersonGetService PersonGetService { get; }


        public PersonCreateService(IPersonDataAccess personDataAccess, IPersonGetService personGetService)
        {
            this.PersonDataAccess = personDataAccess;
            this.PersonGetService = personGetService;
        }

        public Person CreatePerson(PersonUpdateModel person)
        {
            this.PersonGetService.ValidatePerson(person);
            return PersonDataAccess.Insert(person);
        }
    }
}
