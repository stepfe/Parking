using System;
using System.Collections.Generic;
using System.Text;
using Parking.Domain.Contracts;
namespace Parking.Domain.Models
{
    public class PersonUpdateModel : IPersonIdentity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Emaile { get; set; }
        public string PhoneNumber { get; set; }

    }
}
