using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectIHFFv2.Models
{
    public class CulturePresentationModel
    {
        public Cultuuritem cultuuritem { get; set; }
        public IEnumerable<Cultuuritem> CultuurItems { get; set; }
        public IEnumerable<Film> filmVoorstellingen { get; set; }

        public CulturePresentationModel(Cultuuritem cultuuritem, IEnumerable<Cultuuritem> CultuurItems, IEnumerable<Film> filmVoorstellingen)
        {
            this.cultuuritem = cultuuritem;
            this.CultuurItems = CultuurItems;
            this.filmVoorstellingen = filmVoorstellingen;
        }

    }
}