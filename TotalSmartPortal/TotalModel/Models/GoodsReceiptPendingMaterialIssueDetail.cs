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
    
    public partial class GoodsReceiptPendingMaterialIssueDetail
    {
        public int MaterialIssueID { get; set; }
        public int MaterialIssueDetailID { get; set; }
        public System.DateTime MaterialIssueEntryDate { get; set; }
        public int CommodityID { get; set; }
        public string CommodityCode { get; set; }
        public string CommodityName { get; set; }
        public int CommodityTypeID { get; set; }
        public Nullable<decimal> QuantityRemains { get; set; }
        public decimal Quantity { get; set; }
        public string Remarks { get; set; }
        public Nullable<bool> IsSelected { get; set; }
        public string WorkshiftName { get; set; }
        public System.DateTime WorkshiftEntryDate { get; set; }
        public string ProductionLinesCode { get; set; }
        public string PlannedOrderReference { get; set; }
        public string PlannedOrderCode { get; set; }
    }
}
