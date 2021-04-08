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
    public class PersonGetServiceTests
    {
        private Mock<IPersonDataAccess> personDataAccess;
        private Person expected;

        [SetUp]
        public void SetUp()
        {
            personDataAccess = new Mock<IPersonDataAccess>();
            expected = new Person { Id = 1, Name = "Who", Email = "who@yandex.ru", PhoneNumber = "89500492805" };
        }

        [Test]
        public void TestGetPerson()
        {

            personDataAccess.Setup(x => x.Get(It.IsAny<PersonIdentityModel>())).Returns(expected);

            var getService = new PersonGetService(personDataAccess.Object);
            Person person = getService.GetPerson(new PersonIdentityModel(1));


            Assert.AreEqual(person.Name, expected.Name);
            Assert.AreEqual(person.Id, expected.Id);
            Assert.AreEqual(person.Email, expected.Email);
            Assert.AreEqual(person.PhoneNumber, expected.PhoneNumber);
        }

        [Test]
        public void TestSuccessfullValidatePerson()
        {

            personDataAccess.Setup(x => x.Get(It.IsAny<PersonIdentityModel>())).Returns(expected);

            var getService = new PersonGetService(personDataAccess.Object);


            Assert.DoesNotThrow(() => getService.ValidatePerson(new PersonUpdateModel() { Name = "Who", PhoneNumber = "89500492805", Email = "who@yandex.ru" }));
        }

        [Test]
        public void TestUnsuccessfullValidatePerson()
        {

            personDataAccess.Setup(x => x.Get(It.IsAny<PersonIdentityModel>())).Returns(expected);


            var getService = new PersonGetService(personDataAccess.Object);


            Assert.Catch<ArgumentException>(() => getService.ValidatePerson(new PersonUpdateModel() { Name = "Who", PhoneNumber = "895092805", Email = "who@yandex.ru" }));
        }
    }
}