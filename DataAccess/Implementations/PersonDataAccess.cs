using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Context;
using DataAccess.Contracts;
using DataAccess.Entities;
using Parking.Domain.Contracts;
using Parking.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AutoMapper;

namespace DataAccess.Implementations
{
    public class PersonDataAccess : IPersonDataAccess
    {
        private ApplicationContext ApplicationContext { get; }
        private IMapper Mapper { get; }

        public PersonDataAccess(ApplicationContext context, IMapper mapper)
        {
            this.ApplicationContext = context;
            this.Mapper = mapper;

            context.Database.EnsureCreated();
        }

        public Parking.Person Insert(PersonUpdateModel person)
        {
            var result = this.ApplicationContext.Add(this.Mapper.Map<DataAccess.Entities.Person>(person));

            this.ApplicationContext.SaveChanges();

            Parking.Person res = new Parking.Person { Id = result.Entity.Id };

            this.Mapper.Map(result.Entity, res);

            return res;
        }

        public Parking.Person Get(PersonIdentityModel id)
        {
            var result = this.ApplicationContext.Person.Where(u => u.Id == id.Id).First();

            return this.Mapper.Map<Parking.Person>(result);
        }

        public Parking.Person Update(PersonIdentityModel id, PersonUpdateModel person)
        {
            var existing = this.ApplicationContext.Person.Where(u => u.Id == id.Id).First();

            var result = this.Mapper.Map(person, existing);

            this.ApplicationContext.Update(result);

            this.ApplicationContext.SaveChanges();

            return this.Mapper.Map<Parking.Person>(result);
        }

        public Parking.Person GetOwnerOfPlace(IPersonContainer placeId)
        {
            var result = this.ApplicationContext.Person.Where(u => u.Id == placeId.PersonId).First();

            return this.Mapper.Map<Parking.Person>(result);
        }

        public void Delete(PersonIdentityModel id)
        {
            var personToDelete = this.ApplicationContext.Person.Where(p => p.Id == id.Id).First();

            this.ApplicationContext.Attach(personToDelete);
            this.ApplicationContext.Remove(personToDelete);

            this.ApplicationContext.SaveChanges();
        }
    }
}
