//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TotalModel.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PlannedOrderDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PlannedOrderDetail()
        {
            this.MaterialIssueDetails = new HashSet<MaterialIssueDetail>();
            this.MaterialIssues = new HashSet<MaterialIssue>();
            this.PlannedOrderMaterials = new HashSet<PlannedOrderMaterial>();
        }
    
        public int PlannedOrderDetailID { get; set; }
        public int PlannedOrderID { get; set; }
        public System.DateTime EntryDate { get; set; }
        public int LocationID { get; set; }
        public int CustomerID { get; set; }
        public int CommodityID { get; set; }
        public int CommodityTypeID { get; set; }
        public int BomID { get; set; }
        public int MoldID { get; set; }
        public Nullable<System.DateTime> DeliveryDate { get; set; }
        public decimal Quantity { get; set; }
        public decimal QuantitySemifinished { get; set; }
        public string Remarks { get; set; }
        public Nullable<int> VoidTypeID { get; set; }
        public bool Approved { get; set; }
        public bool InActive { get; set; }
        public bool InActivePartial { get; set; }
        public Nullable<System.DateTime> InActivePartialDate { get; set; }
        public Nullable<int> CombineIndex { get; set; }
        public string Description { get; set; }
    
        public virtual Bom Bom { get; set; }
        public virtual Commodity Commodity { get; set; }
        public virtual Customer Customer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaterialIssueDetail> MaterialIssueDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaterialIssue> MaterialIssues { get; set; }
        public virtual Mold Mold { get; set; }
        public virtual PlannedOrder PlannedOrder { get; set; }
        public virtual VoidType VoidType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlannedOrderMaterial> PlannedOrderMaterials { get; set; }
    }
}
