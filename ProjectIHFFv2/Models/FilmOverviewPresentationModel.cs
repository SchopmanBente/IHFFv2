using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectIHFFv2.Models
{
    public class FilmOverviewPresentationModel
    {
        public int EventId { get; set; }
        public string Naam { get; set; }
        public string AfbeeldingUrl { get; set; }
        public string BeginDatumTijd { get; set; }
        public string EventLocatie { get; set; }
        public string Beschrijving { get; set; }
        
        public FilmOverviewPresentationModel(int id, string naam,string afbeelding, DateTime? begindatum, string locatienaam,string locatiezaal, string beschrijving)
        {
            this.EventId = id;
            this.Naam = naam;
            this.AfbeeldingUrl = afbeelding;
            this.EventLocatie = locatienaam + " " + locatiezaal;
            this.Beschrijving = beschrijving;
            DateTime dag = new DateTime(2017, 8, 10, 0, 0, 0);
            DateTime start = (DateTime)begindatum;

            if (start.Minute == dag.Minute)
                this.BeginDatumTijd = start.Hour.ToString() + ":00";
            else
                this.BeginDatumTijd = start.Hour.ToString() + ':' + start.Minute.ToString();
                        
        }
    }
}