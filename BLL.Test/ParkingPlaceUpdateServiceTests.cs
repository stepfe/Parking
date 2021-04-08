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
    class ParkingPlaceUpdateServiceTests
    {

        [Test]
        public void TestUpdatePlace()
        {

            Mock<IParkingPlaceDataAccess> parkingPlaceDataAccess = new Mock<IParkingPlaceDataAccess>();
            ParkingPlace expected = new ParkingPlace() { Flor = 1, Number = 1, PersonId = 1, Auto = "Lada" };

            parkingPlaceDataAccess.Setup(x => x.Update(It.IsAny<ParkingPlaceIdentityModel>(), It.IsAny<ParkingPlaceUpdateModel>())).Returns(expected);


            var updateService = new ParkingPlaceUpdateService(parkingPlaceDataAccess.Object);
            ParkingPlace place = updateService.UpdateParkingPlace(new ParkingPlaceIdentityModel(1), new ParkingPlaceUpdateModel() { Flor = 1, Number = 1, PersonId = 1, Auto = "Lada" });


            Assert.AreEqual(place.Flor, expected.Flor);
            Assert.AreEqual(place.PersonId, expected.PersonId);
            Assert.AreEqual(place.Auto, expected.Auto);
            Assert.AreEqual(place.Number, expected.Number);
        }
    }
}
