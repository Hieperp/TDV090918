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
    
    public partial class SemifinishedHandoverViewDetail
    {
        public int SemifinishedHandoverDetailID { get; set; }
        public int SemifinishedHandoverID { get; set; }
        public int SemifinishedProductID { get; set; }
        public int CustomerID { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public int ProductionLineID { get; set; }
        public string ProductionLineCode { get; set; }
        public decimal Quantity { get; set; }
        public string Remarks { get; set; }
        public int CrucialWorkerID { get; set; }
        public string CrucialWorkerName { get; set; }
        public string SemifinishedProductReference { get; set; }
        public System.DateTime SemifinishedProductEntryDate { get; set; }
    }
}
