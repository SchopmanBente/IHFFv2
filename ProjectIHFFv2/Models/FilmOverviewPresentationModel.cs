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
        public string EindDatumTijd { get; set; }
        public Locatie EventLocatie { get; set; }
        public string Beschrijving { get; set; }
        
        public FilmOverviewPresentationModel(int id, string naam,string afbeelding, DateTime? begindatum,DateTime? einddatum, Locatie locatie, string beschrijving)
        {
            this.EventId = id;
            this.Naam = naam;
            this.AfbeeldingUrl = afbeelding;
            this.EventLocatie = locatie;
            this.Beschrijving = beschrijving.Substring(0,90);
            DateTime dag = new DateTime(2017, 8, 10, 0, 0, 0);
            DateTime start = (DateTime)begindatum;
            DateTime eind = (DateTime)einddatum;

            if (start.Minute == dag.Minute)
                this.BeginDatumTijd =  start.Day.ToString() + '-' +  start.Month.ToString() + '-' + start.Year.ToString() + " " + start.Hour.ToString() + ":00";
            else
                this.BeginDatumTijd = start.Day.ToString() + '-' + start.Month.ToString() + '-' + start.Year.ToString() + " " + start.Hour.ToString() + ':' + start.Minute.ToString();

            if (eind.Minute == dag.Minute)
                this.EindDatumTijd = eind.Day.ToString() + '-' + eind.Month.ToString() + '-' + eind.Year.ToString() + " " + eind.Hour.ToString() + ":00";
            else
                this.BeginDatumTijd = eind.Day.ToString() + '-' + eind.Month.ToString() + '-' + eind.Year.ToString() + " " + eind.Hour.ToString() + ':' + eind.Minute.ToString();
        }
    }
}