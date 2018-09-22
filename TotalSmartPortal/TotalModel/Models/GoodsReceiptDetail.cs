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
    
    public partial class GoodsReceiptDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GoodsReceiptDetail()
        {
            this.WarehouseAdjustmentDetails = new HashSet<WarehouseAdjustmentDetail>();
            this.MaterialIssueDetails = new HashSet<MaterialIssueDetail>();
            this.SemifinishedProducts = new HashSet<SemifinishedProduct>();
        }
    
        public int GoodsReceiptDetailID { get; set; }
        public int GoodsReceiptID { get; set; }
        public System.DateTime EntryDate { get; set; }
        public string Reference { get; set; }
        public string Code { get; set; }
        public int LocationID { get; set; }
        public Nullable<int> LocationIssueID { get; set; }
        public int GoodsReceiptTypeID { get; set; }
        public Nullable<int> PurchaseRequisitionID { get; set; }
        public Nullable<int> PurchaseRequisitionDetailID { get; set; }
        public Nullable<int> FinishedProductID { get; set; }
        public Nullable<int> FinishedProductDetailID { get; set; }
        public Nullable<int> MaterialIssueID { get; set; }
        public Nullable<int> MaterialIssueDetailID { get; set; }
        public Nullable<int> GoodsIssueID { get; set; }
        public Nullable<int> GoodsIssueTransferDetailID { get; set; }
        public Nullable<int> WarehouseAdjustmentID { get; set; }
        public Nullable<int> WarehouseAdjustmentDetailID { get; set; }
        public Nullable<int> WarehouseAdjustmentTypeID { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public int BatchID { get; set; }
        public System.DateTime BatchEntryDate { get; set; }
        public int CommodityID { get; set; }
        public int CommodityTypeID { get; set; }
        public int WarehouseID { get; set; }
        public Nullable<int> WarehouseIssueID { get; set; }
        public decimal Quantity { get; set; }
        public decimal QuantityIssued { get; set; }
        public string Remarks { get; set; }
        public bool Approved { get; set; }
    
        public virtual Commodity Commodity { get; set; }
        public virtual FinishedProductDetail FinishedProductDetail { get; set; }
        public virtual GoodsReceipt GoodsReceipt { get; set; }
        public virtual PurchaseRequisitionDetail PurchaseRequisitionDetail { get; set; }
        public virtual WarehouseAdjustmentDetail WarehouseAdjustmentDetail { get; set; }
        public virtual Warehouse Warehouse { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WarehouseAdjustmentDetail> WarehouseAdjustmentDetails { get; set; }
        public virtual MaterialIssueDetail MaterialIssueDetail { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaterialIssueDetail> MaterialIssueDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SemifinishedProduct> SemifinishedProducts { get; set; }
    }
}
