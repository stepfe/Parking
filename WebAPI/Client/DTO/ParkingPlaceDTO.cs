using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Client.DTO
{
    public class ParkingPlaceDTO
    {
        public int Id { get; set; }

        public int PersonId { get; set; }
        public int Flor { get; set; }
        public int Number { get; set; }
        public string Auto { get; set; }
    }
}
