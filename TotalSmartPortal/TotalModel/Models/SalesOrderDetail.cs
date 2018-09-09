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
    
    public partial class SalesOrderDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SalesOrderDetail()
        {
            this.DeliveryAdviceDetails = new HashSet<DeliveryAdviceDetail>();
        }
    
        public int SalesOrderDetailID { get; set; }
        public System.DateTime EntryDate { get; set; }
        public int LocationID { get; set; }
        public int SalesOrderID { get; set; }
        public int CustomerID { get; set; }
        public int ReceiverID { get; set; }
        public Nullable<int> QuotationDetailID { get; set; }
        public int CommodityID { get; set; }
        public int CommodityTypeID { get; set; }
        public Nullable<int> WarehouseID { get; set; }
        public Nullable<int> PromotionID { get; set; }
        public int SalespersonID { get; set; }
        public int CalculatingTypeID { get; set; }
        public bool VATbyRow { get; set; }
        public decimal Quantity { get; set; }
        public decimal QuantityAdvice { get; set; }
        public decimal ControlFreeQuantity { get; set; }
        public decimal FreeQuantity { get; set; }
        public decimal FreeQuantityAdvice { get; set; }
        public decimal ListedPrice { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TradeDiscountRate { get; set; }
        public decimal VATPercent { get; set; }
        public decimal ListedGrossPrice { get; set; }
        public decimal GrossPrice { get; set; }
        public decimal ListedAmount { get; set; }
        public decimal Amount { get; set; }
        public decimal ListedVATAmount { get; set; }
        public decimal VATAmount { get; set; }
        public decimal ListedGrossAmount { get; set; }
        public decimal GrossAmount { get; set; }
        public Nullable<bool> IsBonus { get; set; }
        public string Remarks { get; set; }
        public Nullable<int> VoidTypeID { get; set; }
        public bool Approved { get; set; }
        public bool InActive { get; set; }
        public bool InActivePartial { get; set; }
        public Nullable<System.DateTime> InActivePartialDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DeliveryAdviceDetail> DeliveryAdviceDetails { get; set; }
        public virtual SalesOrder SalesOrder { get; set; }
        public virtual VoidType VoidType { get; set; }
        public virtual Commodity Commodity { get; set; }
    }
}
