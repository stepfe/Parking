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
    public class ParkingPlaceDataAccess : IParkingPlaceDataAccess
    {
        private ApplicationContext ApplicationContext { get; }
        private IMapper Mapper { get; }

        public ParkingPlaceDataAccess(ApplicationContext context, IMapper mapper)
        {
            this.ApplicationContext = context;
            this.Mapper = mapper;

            context.Database.EnsureCreated();
        }

        public Parking.ParkingPlace Insert(ParkingPlaceUpdateModel place)
        {
            var result = this.ApplicationContext.Add(this.Mapper.Map<DataAccess.Entities.ParkingPlace>(place));

            this.ApplicationContext.SaveChanges();

            Parking.ParkingPlace res = new Parking.ParkingPlace { Id = result.Entity.Id };

            this.Mapper.Map(result.Entity, res);

            return res;
        }

        public Parking.ParkingPlace Get(ParkingPlaceIdentityModel id)
        {
            var result = this.ApplicationContext.ParkingPlaces.Where(p => p.Id == id.Id).First();

            return this.Mapper.Map<Parking.ParkingPlace>(result);
        }

        public Parking.ParkingPlace Update(ParkingPlaceIdentityModel id, ParkingPlaceUpdateModel place)
        {
            var existing = this.ApplicationContext.ParkingPlaces.Where(p => p.Id == id.Id).First();

            var result = this.Mapper.Map(place, existing);

            this.ApplicationContext.Update(result);

            this.ApplicationContext.SaveChanges();

            return this.Mapper.Map<Parking.ParkingPlace>(result);
        }

        public List<Parking.ParkingPlace> GetPersonPlaces(PersonIdentityModel id)
        {
            return this.ApplicationContext.ParkingPlaces.Where(place => place.PersonId == id.Id).ToList().Select(x => this.Mapper.Map<Parking.ParkingPlace>(x)).ToList();
        }

        public void Delete(ParkingPlaceIdentityModel id)
        {
            var placeToDelete = this.ApplicationContext.ParkingPlaces.Where(p => p.Id == id.Id).First();

            this.ApplicationContext.Attach(placeToDelete);
            this.ApplicationContext.Remove(placeToDelete);

            this.ApplicationContext.SaveChanges();
        }
    }
}
