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
    
    public partial class FinishedHandoverPendingDetail
    {
        public int FinishedProductID { get; set; }
        public int FinishedProductDetailID { get; set; }
        public System.DateTime EntryDate { get; set; }
        public int CustomerID { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public int CommodityID { get; set; }
        public string CommodityCode { get; set; }
        public int CommodityTypeID { get; set; }
        public decimal Quantity { get; set; }
        public Nullable<bool> IsSelected { get; set; }
    }
}
