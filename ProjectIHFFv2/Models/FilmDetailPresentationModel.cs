using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectIHFFv2.Models
{
    public class FilmDetailPresentationModel
    {
        public int EventId { get; set; }
        public string Naam { get; set; }
        public double Rating { get; set; }
        public string AfbeeldingUrl { get; set; }
        public string TrailerUrl { get; set; }
        public string EventLocatie { get; set; }
        public string Beschrijving { get; set; }
        public IEnumerable<Cultuuritem> CultuurItems { get; set; }
        public IEnumerable<Film> filmVoorstellingen { get; set; }

        [Required(ErrorMessage = "An amount is required")]
        [Display(Name = "Amount")]
        public int AantalPersonen { get; set; }


        public FilmDetailPresentationModel(int id, string naam,double rating,string afbeelding, string trailer,DateTime? begindatum, DateTime? einddatum, string locatienaam,string locatiezaal, string beschrijving,  IEnumerable<Cultuuritem> activiteiten , IEnumerable<Film> voorstellingen)
        {
            this.EventId = id;
            this.Naam = naam;
            this.Rating = rating;
            this.AfbeeldingUrl = afbeelding;
            this.TrailerUrl = trailer;
            this.EventLocatie = locatienaam + " " + locatiezaal;
            this.Beschrijving = beschrijving;
            this.CultuurItems = activiteiten;
            this.filmVoorstellingen = voorstellingen;
          
        }
    }
}