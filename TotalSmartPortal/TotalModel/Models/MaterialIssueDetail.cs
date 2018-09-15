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
    
    public partial class MaterialIssueDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MaterialIssueDetail()
        {
            this.SemifinishedProductDetails = new HashSet<SemifinishedProductDetail>();
            this.SemifinishedProducts = new HashSet<SemifinishedProduct>();
        }
    
        public int MaterialIssueDetailID { get; set; }
        public int MaterialIssueID { get; set; }
        public System.DateTime EntryDate { get; set; }
        public int LocationID { get; set; }
        public int MaterialIssueTypeID { get; set; }
        public int WorkshiftID { get; set; }
        public int CustomerID { get; set; }
        public int ProductionOrderID { get; set; }
        public int ProductionOrderDetailID { get; set; }
        public int PlannedOrderID { get; set; }
        public int FirmOrderID { get; set; }
        public int FirmOrderMaterialID { get; set; }
        public int ProductionLineID { get; set; }
        public int GoodsReceiptID { get; set; }
        public int GoodsReceiptDetailID { get; set; }
        public int CommodityID { get; set; }
        public int CommodityTypeID { get; set; }
        public int WarehouseID { get; set; }
        public decimal Quantity { get; set; }
        public decimal QuantitySemifinished { get; set; }
        public decimal QuantityWastage { get; set; }
        public decimal QuantityFailure { get; set; }
        public decimal QuantityRejected { get; set; }
        public string Remarks { get; set; }
        public bool Approved { get; set; }
    
        public virtual Commodity Commodity { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual FirmOrder FirmOrder { get; set; }
        public virtual GoodsReceiptDetail GoodsReceiptDetail { get; set; }
        public virtual MaterialIssue MaterialIssue { get; set; }
        public virtual ProductionOrderDetail ProductionOrderDetail { get; set; }
        public virtual Workshift Workshift { get; set; }
        public virtual FirmOrderMaterial FirmOrderMaterial { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SemifinishedProductDetail> SemifinishedProductDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SemifinishedProduct> SemifinishedProducts { get; set; }
    }
}
