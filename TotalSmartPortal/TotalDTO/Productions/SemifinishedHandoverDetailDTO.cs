using System;
using System.ComponentModel.DataAnnotations;

using TotalModel;
using TotalDTO.Helpers;
using TotalDTO.Commons;

namespace TotalDTO.Productions
{
    public class SemifinishedHandoverDetailDTO : QuantityDetailDTO, IPrimitiveEntity
    {
        public int GetID() { return this.SemifinishedHandoverDetailID; }

        public int SemifinishedHandoverDetailID { get; set; }
        public int SemifinishedHandoverID { get; set; }
       
        public Nullable<int> SemifinishedProductID { get; set; }
        public Nullable<int> SemifinishedProductDetailID { get; set; }

        [Display(Name = "Số BTP")]
        [UIHint("StringReadonly")]
        public string SemifinishedProductReference { get; set; }
        [Display(Name = "Mã BTP")]
        [UIHint("StringReadonly")]
        public string SemifinishedProductCode { get; set; }
        [Display(Name = "Ngày BTP")]
        [UIHint("DateTimeReadonly")]
        public Nullable<System.DateTime> SemifinishedProductEntryDate { get; set; }

        public int CustomerID { get; set; }
        [Display(Name = "Mã khách hàng")]
        public string CustomerCode { get; set; }
        [Display(Name = "Tên khách hàng")]
        [UIHint("StringReadonly")]
        public string CustomerName { get; set; }

        public int CrucialWorkerID { get; set; }


        [Display(Name = "SL xuất")]
        [UIHint("QuantityReadonly")]
        public decimal QuantityIssue { get; set; }

        public virtual int ShiftID { get; set; }

        public virtual int WorkshiftID { get; set; }
     
    }
}
