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
    
    public partial class Cultuuritem
    {
        public int id { get; set; }
        public string beschrijving { get; set; }
        public string soort { get; set; }
        public string naam { get; set; }
        public string straatnaam { get; set; }
        public string huisnr { get; set; }
        public string toevoeging { get; set; }
        public string postcode { get; set; }
        public string locatie { get; set; }
        public Nullable<System.DateTime> openinsstarttijd { get; set; }
        public Nullable<System.DateTime> openingeindtijd { get; set; }
        public string afbeelding_url { get; set; }
    }
}
