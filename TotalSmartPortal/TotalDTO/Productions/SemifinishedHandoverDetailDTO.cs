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

        public override int CrucialWorkerID { get { return (this.CrucialWorker != null ? this.CrucialWorker.EmployeeID : 0); } }
        [Display(Name = "Nhân viên kho")]
        [UIHint("AutoCompletes/EmployeeBase")]
        public EmployeeBaseDTO CrucialWorker { get; set; }

        [Display(Name = "SL xuất")]
        [UIHint("QuantityReadonly")]
        public decimal QuantityIssue { get; set; }

        public virtual int ShiftID { get; set; }

        public virtual int WorkshiftID { get; set; }
     
    }
}
