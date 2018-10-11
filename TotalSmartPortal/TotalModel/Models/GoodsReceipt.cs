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
    
    public partial class GoodsReceipt
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GoodsReceipt()
        {
            this.SemifinishedProducts = new HashSet<SemifinishedProduct>();
            this.GoodsReceiptDetails = new HashSet<GoodsReceiptDetail>();
        }
    
        public int GoodsReceiptID { get; set; }
        public System.DateTime EntryDate { get; set; }
        public string Reference { get; set; }
        public string Code { get; set; }
        public int NMVNTaskID { get; set; }
        public int GoodsReceiptTypeID { get; set; }
        public Nullable<int> PurchaseRequisitionID { get; set; }
        public Nullable<int> PlannedOrderID { get; set; }
        public Nullable<int> WarehouseTransferID { get; set; }
        public Nullable<int> WarehouseAdjustmentID { get; set; }
        public string PrimaryReferences { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public int WarehouseID { get; set; }
        public Nullable<int> WarehouseIssueID { get; set; }
        public int StorekeeperID { get; set; }
        public int UserID { get; set; }
        public int PreparedPersonID { get; set; }
        public int OrganizationalUnitID { get; set; }
        public int LocationID { get; set; }
        public int ApproverID { get; set; }
        public decimal TotalQuantity { get; set; }
        public decimal TotalQuantityIssued { get; set; }
        public string Purposes { get; set; }
        public string Description { get; set; }
        public string Remarks { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime EditedDate { get; set; }
        public bool Approved { get; set; }
        public Nullable<System.DateTime> ApprovedDate { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Location Location { get; set; }
        public virtual PurchaseRequisition PurchaseRequisition { get; set; }
        public virtual WarehouseAdjustment WarehouseAdjustment { get; set; }
        public virtual Warehouse Warehouse { get; set; }
        public virtual Warehouse Warehouse1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SemifinishedProduct> SemifinishedProducts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GoodsReceiptDetail> GoodsReceiptDetails { get; set; }
        public virtual WarehouseTransfer WarehouseTransfer { get; set; }
    }
}
