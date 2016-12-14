//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectIHFFv2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Event
    {
        public Event()
        {
            this.Klant_reservering = new HashSet<Klant_reservering>();
        }
    
        public int EventId { get; set; }
        public string naam { get; set; }
        public Nullable<double> prijs { get; set; }
        public Nullable<System.DateTime> begin_datumtijd { get; set; }
        public Nullable<System.DateTime> eind_datumtijd { get; set; }
        public Nullable<int> locatie_id { get; set; }
        public string beschrijving { get; set; }
        public string afbeelding_url { get; set; }
        public Nullable<double> rating { get; set; }
        public int type { get; set; }
    
        public virtual Locatie Locatie { get; set; }
        public virtual Film Film { get; set; }
        public virtual ICollection<Klant_reservering> Klant_reservering { get; set; }
        public virtual Special Special { get; set; }
    }
}
