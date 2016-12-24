using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectIHFFv2.Models
{
    public class EventRepository : IEventRepository
    {
        private iHFF1617S_A3Entities1 ctx = new iHFF1617S_A3Entities1();

        public Event GetById(int id)
        {
            Event gebeurtenis = ctx.Event.FirstOrDefault(x => x.EventId == id);
            return gebeurtenis;
        }
    }
}