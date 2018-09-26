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
    
    public partial class TransferOrder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TransferOrder()
        {
            this.TransferOrderDetails = new HashSet<TransferOrderDetail>();
            this.WarehouseTransferDetails = new HashSet<WarehouseTransferDetail>();
            this.WarehouseTransfers = new HashSet<WarehouseTransfer>();
        }
    
        public int TransferOrderID { get; set; }
        public System.DateTime EntryDate { get; set; }
        public string Reference { get; set; }
        public int NMVNTaskID { get; set; }
        public int CustomerID { get; set; }
        public int WarehouseID { get; set; }
        public int WarehouseReceiptID { get; set; }
        public int TransferOrderTypeID { get; set; }
        public int StorekeeperID { get; set; }
        public bool HasPositiveLine { get; set; }
        public string AdjustmentJobs { get; set; }
        public int UserID { get; set; }
        public int PreparedPersonID { get; set; }
        public int OrganizationalUnitID { get; set; }
        public int LocationID { get; set; }
        public decimal TotalQuantity { get; set; }
        public string Description { get; set; }
        public string Remarks { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime EditedDate { get; set; }
        public bool Approved { get; set; }
        public Nullable<System.DateTime> ApprovedDate { get; set; }
        public Nullable<int> VoidTypeID { get; set; }
        public bool InActive { get; set; }
        public bool InActivePartial { get; set; }
        public Nullable<System.DateTime> InActiveDate { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Location Location { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TransferOrderDetail> TransferOrderDetails { get; set; }
        public virtual TransferOrderType TransferOrderType { get; set; }
        public virtual Warehouse Warehouse { get; set; }
        public virtual Warehouse Warehouse1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WarehouseTransferDetail> WarehouseTransferDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WarehouseTransfer> WarehouseTransfers { get; set; }
    }
}
