using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Restoraneo.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }

        public int NumberOfPersons { get; set; }

        public DateTime DateTimeOfReservation { get; set; }

        public int RestaurantId { get; set; }

        [ForeignKey("RestaurantId")]
        public virtual Restaurant Restaurant { get; set; }

        public string ApplicationUser_Id { get; set; }

        [ForeignKey("ApplicationUser_Id")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        public int ReservationStatus { get; set; }

    }
}