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
    
    public partial class CostCenters
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CostCenters()
        {
            this.FleetCostCenterMapping = new HashSet<FleetCostCenterMapping>();
            this.FleetTransactions = new HashSet<FleetTransactions>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string elementid { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FleetCostCenterMapping> FleetCostCenterMapping { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FleetTransactions> FleetTransactions { get; set; }
    }
}
