using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectIHFFv2.Models
{
  public  class ReserveringModel : Reservering
    {

        public ReserveringModel()
        {

        }

        public ReserveringModel(int klantid, DateTime besteldatum, bool is_betaald, bool is_geannuleerd)
        {
            this.ophaalcode = "RandomOphaalCode";
        }
    }
}
