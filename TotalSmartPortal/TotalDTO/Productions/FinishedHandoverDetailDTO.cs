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
        public Nullable<int> FinishedProductPackageID { get; set; }

        [Display(Name = "Ngày ĐG")]
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
