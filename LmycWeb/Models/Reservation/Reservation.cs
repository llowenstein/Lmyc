using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LmycWeb.Models.Reservation
{
    public class Reservation
    {
        public int ReservationId { get; set; }

        [ForeignKey("User")]
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [ScaffoldColumn(false)]
        public ApplicationUser User { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        [ForeignKey("Boat")]
        [Display(Name = "Boat")]
        public string BoatName { get; set; }

        [ScaffoldColumn(false)]
        public ApplicationUser Boat { get; set; }
    }
}
