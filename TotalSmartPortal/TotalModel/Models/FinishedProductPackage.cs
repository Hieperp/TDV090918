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
    
    public partial class FinishedProductPackage
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FinishedProductPackage()
        {
            this.FinishedHandoverDetails = new HashSet<FinishedHandoverDetail>();
            this.GoodsReceiptDetails = new HashSet<GoodsReceiptDetail>();
            this.FinishedProductDetails = new HashSet<FinishedProductDetail>();
        }
    
        public int FinishedProductPackageID { get; set; }
        public int FinishedProductID { get; set; }
        public System.DateTime EntryDate { get; set; }
        public int LocationID { get; set; }
        public int CustomerID { get; set; }
        public int FirmOrderID { get; set; }
        public int PlannedOrderID { get; set; }
        public Nullable<int> FinishedHandoverID { get; set; }
        public int CommodityID { get; set; }
        public int CommodityTypeID { get; set; }
        public int PiecePerPack { get; set; }
        public decimal Quantity { get; set; }
        public decimal QuantityFailure { get; set; }
        public decimal Swarfs { get; set; }
        public decimal QuantityReceipted { get; set; }
        public decimal Packages { get; set; }
        public decimal OddPackages { get; set; }
        public decimal QuantityWeights { get; set; }
        public decimal QuantityFailureWeights { get; set; }
        public string Remarks { get; set; }
        public bool Approved { get; set; }
        public bool HandoverApproved { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FinishedHandoverDetail> FinishedHandoverDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GoodsReceiptDetail> GoodsReceiptDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FinishedProductDetail> FinishedProductDetails { get; set; }
    }
}
