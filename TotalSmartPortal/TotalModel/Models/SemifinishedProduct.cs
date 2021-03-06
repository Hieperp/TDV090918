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
    
    public partial class SemifinishedProduct
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SemifinishedProduct()
        {
            this.SemifinishedProductDetails = new HashSet<SemifinishedProductDetail>();
            this.SemifinishedHandoverDetails = new HashSet<SemifinishedHandoverDetail>();
        }
    
        public int SemifinishedProductID { get; set; }
        public System.DateTime EntryDate { get; set; }
        public string Reference { get; set; }
        public int CustomerID { get; set; }
        public int MaterialIssueID { get; set; }
        public int MaterialIssueDetailID { get; set; }
        public int FirmOrderID { get; set; }
        public int GoodsReceiptID { get; set; }
        public int GoodsReceiptDetailID { get; set; }
        public int ShiftID { get; set; }
        public int WorkshiftID { get; set; }
        public int ProductionLineID { get; set; }
        public int CrucialWorkerID { get; set; }
        public int UserID { get; set; }
        public int PreparedPersonID { get; set; }
        public int OrganizationalUnitID { get; set; }
        public int LocationID { get; set; }
        public int ApproverID { get; set; }
        public decimal StartSequenceNo { get; set; }
        public decimal StopSequenceNo { get; set; }
        public decimal FoilCounts { get; set; }
        public decimal FoilUnitCounts { get; set; }
        public decimal FoilUnitWeights { get; set; }
        public decimal FoilWeights { get; set; }
        public decimal FailureWeights { get; set; }
        public decimal TotalQuantity { get; set; }
        public decimal TotalQuantityFinished { get; set; }
        public string Description { get; set; }
        public string Remarks { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime EditedDate { get; set; }
        public bool Approved { get; set; }
        public Nullable<System.DateTime> ApprovedDate { get; set; }
        public Nullable<int> SemifinishedHandoverID { get; set; }
        public bool HandoverApproved { get; set; }
        public string Caption { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual FirmOrder FirmOrder { get; set; }
        public virtual Location Location { get; set; }
        public virtual MaterialIssueDetail MaterialIssueDetail { get; set; }
        public virtual ProductionLine ProductionLine { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SemifinishedProductDetail> SemifinishedProductDetails { get; set; }
        public virtual Shift Shift { get; set; }
        public virtual Workshift Workshift { get; set; }
        public virtual GoodsReceipt GoodsReceipt { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SemifinishedHandoverDetail> SemifinishedHandoverDetails { get; set; }
        public virtual GoodsReceiptDetail GoodsReceiptDetail { get; set; }
    }
}
