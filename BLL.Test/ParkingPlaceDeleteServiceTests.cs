using Parking;
using Parking.Domain.Models;
using BLL.Contracts;
using BLL.Implementation;
using DataAccess.Contracts;
using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;

namespace BLL.Test
{
    class ParkingPlaceDeleteServiceTests
    {

        [Test]
        public void TestDeletePlace()
        {

            Mock<IParkingPlaceDataAccess> parkingPlaceDataAccess = new Mock<IParkingPlaceDataAccess>();
            ParkingPlace expected = new ParkingPlace() { Flor = 1, Number = 1, PersonId = 1, Auto = "Lada" };

            parkingPlaceDataAccess.Setup(x => x.Insert(It.IsAny<ParkingPlaceUpdateModel>())).Returns(expected);


            var placeCreateService = new ParkingPlaceDeleteService(parkingPlaceDataAccess.Object);
            placeCreateService.DeleteParkingPlace(new ParkingPlaceIdentityModel(1));


            parkingPlaceDataAccess.Verify(x => x.Delete(It.IsAny<ParkingPlaceIdentityModel>()), Times.Once());
        }
    }
}