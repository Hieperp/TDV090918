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
    
    public partial class SemifinishedHandoverPendingDetail
    {
        public int SemifinishedProductID { get; set; }
        public int SemifinishedProductDetailID { get; set; }
        public System.DateTime EntryDate { get; set; }
        public int CustomerID { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public int CommodityID { get; set; }
        public string CommodityCode { get; set; }
        public int ProductionLineID { get; set; }
        public string ProductionLineCode { get; set; }
        public decimal Quantity { get; set; }
        public Nullable<bool> IsSelected { get; set; }
        public int CrucialWorkerID { get; set; }
        public string CrucialWorkerName { get; set; }
    }
}
