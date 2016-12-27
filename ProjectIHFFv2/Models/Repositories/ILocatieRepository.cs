using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectIHFFv2.Models
{
    interface ILocatieRepository
    {
        Locatie GetById(int id);
    }
}
