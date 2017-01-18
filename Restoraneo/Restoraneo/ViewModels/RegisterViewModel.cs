using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restoraneo.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Ime je obavezno za unos!")]
        [Display(Name = "Ime")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Prezime je obavezno za unos!")]
        [Display(Name = "Prezime")]
        public string Surname { get; set; }

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