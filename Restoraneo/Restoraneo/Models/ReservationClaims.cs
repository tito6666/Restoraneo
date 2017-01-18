using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restoraneo.Models
{
    public class ReservationClaim
    {
        [Key]
        public int ReservationClaimId { get; set; }

        public string ClientId { get; set; }

        public string ClientUsername { get; set; }

        public int RestaurantId { get; set; }

        public string RestaurantName { get; set; }

        public string NumberOfPersons { get; set; }

        public string DateOfReservation { get; set; }

        public string TimeOfReservation { get; set; }
    }
}