using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restoraneo.ViewModels
{
    public class RegisterRestaurantViewModel
    {
        [Required(ErrorMessage = "Ime restorana je obavezno za unos!")]
        [Display(Name = "Ime restorana")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Ime vlasnika je obavezno za unos!")]
        [Display(Name = "Ime vlasnika")]
        public string NameOfOwner { get; set; }


        [Required(ErrorMessage = "Ime vlasnika je obavezno za unos!")]
        [Display(Name = "Prezime vlasnika")]
        public string SurnameOfOwner { get; set; }



        [Display(Name = "Broj mobitela")]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "Email je obavezan za unos!")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lozinka je obavezna za unos!")]
        [StringLength(100, ErrorMessage = "{0} mora biti najmanje {2} znakova.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Lozinka")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potvrda lozinke")]
        [Compare("Password", ErrorMessage = "Lozinka i potvrda lozinke se ne poduraraju")]
        public string ConfirmPassword { get; set; }
    }
}