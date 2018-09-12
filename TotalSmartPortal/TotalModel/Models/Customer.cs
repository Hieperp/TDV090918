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
    
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            this.AccountInvoices = new HashSet<AccountInvoice>();
            this.AccountInvoices1 = new HashSet<AccountInvoice>();
            this.AccountInvoices2 = new HashSet<AccountInvoice>();
            this.CreditNotes = new HashSet<CreditNote>();
            this.DeliveryAdvices = new HashSet<DeliveryAdvice>();
            this.DeliveryAdvices1 = new HashSet<DeliveryAdvice>();
            this.GoodsDeliveries = new HashSet<GoodsDelivery>();
            this.GoodsIssues = new HashSet<GoodsIssue>();
            this.GoodsIssues1 = new HashSet<GoodsIssue>();
            this.HandlingUnits = new HashSet<HandlingUnit>();
            this.HandlingUnits1 = new HashSet<HandlingUnit>();
            this.Receipts = new HashSet<Receipt>();
            this.SalesOrders = new HashSet<SalesOrder>();
            this.SalesOrders1 = new HashSet<SalesOrder>();
            this.SalesReturns = new HashSet<SalesReturn>();
            this.SalesReturns1 = new HashSet<SalesReturn>();
            this.GoodsReceipts = new HashSet<GoodsReceipt>();
            this.PurchaseRequisitions = new HashSet<PurchaseRequisition>();
            this.WarehouseAdjustments = new HashSet<WarehouseAdjustment>();
            this.FirmOrderDetails = new HashSet<FirmOrderDetail>();
            this.FirmOrderMaterials = new HashSet<FirmOrderMaterial>();
            this.FirmOrders = new HashSet<FirmOrder>();
            this.MaterialIssues = new HashSet<MaterialIssue>();
            this.PlannedOrderDetails = new HashSet<PlannedOrderDetail>();
            this.PlannedOrders = new HashSet<PlannedOrder>();
            this.ProductionOrderDetails = new HashSet<ProductionOrderDetail>();
            this.ProductionOrders = new HashSet<ProductionOrder>();
            this.MaterialIssueDetails = new HashSet<MaterialIssueDetail>();
        }
    
        public int CustomerID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string OfficialName { get; set; }
        public string VendorCode { get; set; }
        public string VendorCategory { get; set; }
        public int PriceCategoryID { get; set; }
        public int PaymentTermID { get; set; }
        public Nullable<int> MonetaryAccountID { get; set; }
        public int SalespersonID { get; set; }
        public int CustomerCategoryID { get; set; }
        public int CustomerTypeID { get; set; }
        public int TerritoryID { get; set; }
        public string BillingAddress { get; set; }
        public string ShippingAddress { get; set; }
        public string VATCode { get; set; }
        public string Telephone { get; set; }
        public string Facsimile { get; set; }
        public string AttentionName { get; set; }
        public string AttentionTitle { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public Nullable<double> LimitAmount { get; set; }
        public string Remarks { get; set; }
        public bool InActive { get; set; }
        public bool IsCustomer { get; set; }
        public bool IsSupplier { get; set; }
        public bool IsFemale { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AccountInvoice> AccountInvoices { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AccountInvoice> AccountInvoices1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AccountInvoice> AccountInvoices2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CreditNote> CreditNotes { get; set; }
        public virtual CustomerCategory CustomerCategory { get; set; }
        public virtual CustomerType CustomerType { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual EntireTerritory EntireTerritory { get; set; }
        public virtual PriceCategory PriceCategory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DeliveryAdvice> DeliveryAdvices { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DeliveryAdvice> DeliveryAdvices1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GoodsDelivery> GoodsDeliveries { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GoodsIssue> GoodsIssues { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GoodsIssue> GoodsIssues1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HandlingUnit> HandlingUnits { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HandlingUnit> HandlingUnits1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Receipt> Receipts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesOrder> SalesOrders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesOrder> SalesOrders1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesReturn> SalesReturns { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesReturn> SalesReturns1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GoodsReceipt> GoodsReceipts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseRequisition> PurchaseRequisitions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WarehouseAdjustment> WarehouseAdjustments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FirmOrderDetail> FirmOrderDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FirmOrderMaterial> FirmOrderMaterials { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FirmOrder> FirmOrders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaterialIssue> MaterialIssues { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlannedOrderDetail> PlannedOrderDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlannedOrder> PlannedOrders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductionOrderDetail> ProductionOrderDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductionOrder> ProductionOrders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaterialIssueDetail> MaterialIssueDetails { get; set; }
    }
}
