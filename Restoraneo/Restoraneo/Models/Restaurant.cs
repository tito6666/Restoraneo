using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restoraneo.Models
{
    public class Restaurant
    {
        public int RestaurantId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Email { get; set; }

        public string TelephoneNumber1 { get; set; }

        public string TelephoneNumber2 { get; set; }

        public string MobileNumber1 { get; set; }

        public string MobileNumber2 { get; set; }

        public string Fax { get; set; }

        public int NumberOfSeets { get; set; }

        public decimal Lat { get; set; }

        public decimal Long { get; set; }

        public virtual RestaurantInfo RestaurantInfo { get; set; }

        public ICollection<RestaurantDish> RestaurantDishes { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }

        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}