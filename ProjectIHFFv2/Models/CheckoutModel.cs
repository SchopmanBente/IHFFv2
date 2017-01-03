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
        [DataType(DataType.Text)]
        [RegularExpression(@"^[\w\s]*$", ErrorMessage = "A name can only contain letters.")]
        public string VoorNaam { get; set; }

        [Required]
        [Display(Name = "Surname")]
        [RegularExpression(@"^[\w\s]*$", ErrorMessage = "A surname can only contain letters.")]
        public string AchterNaam { get; set; }

        [Required]
        [Display(Name = "E-mail adress")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }

      

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Confirm Email adress")]
        [Compare("Email", ErrorMessage = "E-mail adresses do not match.")]


        public string BevestigEmail { get; set; }

        [Display(Name = "Phone number")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        public string TelefoonNummer { get; set; }


        public CheckoutModel() { }
        public CheckoutModel(CartPresentationModel model)
        {
            Reserveringen = model; 
        }
    }
}