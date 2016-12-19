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
        public string AfbeeldingUrl { get; set; }
        public string TrailerUrl { get; set; }
        public string BeginDatumTijd { get; set; }
        public string EindDatumTijd { get; set; }
        public string EventLocatie { get; set; }
        public string Beschrijving { get; set; }
        public IEnumerable<Cultuuritem> CultuurItems { get; set; }
        public IEnumerable<Film> filmVoorstellingen { get; set; }

        [Required(ErrorMessage = "An amount is required")]
        [Display(Name = "Amount")]
        public int AantalPersonen { get; set; }


        public FilmDetailPresentationModel(int id, string naam,string afbeelding, string trailer,DateTime? begindatum, DateTime? einddatum, string locatienaam,string locatiezaal, string beschrijving,  IEnumerable<Cultuuritem> activiteiten , IEnumerable<Film> voorstellingen)
        {
            this.EventId = id;
            this.Naam = naam;
            this.AfbeeldingUrl = afbeelding;
            this.TrailerUrl = trailer;
            this.EventLocatie = locatienaam + " " + locatiezaal;
            this.Beschrijving = beschrijving;
            this.CultuurItems = activiteiten;
            this.filmVoorstellingen = voorstellingen;

            //Bepaal de juiste weergave
            DateTime dag = new DateTime(2017, 8, 10, 0, 0, 0);
            DateTime start = (DateTime)begindatum;
            DateTime eind = (DateTime)einddatum;

            if (start.Minute == dag.Minute)
                this.BeginDatumTijd = start.Date.ToString() + " " + start.Hour.ToString() + ":00";
            else
                this.BeginDatumTijd = start.Date.ToString() + " " + start.Hour.ToString() + ':' + start.Minute.ToString();

            if(eind.Minute == dag.Minute)
                this.BeginDatumTijd = eind.Date.ToString() + " " + eind.Hour.ToString() + ':' + 0 + eind.Minute.ToString();
            else
                this.BeginDatumTijd = eind.Date.ToString() + " " + eind.Hour.ToString() + ':' + eind.Minute.ToString();     
        }
    }
}