using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectIHFFv2.Models
{
    public class FilmPresentationModel
    {
        public Film Film { get; set; }
        public Locatie Locatie { get; set; }

        public FilmPresentationModel(Film f, Locatie l)
        {
            this.Film = f;
            this.Locatie = l;
        }
    }
}