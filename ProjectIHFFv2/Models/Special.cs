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
    
    public partial class Special
    {
        public int EventId { get; set; }
        public string spreker { get; set; }
    
        public virtual Event Event { get; set; }
    }
}
