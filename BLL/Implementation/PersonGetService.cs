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
    public class PersonGetService : IPersonGetService
    {

        private IPersonDataAccess PersonDataAccess;

        public PersonGetService(IPersonDataAccess personDataAccess)
        {
            this.PersonDataAccess = personDataAccess;
        }

        public Person GetOwnerOfPlace(IPersonContainer container)
        {
            return PersonDataAccess.GetOwnerOfPlace(container);
        }

        public Person GetPerson(PersonIdentityModel id)
        {
            return PersonDataAccess.Get(id);
        }

        public void ValidatePerson(PersonUpdateModel person)
        {
            if(person.PhoneNumber.Length != 11)
            {
                throw new ArgumentException("Wrong phone format");
            }
        }
    }
}
