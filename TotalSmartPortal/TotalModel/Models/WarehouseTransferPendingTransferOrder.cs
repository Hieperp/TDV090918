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
    
    public partial class WarehouseTransferPendingTransferOrder
    {
        public int TransferOrderID { get; set; }
        public string TransferOrderReference { get; set; }
        public System.DateTime TransferOrderEntryDate { get; set; }
        public int WarehouseID { get; set; }
        public string WarehouseCode { get; set; }
        public int WarehouseReceiptID { get; set; }
        public string WarehouseReceiptCode { get; set; }
        public int CustomerID { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
    }
}
