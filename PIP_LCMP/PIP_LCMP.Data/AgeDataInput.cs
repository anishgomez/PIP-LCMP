//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PIP_LCMP.DataEntities
{
    using System;
    using System.Collections.Generic;
    
    public partial class AgeDataInput
    {
        public int Id { get; set; }
        public int FleetModelId { get; set; }
        public int ColorId { get; set; }
        public int RangeStart { get; set; }
        public int RangeEnd { get; set; }
        public int FleetId { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    
        public virtual Fleet Fleet { get; set; }
        public virtual FleetAgeColours FleetAgeColours { get; set; }
        public virtual FleetModel FleetModel { get; set; }
        public virtual Users Users { get; set; }
        public virtual Users Users1 { get; set; }
    }
}
