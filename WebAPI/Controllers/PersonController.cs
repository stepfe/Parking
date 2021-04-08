using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoMapper;

using WebAPI.Client.DTO;
using BLL.Contracts;
using Parking;
using Parking.Domain.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;

        private IMapper Mapper { get; }
        private IPersonCreateService PersonCreateService { get; }
        private IPersonGetService PersonGetService { get; }
        private IPersonUpdateService PersonUpdateService { get; }
        private IPersonDeleteService PersonDeleteService { get; }

        private IParkingPlaceCreateService PlaceCreateService { get; }
        private IParkingPlaceGetService PlaceGetService { get; }

        public PersonController(ILogger<PersonController> logger, IMapper mapper, IPersonCreateService personCreateService, IPersonGetService personGetService, IPersonUpdateService personUpdateService, IPersonDeleteService personDeleteService, IParkingPlaceGetService placeGetService, IParkingPlaceCreateService placeCreateService)
        {
            _logger = logger;

            this.Mapper = mapper;
            this.PersonCreateService = personCreateService;
            this.PersonGetService = personGetService;
            this.PersonUpdateService = personUpdateService;
            this.PersonDeleteService = personDeleteService;

            this.PlaceCreateService = placeCreateService;
            this.PlaceGetService = placeGetService;
        }

        [HttpPost]
        public PersonDTO CreatePerson(PersonDTO person)
        {
            var updateModel = Mapper.Map<PersonUpdateModel>(person);

            PersonGetService.ValidatePerson(updateModel);
            Person res = PersonCreateService.CreatePerson(updateModel);

            return Mapper.Map<PersonDTO>(res);
        }

        [HttpPost("{id}/places")]
        public ParkingPlaceDTO CreatePersonPlace(int id, ParkingPlaceDTO place)
        {
            place.PersonId = id;

            return Mapper.Map<ParkingPlaceDTO>(PlaceCreateService.CreateParkingPlace(Mapper.Map<ParkingPlaceUpdateModel>(place)));
        }

        [HttpGet("{id}")]
        public PersonDTO GetPerson(int id)
        {
            return Mapper.Map<PersonDTO>(PersonGetService.GetPerson(new PersonIdentityModel(id)));
        }

        [HttpGet("{id}/places")]
        public IEnumerable<ParkingPlaceDTO> GetPersonPlaces(int id)
        {
            return PlaceGetService.GetPersonsPlaces(new PersonIdentityModel(id)).Select(x => Mapper.Map<ParkingPlaceDTO>(x)).ToList();
        }

        [HttpPut("{id}")]
        public PersonDTO UpdatePerson(int id, PersonDTO person)
        {
            var identityModel = new PersonIdentityModel(id);
            var updateModel = Mapper.Map<PersonUpdateModel>(person);

            Person res = PersonUpdateService.UpdatePerson(identityModel, updateModel);

            return Mapper.Map<PersonDTO>(res);
        }

        [HttpDelete("{id}")]
        public void DeletePerson(int id)
        {
            var identityModel = new PersonIdentityModel(id);
            PersonDeleteService.DeletePerson(identityModel);
        }
    }
}
