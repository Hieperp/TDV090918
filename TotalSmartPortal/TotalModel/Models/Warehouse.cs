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
    
    public partial class Warehouse
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Warehouse()
        {
            this.DeliveryAdvices = new HashSet<DeliveryAdvice>();
            this.GoodsIssueDetails = new HashSet<GoodsIssueDetail>();
            this.GoodsIssues = new HashSet<GoodsIssue>();
            this.SalesOrders = new HashSet<SalesOrder>();
            this.SalesReturns = new HashSet<SalesReturn>();
            this.WarehouseAdjustmentDetails = new HashSet<WarehouseAdjustmentDetail>();
            this.WarehouseAdjustmentDetails1 = new HashSet<WarehouseAdjustmentDetail>();
            this.WarehouseAdjustments = new HashSet<WarehouseAdjustment>();
            this.WarehouseAdjustments1 = new HashSet<WarehouseAdjustment>();
            this.GoodsReceiptDetails = new HashSet<GoodsReceiptDetail>();
            this.GoodsReceipts = new HashSet<GoodsReceipt>();
            this.MaterialIssues = new HashSet<MaterialIssue>();
        }
    
        public int WarehouseID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int WarehouseCategoryID { get; set; }
        public int WarehouseGroupID { get; set; }
        public int WarehouseClassID { get; set; }
        public int LocationID { get; set; }
        public bool Bookable { get; set; }
        public bool Issuable { get; set; }
        public bool IsDefault { get; set; }
        public string Remarks { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DeliveryAdvice> DeliveryAdvices { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GoodsIssueDetail> GoodsIssueDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GoodsIssue> GoodsIssues { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesOrder> SalesOrders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesReturn> SalesReturns { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WarehouseAdjustmentDetail> WarehouseAdjustmentDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WarehouseAdjustmentDetail> WarehouseAdjustmentDetails1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WarehouseAdjustment> WarehouseAdjustments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WarehouseAdjustment> WarehouseAdjustments1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GoodsReceiptDetail> GoodsReceiptDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GoodsReceipt> GoodsReceipts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaterialIssue> MaterialIssues { get; set; }
    }
}
