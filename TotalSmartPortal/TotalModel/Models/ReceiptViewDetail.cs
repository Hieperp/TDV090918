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
    
    public partial class ReceiptViewDetail
    {
        public int GoodsIssueID { get; set; }
        public System.DateTime GoodsIssueEntryDate { get; set; }
        public string GoodsIssueReference { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public int ReceiverID { get; set; }
        public string ReceiverName { get; set; }
        public string Description { get; set; }
        public int ReceiptDetailID { get; set; }
        public int ReceiptID { get; set; }
        public string Remarks { get; set; }
        public decimal TotalGrossAmount { get; set; }
        public Nullable<decimal> AmountDue { get; set; }
        public decimal ReceiptAmount { get; set; }
        public decimal CashDiscount { get; set; }
        public decimal OtherDiscount { get; set; }
        public decimal FluctuationAmount { get; set; }
    }
}
