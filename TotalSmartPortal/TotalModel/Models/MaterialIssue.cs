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
    
    public partial class MaterialIssue
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MaterialIssue()
        {
            this.MaterialIssueDetails = new HashSet<MaterialIssueDetail>();
        }
    
        public int MaterialIssueID { get; set; }
        public System.DateTime EntryDate { get; set; }
        public string Reference { get; set; }
        public string Code { get; set; }
        public int MaterialIssueTypeID { get; set; }
        public int WorkshiftID { get; set; }
        public int CustomerID { get; set; }
        public int CommodityID { get; set; }
        public int PlannedOrderID { get; set; }
        public int PlannedOrderDetailID { get; set; }
        public int ProductionOrderID { get; set; }
        public int ProductionOrderDetailID { get; set; }
        public int ProductionLineID { get; set; }
        public int MoldID { get; set; }
        public int WarehouseID { get; set; }
        public int StorekeeperID { get; set; }
        public int UserID { get; set; }
        public int PreparedPersonID { get; set; }
        public int OrganizationalUnitID { get; set; }
        public int LocationID { get; set; }
        public int ApproverID { get; set; }
        public decimal TotalQuantity { get; set; }
        public decimal TotalQuantitySemifinished { get; set; }
        public decimal TotalQuantityWastage { get; set; }
        public decimal TotalQuantityRejected { get; set; }
        public string Description { get; set; }
        public string Remarks { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime EditedDate { get; set; }
        public bool Approved { get; set; }
        public Nullable<System.DateTime> ApprovedDate { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Location Location { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaterialIssueDetail> MaterialIssueDetails { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Mold Mold { get; set; }
        public virtual ProductionLine ProductionLine { get; set; }
        public virtual Workshift Workshift { get; set; }
        public virtual Warehouse Warehouse { get; set; }
        public virtual Commodity Commodity { get; set; }
        public virtual PlannedOrderDetail PlannedOrderDetail { get; set; }
        public virtual PlannedOrder PlannedOrder { get; set; }
        public virtual ProductionOrderDetail ProductionOrderDetail { get; set; }
        public virtual ProductionOrder ProductionOrder { get; set; }
    }
}
