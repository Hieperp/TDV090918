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
    
    public partial class Commodity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Commodity()
        {
            this.AccountInvoiceDetails = new HashSet<AccountInvoiceDetail>();
            this.CreditNoteDetails = new HashSet<CreditNoteDetail>();
            this.DeliveryAdviceDetails = new HashSet<DeliveryAdviceDetail>();
            this.GoodsIssueDetails = new HashSet<GoodsIssueDetail>();
            this.GoodsReceiptDetails = new HashSet<GoodsReceiptDetail>();
            this.MaterialIssueDetails = new HashSet<MaterialIssueDetail>();
            this.MaterialIssues = new HashSet<MaterialIssue>();
            this.PurchaseRequisitionDetails = new HashSet<PurchaseRequisitionDetail>();
            this.SalesOrderDetails = new HashSet<SalesOrderDetail>();
            this.SalesReturnDetails = new HashSet<SalesReturnDetail>();
            this.WarehouseAdjustmentDetails = new HashSet<WarehouseAdjustmentDetail>();
            this.BomDetails = new HashSet<BomDetail>();
            this.BomDetails1 = new HashSet<BomDetail>();
            this.Boms = new HashSet<Bom>();
            this.FirmOrderDetails = new HashSet<FirmOrderDetail>();
            this.FirmOrderMaterials = new HashSet<FirmOrderMaterial>();
            this.PlannedOrderDetails = new HashSet<PlannedOrderDetail>();
        }
    
        public int CommodityID { get; set; }
        public int NMVNTaskID { get; set; }
        public string Code { get; set; }
        public string OfficialCode { get; set; }
        public string CodePartA { get; set; }
        public string CodePartB { get; set; }
        public string CodePartC { get; set; }
        public string CodePartD { get; set; }
        public string CodePartE { get; set; }
        public string CodePartF { get; set; }
        public string Name { get; set; }
        public string OfficialName { get; set; }
        public string OriginalName { get; set; }
        public Nullable<int> PreviousCommodityID { get; set; }
        public int CommodityBrandID { get; set; }
        public int CommodityCategoryID { get; set; }
        public int CommodityTypeID { get; set; }
        public int CommodityClassID { get; set; }
        public int CommodityLineID { get; set; }
        public int SupplierID { get; set; }
        public int PiecePerPack { get; set; }
        public decimal QuantityAlert { get; set; }
        public decimal ListedPrice { get; set; }
        public decimal GrossPrice { get; set; }
        public string PurchaseUnit { get; set; }
        public string SalesUnit { get; set; }
        public string Packing { get; set; }
        public string Origin { get; set; }
        public Nullable<double> Weight { get; set; }
        public Nullable<double> LeadTime { get; set; }
        public string HSCode { get; set; }
        public bool Discontinue { get; set; }
        public string Remarks { get; set; }
        public bool InActive { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AccountInvoiceDetail> AccountInvoiceDetails { get; set; }
        public virtual CommodityBrand CommodityBrand { get; set; }
        public virtual CommodityCategory CommodityCategory { get; set; }
        public virtual CommodityClass CommodityClass { get; set; }
        public virtual CommodityLine CommodityLine { get; set; }
        public virtual CommodityType CommodityType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CreditNoteDetail> CreditNoteDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DeliveryAdviceDetail> DeliveryAdviceDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GoodsIssueDetail> GoodsIssueDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GoodsReceiptDetail> GoodsReceiptDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaterialIssueDetail> MaterialIssueDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaterialIssue> MaterialIssues { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseRequisitionDetail> PurchaseRequisitionDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesOrderDetail> SalesOrderDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesReturnDetail> SalesReturnDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WarehouseAdjustmentDetail> WarehouseAdjustmentDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BomDetail> BomDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BomDetail> BomDetails1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bom> Boms { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FirmOrderDetail> FirmOrderDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FirmOrderMaterial> FirmOrderMaterials { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlannedOrderDetail> PlannedOrderDetails { get; set; }
    }
}
