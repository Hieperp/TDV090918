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
    
    public partial class BomDetail
    {
        public int BomDetailID { get; set; }
        public int BomID { get; set; }
        public int MaterialID { get; set; }
        public decimal BlockUnit { get; set; }
        public decimal BlockQuantity { get; set; }
        public string Remarks { get; set; }
        public bool InActive { get; set; }
    
        public virtual Bom Bom { get; set; }
        public virtual Commodity Commodity { get; set; }
    }
}
