using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProjectIHFFv2.Models
{
    public class CheckoutModel
    {
       public CartPresentationModel Reserveringen { get; set; }

        [Required]
        [Display(Name ="Name")]
        public string VoorNaam { get; set; }

        [Required]
        [Display(Name = "Surname")]
        public string AchterNaam { get; set; }

        [Required]
        [Display(Name = "E-mail adress")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

      

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Confirm Email adress")]
        [Compare("Email", ErrorMessage = "E-mail adresses do not match")]


        public string BevestigEmail { get; set; }

        [Display(Name = "Phone number")]
        public string TelefoonNummer { get; set; }


        public CheckoutModel() { }
        public CheckoutModel(CartPresentationModel model)
        {
            Reserveringen = model; 
        }
    }
}