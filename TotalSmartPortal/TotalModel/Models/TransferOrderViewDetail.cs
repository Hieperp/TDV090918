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
    
    public partial class TransferOrderViewDetail
    {
        public int TransferOrderDetailID { get; set; }
        public int TransferOrderID { get; set; }
        public int CommodityID { get; set; }
        public string CommodityCode { get; set; }
        public string CommodityName { get; set; }
        public int CommodityTypeID { get; set; }
        public decimal QuantityAvailables { get; set; }
        public decimal Quantity { get; set; }
        public string Remarks { get; set; }
        public Nullable<int> VoidTypeID { get; set; }
        public string VoidTypeCode { get; set; }
        public string VoidTypeName { get; set; }
        public Nullable<int> VoidClassID { get; set; }
    }
}
