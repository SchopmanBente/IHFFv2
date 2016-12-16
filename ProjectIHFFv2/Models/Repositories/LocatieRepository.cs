using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectIHFFv2.Models
{
    public class LocatieRepository
    {
        private iHFF1617S_A3Entities1 ctx = new iHFF1617S_A3Entities1();

        public Locatie GetById(int id)
        {
            Locatie locatie = ctx.Locatie.FirstOrDefault(l => l.id == id);
            return locatie;
        }
    }
}