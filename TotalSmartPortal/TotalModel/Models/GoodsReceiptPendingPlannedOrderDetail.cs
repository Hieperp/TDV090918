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
    
    public partial class GoodsReceiptPendingPlannedOrderDetail
    {
        public int FinishedProductID { get; set; }
        public System.DateTime FinishedProductEntryDate { get; set; }
        public int CommodityID { get; set; }
        public string CommodityCode { get; set; }
        public string CommodityName { get; set; }
        public int CommodityTypeID { get; set; }
        public Nullable<decimal> QuantityRemains { get; set; }
        public decimal Quantity { get; set; }
        public string Remarks { get; set; }
        public Nullable<bool> IsSelected { get; set; }
        public int FinishedProductPackageID { get; set; }
        public string FirmOrderReference { get; set; }
        public string FirmOrderCode { get; set; }
        public string Caption { get; set; }
    }
}
