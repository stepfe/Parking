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
    class ParkingPlaceCreateServiceTests
    {
        [Test]
        public void TestCreatePlace()
        {
            Mock<IParkingPlaceDataAccess> parkingPlaceDataAccess = new Mock<IParkingPlaceDataAccess>();
            ParkingPlace expected = new ParkingPlace() { Flor = 1, Number = 1, PersonId = 1, Auto = "Lada" };

            parkingPlaceDataAccess.Setup(x => x.Insert(It.IsAny<ParkingPlaceUpdateModel>())).Returns(expected);


            var placeCreateService = new ParkingPlaceCreateService(parkingPlaceDataAccess.Object);
            ParkingPlace place = placeCreateService.CreateParkingPlace(new ParkingPlaceUpdateModel() { Flor = 1, Number = 1, PersonId = 1, Auto = "Lada" });


            Assert.AreEqual(place.Flor, expected.Flor);
            Assert.AreEqual(place.Number, expected.Number);
            Assert.AreEqual(place.Auto, expected.Auto);
            Assert.AreEqual(place.PersonId, expected.PersonId);
        }
    }
}
