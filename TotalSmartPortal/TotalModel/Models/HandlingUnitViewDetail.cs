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
    
    public partial class HandlingUnitViewDetail
    {
        public int HandlingUnitDetailID { get; set; }
        public int HandlingUnitID { get; set; }
        public int GoodsIssueID { get; set; }
        public int GoodsIssueDetailID { get; set; }
        public string GoodsIssueReference { get; set; }
        public string GoodsIssueCode { get; set; }
        public System.DateTime GoodsIssueEntryDate { get; set; }
        public int CommodityID { get; set; }
        public string CommodityCode { get; set; }
        public string CommodityName { get; set; }
        public int CommodityTypeID { get; set; }
        public Nullable<decimal> QuantityRemains { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitWeight { get; set; }
        public decimal Weight { get; set; }
        public string Remarks { get; set; }
    }
}
