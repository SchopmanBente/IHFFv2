using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectIHFFv2.Models
{
    public class SpecialRepository : ISpecialRepository
    {
        private iHFF1617S_A3Entities1 ctx = new iHFF1617S_A3Entities1();

        public IEnumerable<Special> GetAllForDay(DateTime dag)
        {
            //Haal elke special op die op de bepaalde dag afspeelt en order deze op volgorde
            IQueryable<Special> specialsDay = ctx.Special.Where(x => x.Event.begin_datumtijd.Day == dag.Day).OrderBy(x => x.Event.begin_datumtijd);
            return specialsDay;
        }

        public Special GetSpecialById(int id)
        {
            //Haal de special op met eventId x
            Special special = ctx.Special.FirstOrDefault(x => x.EventId == id);
            return special;
        }
    }
}