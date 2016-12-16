using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectIHFFv2.Models
{
    public class SpecialRepository
    {
        private iHFF1617S_A3Entities1 ctx = new iHFF1617S_A3Entities1();

        public IEnumerable<Special> GetAllForDay(DateTime dag)
        {
            IQueryable<Special> specialsDay = ctx.Special.Where(x => x.Event.type == 3 && x.Event.begin_datumtijd.Value.Day == dag.Day).OrderBy(x => x.Event.begin_datumtijd);
            return specialsDay;
        }

        public Special GetSpecialById(int id)
        {
            Special special = ctx.Special.FirstOrDefault(x => x.EventId == id);
            return special;
        }
    }
}