using System;
using System.ComponentModel.DataAnnotations;

using TotalModel;
using TotalDTO.Helpers;
using TotalDTO.Commons;

namespace TotalDTO.Productions
{
    public class FinishedHandoverDetailDTO : QuantityDetailDTO, IPrimitiveEntity
    {
        public int GetID() { return this.FinishedHandoverDetailID; }

        public int FinishedHandoverDetailID { get; set; }
        public int FinishedHandoverID { get; set; }
       
        public Nullable<int> FinishedProductID { get; set; }
        public Nullable<int> FinishedProductDetailID { get; set; }

        [Display(Name = "Số BTP")]
        [UIHint("StringReadonly")]
        public string FinishedProductReference { get; set; }
        [Display(Name = "Mã BTP")]
        [UIHint("StringReadonly")]
        public string FinishedProductCode { get; set; }
        [Display(Name = "Ngày BTP")]
        [UIHint("DateTimeReadonly")]
        public Nullable<System.DateTime> FinishedProductEntryDate { get; set; }

        public int CustomerID { get; set; }
        [Display(Name = "Mã khách hàng")]
        public string CustomerCode { get; set; }
        [Display(Name = "Tên khách hàng")]
        [UIHint("StringReadonly")]
        public string CustomerName { get; set; }
       
    }
}
