using System;
using AutoMapper;
using DataAccess.Context;
using DataAccess.Entities;
using DataAccess.Implementations;
using Parking.Domain.Models;
namespace BLL
{
    class Program
    {
        static void Main(string[] args)
        {
            var mapperConfig = new MapperConfiguration(cfg => {
                cfg.CreateMap<Parking.Domain.Models.PersonUpdateModel, DataAccess.Entities.Person>();
                cfg.CreateMap<Parking.Domain.Models.PersonUpdateModel, Parking.Person>();
                cfg.CreateMap<DataAccess.Entities.Person, Parking.Person>();
                cfg.CreateMap<Parking.Person, DataAccess.Entities.Person>();
                cfg.CreateMap<Parking.Domain.Models.ParkingPlaceUpdateModel, DataAccess.Entities.ParkingPlace>();
                cfg.CreateMap<Parking.Domain.Models.ParkingPlaceUpdateModel, Parking.ParkingPlace>();
                cfg.CreateMap<DataAccess.Entities.ParkingPlace, Parking.ParkingPlace>();
                cfg.CreateMap<Parking.ParkingPlace, DataAccess.Entities.ParkingPlace>();
            });
            Mapper mapper = new Mapper(mapperConfig);

            var context = new ApplicationContext();

            PersonDataAccess personDataAccess = new PersonDataAccess(context, mapper);

            Parking.Person person = personDataAccess.Insert(new PersonUpdateModel { Email = "123@456.ru", PhoneNumber = "9500492805", Name = "Rakan" });

            Console.WriteLine("Created User:");
            Console.WriteLine(person);

            Console.WriteLine("\nGet User From Database:");
            Console.WriteLine(personDataAccess.Get(new PersonIdentityModel(1)).Name);

            Parking.Person updatedPerson = personDataAccess.Update(
                new PersonIdentityModel(1),
                new PersonUpdateModel { Email = "132@456.ru", PhoneNumber = "89500492805", Name = "Xayah" }
            );

            Console.WriteLine("\nUpdated User:");
            Console.WriteLine(updatedPerson.Id);

            ParkingPlaceDataAccess parkingPlaceDataAccess = new ParkingPlaceDataAccess(context, mapper);

            Parking.ParkingPlace place = parkingPlaceDataAccess.Insert(new ParkingPlaceUpdateModel { PersonId = updatedPerson.Id, Flor = 1, Number = 1, Auto = "Best" });

            Console.WriteLine("\nCreated Note:");
            Console.WriteLine(place);

            Console.WriteLine("\nGet Note From Database:");
            Console.WriteLine(parkingPlaceDataAccess.Get(new ParkingPlaceIdentityModel(1)));

            Parking.ParkingPlace updatedPlace = parkingPlaceDataAccess.Update(
                new ParkingPlaceIdentityModel(1),
                new ParkingPlaceUpdateModel { Flor = 2, Number = 2, PersonId = 1 }
            );

            Console.WriteLine("\nUpdated Note:");
            Console.WriteLine(parkingPlaceDataAccess.Get(new ParkingPlaceIdentityModel(1)));

            Console.WriteLine("\nGet User Notes:");
            parkingPlaceDataAccess.GetPersonPlaces(new PersonIdentityModel(1)).ForEach(Console.WriteLine);

            Console.WriteLine("\nGet User Notes From User Class:");
            personDataAccess.Get(new PersonIdentityModel(1)).Places.ForEach(Console.WriteLine);

            parkingPlaceDataAccess.Delete(new ParkingPlaceIdentityModel(1));
            personDataAccess.Delete(new PersonIdentityModel(1));
        }
    }
}
