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
    using System.Collections.Generic;
    
    public partial class FinishedHandoverDetail
    {
        public int FinishedHandoverDetailID { get; set; }
        public int FinishedHandoverID { get; set; }
        public System.DateTime EntryDate { get; set; }
        public int LocationID { get; set; }
        public int FinishedProductID { get; set; }
        public int FinishedProductDetailID { get; set; }
        public int CommodityID { get; set; }
        public int CommodityTypeID { get; set; }
        public decimal Quantity { get; set; }
        public string Remarks { get; set; }
        public bool Approved { get; set; }
    
        public virtual Commodity Commodity { get; set; }
        public virtual FinishedHandover FinishedHandover { get; set; }
        public virtual FinishedProductDetail FinishedProductDetail { get; set; }
    }
}
