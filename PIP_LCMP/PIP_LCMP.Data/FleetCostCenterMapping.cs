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
    
    public partial class FleetCostCenterMapping
    {
        public int id { get; set; }
        public Nullable<int> fleetied { get; set; }
        public Nullable<int> costcenterid { get; set; }
        public Nullable<int> count { get; set; }
    
        public virtual CostCenters CostCenters { get; set; }
        public virtual Fleet Fleet { get; set; }
    }
}
