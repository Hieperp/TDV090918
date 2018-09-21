using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;

using TotalModel;
using TotalDTO.Helpers;

namespace TotalDTO.Productions
{  
    public class FinishedProductDetailDTO : QuantityDetailDTO, IPrimitiveEntity
    {
        public int GetID() { return this.FinishedProductDetailID; }

        public int FinishedProductDetailID { get; set; }
        public int FinishedProductID { get; set; }                          

        public int FirmOrderID { get; set; }
        public int FirmOrderDetailID { get; set; }

        public int PlannedOrderID { get; set; }
        public int PlannedOrderDetailID { get; set; }

        public int SemifinishedProductID { get; set; }
        public int SemifinishedProductDetailID { get; set; }
     
        public int CrucialWorkerID { get; set; }

        public int SemifinishedHandoverID { get; set; }
        public Nullable<int> FinishedHandoverID { get; set; }
        
        [Display(Name = "Ca sản xuất")]
        [UIHint("StringReadonly")]
        public string WorkshiftCode { get; set; }
        [Display(Name = "Ngày sản xuất")]
        [UIHint("DateTimeReadonly")]
        public DateTime WorkshiftEntryDate { get; set; }
        
        [Display(Name = "Lô SX")]
        [UIHint("StringReadonly")]
        public string GoodsReceiptReference { get; set; }
        [Display(Name = "Mã NK")]
        [UIHint("StringReadonly")]
        public string GoodsReceiptCode { get; set; }
        [Display(Name = "Ngày NK")]
        [UIHint("DateTimeReadonly")]
        public Nullable<System.DateTime> GoodsReceiptEntryDate { get; set; }

        [Display(Name = "Ngày lô hàng")]
        [UIHint("DateTimeReadonly")]
        public System.DateTime BatchEntryDate { get; set; }

        [Display(Name = "SL Nhập")]
        [UIHint("QuantityReadonly")]
        public decimal QuantityIssue { get; set; }

        [Display(Name = "Tồn đơn")]
        [UIHint("QuantityReadonly")]
        public decimal QuantityRemains { get; set; }

        [Display(Name = "SL (Cái)")]
        [UIHint("DecimalN0")]
        public override decimal Quantity { get; set; }           


        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            foreach (var result in base.Validate(validationContext)) { yield return result; }

            if (this.Quantity > this.QuantityRemains) yield return new ValidationResult("Số lượng nhập không được lớn hơn số lượng tồn đơn [" + this.CommodityName + "]", new[] { "Quantity" });
        }
    }
}
