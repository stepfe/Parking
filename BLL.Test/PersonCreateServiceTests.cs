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
    class PersonCreateServiceTests
    {
        [Test]
        public void TestCreateperson()
        {
            Mock<IPersonDataAccess> personDataAccess = new Mock<IPersonDataAccess>();
            Person expected = new Person { Id = 1, Name = "Who", Email = "who@yandex.ru", PhoneNumber = "89500492805" };


            personDataAccess.Setup(x => x.Insert(It.IsAny<PersonUpdateModel>())).Returns(expected);


            var createService = new PersonCreateService(personDataAccess.Object, new PersonGetService(personDataAccess.Object));
            Person person = createService.CreatePerson(new PersonUpdateModel() { Name = "Who", Email = "who@yandex.ru", PhoneNumber = "89500492805" });

            Assert.AreEqual(person.Name, expected.Name);
            Assert.AreEqual(person.Id, expected.Id);
            Assert.AreEqual(person.Email, expected.Email);
            Assert.AreEqual(person.PhoneNumber, expected.PhoneNumber);
        }
    }
}
