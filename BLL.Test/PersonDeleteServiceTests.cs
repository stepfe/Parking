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
    public class PersoneDeleteServiceTests
    {

        [Test]
        public void TestDeletePerson()
        {
            Mock<IPersonDataAccess> personDataAccess = new Mock<IPersonDataAccess>();
            personDataAccess.Setup(x => x.Delete(It.IsAny<PersonIdentityModel>()));


            var deleteService = new PersonDeleteService(personDataAccess.Object);
            deleteService.DeletePerson(new PersonIdentityModel(1));


            personDataAccess.Verify(x => x.Delete(It.IsAny<PersonIdentityModel>()), Times.Once());
        }
    }
}