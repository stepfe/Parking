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
    public class PersonUpdateServiceTests
    {

        [Test]
        public void TestUpdateUser()
        {
            Mock<IPersonDataAccess> personDataAccess = new Mock<IPersonDataAccess>();
            Person expected = new Person { Id = 1, Name = "Who", Email = "who@yandex.ru", PhoneNumber = "89500492805" };

            personDataAccess.Setup(x => x.Update(It.IsAny<PersonIdentityModel>(), It.IsAny<PersonUpdateModel>())).Returns(expected);


            var updateService = new PersonUpdateService(personDataAccess.Object, new PersonGetService(personDataAccess.Object));
            Person person = updateService.UpdatePerson(new PersonIdentityModel(1), new PersonUpdateModel() { Name = "Who", Email = "who@yandex.ru", PhoneNumber = "89500492805" });


            Assert.AreEqual(person.Name, expected.Name);
            Assert.AreEqual(person.Id, expected.Id);
            Assert.AreEqual(person.Email, expected.Email);
            Assert.AreEqual(person.PhoneNumber, expected.PhoneNumber);
        }
    }
}