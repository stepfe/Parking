using System;
using System.Collections.Generic;
using System.Text;
using Parking.Domain.Contracts;

namespace Parking.Domain.Models
{
    public class PersonIdentityModel : IPersonIdentity
    {
        public int Id { get; }

        public PersonIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}
