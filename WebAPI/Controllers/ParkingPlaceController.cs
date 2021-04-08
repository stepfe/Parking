
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
    public class ParkingPlaceController : Controller
    {
        private readonly ILogger<ParkingPlaceController> _logger;

        private IMapper Mapper { get; }
        private IParkingPlaceCreateService PlaceCreateService { get; }
        private IParkingPlaceGetService PlaceGetService { get; }
        private IParkingPlaceUpdateService PlaceUpdateService { get; }
        private IParkingPlaceDeleteService PlaceDeleteService { get; }
        public ParkingPlaceController(ILogger<ParkingPlaceController> logger, IMapper mapper, IParkingPlaceCreateService placeCreateService, IParkingPlaceGetService placeGetService, IParkingPlaceUpdateService placeUpdateService, IParkingPlaceDeleteService placeDeleteService)
        {
            _logger = logger;

            this.Mapper = mapper;
            this.PlaceCreateService = placeCreateService;
            this.PlaceGetService = placeGetService;
            this.PlaceUpdateService = placeUpdateService;
            this.PlaceDeleteService = placeDeleteService;
        }

        [HttpGet("{id}")]
        public ParkingPlaceDTO GetPlace(int id)
        {
            return Mapper.Map<ParkingPlaceDTO>(PlaceGetService.Get(new ParkingPlaceIdentityModel(id)));
        }

        [HttpPut("{id}")]
        public ParkingPlaceDTO UpdatePlace(int id, ParkingPlaceDTO place)
        {
            var identityModel = new ParkingPlaceIdentityModel(id);
            var updateModel = Mapper.Map<ParkingPlaceUpdateModel>(place);

            ParkingPlace res = PlaceUpdateService.UpdateParkingPlace(identityModel, updateModel);

            return Mapper.Map<ParkingPlaceDTO>(res);
        }

        [HttpDelete("{id}")]
        public void DeletePlace(int id)
        {
            var identityModel = new ParkingPlaceIdentityModel(id);
            PlaceDeleteService.DeleteParkingPlace(identityModel);
        }
    }
}
