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
    
    public partial class Bom
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bom()
        {
            this.BomDetails = new HashSet<BomDetail>();
            this.FirmOrderDetails = new HashSet<FirmOrderDetail>();
            this.FirmOrders = new HashSet<FirmOrder>();
            this.PlannedOrderDetails = new HashSet<PlannedOrderDetail>();
            this.FirmOrderMaterials = new HashSet<FirmOrderMaterial>();
            this.ProductionOrderDetails = new HashSet<ProductionOrderDetail>();
        }
    
        public int BomID { get; set; }
        public System.DateTime EntryDate { get; set; }
        public string Reference { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int CommodityCategoryID { get; set; }
        public int CommodityClassID { get; set; }
        public int CommodityLineID { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public string Remarks { get; set; }
        public bool InActive { get; set; }
        public string OfficialCode { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BomDetail> BomDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FirmOrderDetail> FirmOrderDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FirmOrder> FirmOrders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlannedOrderDetail> PlannedOrderDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FirmOrderMaterial> FirmOrderMaterials { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductionOrderDetail> ProductionOrderDetails { get; set; }
    }
}
