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
    
    public partial class FinishedProductDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FinishedProductDetail()
        {
            this.FinishedHandoverDetails = new HashSet<FinishedHandoverDetail>();
            this.GoodsReceiptDetails = new HashSet<GoodsReceiptDetail>();
        }
    
        public int FinishedProductDetailID { get; set; }
        public int FinishedProductID { get; set; }
        public System.DateTime EntryDate { get; set; }
        public int LocationID { get; set; }
        public int CustomerID { get; set; }
        public int CrucialWorkerID { get; set; }
        public int FirmOrderID { get; set; }
        public int FirmOrderDetailID { get; set; }
        public int PlannedOrderID { get; set; }
        public int PlannedOrderDetailID { get; set; }
        public int SemifinishedProductID { get; set; }
        public int SemifinishedProductDetailID { get; set; }
        public int SemifinishedHandoverID { get; set; }
        public Nullable<int> FinishedHandoverID { get; set; }
        public int CommodityID { get; set; }
        public int CommodityTypeID { get; set; }
        public int PiecePerPack { get; set; }
        public decimal Quantity { get; set; }
        public decimal QuantityFailure { get; set; }
        public decimal Swarfs { get; set; }
        public decimal QuantityReceipted { get; set; }
        public string Remarks { get; set; }
        public bool Approved { get; set; }
        public bool HandoverApproved { get; set; }
        public Nullable<int> FinishedProductPackageID { get; set; }
    
        public virtual Commodity Commodity { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FinishedHandoverDetail> FinishedHandoverDetails { get; set; }
        public virtual FinishedProduct FinishedProduct { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GoodsReceiptDetail> GoodsReceiptDetails { get; set; }
    }
}
