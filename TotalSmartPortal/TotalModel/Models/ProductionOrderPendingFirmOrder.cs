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
    
    public partial class ProductionOrderPendingFirmOrder
    {
        public int PlannedOrderID { get; set; }
        public int FirmOrderID { get; set; }
        public string FirmOrderReference { get; set; }
        public string FirmOrderCode { get; set; }
        public System.DateTime FirmOrderEntryDate { get; set; }
        public int CustomerID { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string Specification { get; set; }
        public int BomID { get; set; }
        public string BomCode { get; set; }
        public Nullable<decimal> QuantityRemains { get; set; }
        public string Description { get; set; }
        public string Remarks { get; set; }
        public Nullable<bool> IsSelected { get; set; }
        public string Specs { get; set; }
    }
}
