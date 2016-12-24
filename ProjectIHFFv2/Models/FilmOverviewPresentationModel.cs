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
        
        public FilmOverviewPresentationModel(int id, string naam,string afbeelding, DateTime begindatum,DateTime einddatum, Locatie locatie, string beschrijving)
        {
            this.EventId = id;
            this.Naam = naam;
            this.AfbeeldingUrl = afbeelding;
            this.EventLocatie = locatie;
            this.Beschrijving = beschrijving.Substring(0,90);
            DateTime dag = new DateTime(2017, 8, 10, 0, 0, 0);
           /* DateTime begindatum = (DateTime)begindatum;
            DateTime einddatum = (DateTime)einddatumdatum; */

            if (begindatum.Minute == dag.Minute)
                this.BeginDatumTijd =  begindatum.Day.ToString() + '-' +  begindatum.Month.ToString() + '-' + begindatum.Year.ToString() + " " + begindatum.Hour.ToString() + ":00";
            else
                this.BeginDatumTijd = begindatum.Day.ToString() + '-' + begindatum.Month.ToString() + '-' + begindatum.Year.ToString() + " " + begindatum.Hour.ToString() + ':' + begindatum.Minute.ToString();

            if (einddatum.Minute == dag.Minute)
                this.EindDatumTijd = einddatum.Day.ToString() + '-' + einddatum.Month.ToString() + '-' + einddatum.Year.ToString() + " " + einddatum.Hour.ToString() + ":00";
            else
                this.EindDatumTijd = einddatum.Day.ToString() + '-' + einddatum.Month.ToString() + '-' + einddatum.Year.ToString() + " " + einddatum.Hour.ToString() + ':' + einddatum.Minute.ToString();
        }
    }
}