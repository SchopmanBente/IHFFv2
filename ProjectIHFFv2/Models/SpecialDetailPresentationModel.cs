using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectIHFFv2.Models
{
    public class SpecialDetailPresentationModel
    {
         public int EventId { get; set; }
         public double Prijs { get; set; }
        public string Naam { get; set; }
        public string AfbeeldingUrl { get; set; }
        public DateTime BeginDatumTijd { get; set; }
        public DateTime EindDatumTijd { get; set; }
        public Locatie EventLocatie { get; set; }
        public string Beschrijving { get; set; }
        public IEnumerable<Event> Restaurants { get; set; }

        [Required(ErrorMessage = "An amount is required")]
        [Display(Name = "Amount")]
        public int AantalPersonen { get; set; }


        public SpecialDetailPresentationModel(int id, double prijs,string naam,string spreker,string afbeelding, DateTime begindatum, DateTime einddatum,Locatie locatie, string beschrijving,IEnumerable<Event> activiteiten)
        {
            this.EventId = id;
            this.Prijs = prijs;
            this.Naam = naam + " "+ spreker;
            this.AfbeeldingUrl = afbeelding;
            this.EventLocatie = locatie;
            this.Beschrijving = beschrijving;
            this.Restaurants = activiteiten;

            this.BeginDatumTijd = begindatum;
            this.EindDatumTijd = einddatum;

          
        }
    }
}