using System;
using System.Collections.Generic;
using System.Text;
using Parking.Domain.Contracts;
namespace Parking.Domain.Models
{
    public class PersonUpdateModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

    }
}
