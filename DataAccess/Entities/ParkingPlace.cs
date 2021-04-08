using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DataAccess.Entities
{
    public class ParkingPlace
    {
        public ParkingPlace()
        {

        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int PersonId { get; set; }
        public int Flor { get; set; }
        public int Number { get; set; }
        public string Auto { get; set; }
        public virtual Person Person { get; set; }
    }
}
