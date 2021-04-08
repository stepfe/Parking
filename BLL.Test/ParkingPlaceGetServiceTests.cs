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
    class ParkingPlaceGetServiceTests
    {

        [Test]
        public void TestGetPlace()
        {

            Mock<IParkingPlaceDataAccess> parkingPlaceDataAccess = new Mock<IParkingPlaceDataAccess>();
            ParkingPlace expected = new ParkingPlace() { Flor = 1, Number = 1, PersonId = 1, Auto = "Lada" };


            parkingPlaceDataAccess.Setup(x => x.Get(It.IsAny<ParkingPlaceIdentityModel>())).Returns(expected);


            var getService = new ParkingPlaceGetService(parkingPlaceDataAccess.Object);
            ParkingPlace place = getService.Get(new ParkingPlaceIdentityModel(1));


            Assert.AreEqual(place.Flor, expected.Flor);
            Assert.AreEqual(place.PersonId, expected.PersonId);
            Assert.AreEqual(place.Auto, expected.Auto);
            Assert.AreEqual(place.Number, expected.Number);
        }
    }
}
