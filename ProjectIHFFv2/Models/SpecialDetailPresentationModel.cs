using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectIHFFv2.Models
{
    public class SpecialDetailPresentationModel
    {
         public int EventId { get; set; }
        public string Naam { get; set; }
        public string AfbeeldingUrl { get; set; }
        public string BeginDatumTijd { get; set; }
        public string EindDatumTijd { get; set; }
        public Locatie EventLocatie { get; set; }
        public string Beschrijving { get; set; }
        public IEnumerable<Event> Restaurants { get; set; }


        public SpecialDetailPresentationModel(int id, string naam,string spreker,string afbeelding, DateTime? begindatum, DateTime? einddatum,Locatie locatie, string beschrijving,IEnumerable<Event> activiteiten)
        {
            this.EventId = id;
            this.Naam = naam + " "+ spreker;
            this.AfbeeldingUrl = afbeelding;
            this.EventLocatie = locatie;
            this.Beschrijving = beschrijving;
            this.Restaurants = activiteiten;


            //Bepaal de juiste weergave
            DateTime dag = new DateTime(2017, 8, 10, 0, 0, 0);
            DateTime start = (DateTime)begindatum;
            DateTime eind = (DateTime)einddatum;

            if (start.Minute == dag.Minute)
                this.BeginDatumTijd = start.Date.ToString() + " " + start.Hour.ToString() + ':' + 0 + start.Minute.ToString();
            else
                this.BeginDatumTijd = start.Date.ToString() + " " + start.Hour.ToString() + ':' + start.Minute.ToString();

            if(eind.Minute == dag.Minute)
                this.BeginDatumTijd = eind.Date.ToString() + " " + eind.Hour.ToString() + ':' + 0 + eind.Minute.ToString();
            else
                this.BeginDatumTijd = eind.Date.ToString() + " " + eind.Hour.ToString() + ':' + eind.Minute.ToString();     
        }
    }
}