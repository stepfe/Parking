using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Entities;
using Parking;
using Parking.Domain.Models;
using WebAPI.Client.DTO;

namespace WebAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Parking.Person, DataAccess.Entities.Person>().ReverseMap();
            CreateMap<PersonUpdateModel, DataAccess.Entities.Person>().ReverseMap();
            CreateMap<PersonDTO, PersonUpdateModel>().ReverseMap();
            CreateMap<Parking.Person, PersonDTO>().ReverseMap();
            CreateMap<Parking.ParkingPlace, DataAccess.Entities.ParkingPlace>().ReverseMap();
            CreateMap<ParkingPlaceUpdateModel, DataAccess.Entities.ParkingPlace>().ReverseMap();
            CreateMap<ParkingPlaceDTO, ParkingPlaceUpdateModel>().ReverseMap();
            CreateMap<Parking.ParkingPlace, ParkingPlaceDTO>().ReverseMap();
        }
    }
}
