using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;

using TotalModel;
using TotalDTO.Helpers;

namespace TotalDTO.Productions
{
    public class SemifinishedProductDetailDTO : QuantityDetailDTO, IPrimitiveEntity
    {
        public int GetID() { return this.SemifinishedProductDetailID; }        

        public int SemifinishedProductDetailID { get; set; }
        public int SemifinishedProductID { get; set; }

        public int MaterialIssueID { get; set; }
        public int MaterialIssueDetailID { get; set; }

        public int FirmOrderID { get; set; }
        public int FirmOrderDetailID { get; set; }

        public int PlannedOrderDetailID { get; set; }

        public int GoodsReceiptID { get; set; }
        public int GoodsReceiptDetailID { get; set; }
        public Nullable<int> CustomerID { get; set; }

        public int WorkshiftID { get; set; }
        public int ProductionLineID { get; set; }
        public int CrucialWorkerID { get; set; }

        public Nullable<int> SemifinishedHandoverID { get; set; }      
        public decimal QuantityRejectedReturned { get; set; }

        [Display(Name = "Tồn đơn")]
        [UIHint("QuantityReadonly")]
        public decimal QuantityRemains { get; set; }
        [Display(Name = "SL (Cái)")]
        [UIHint("DecimalN0")]
        public override decimal Quantity { get; set; }
        [Display(Name = "Thành phẩm")]
        [UIHint("Quantity")]
        public decimal QuantityGainings { get; set; }
        [Display(Name = "Hao hụt")]
        [UIHint("Quantity")]
        public decimal QuantityWastage { get; set; }
        [Display(Name = "Phế phẩm")]
        [UIHint("Quantity")]
        public decimal QuantityFailure { get; set; }
        [Display(Name = "Trả lại")]
        [UIHint("Quantity")]
        public decimal QuantityRejected { get; set; }


        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            foreach (var result in base.Validate(validationContext)) { yield return result; }

            if (this.Quantity > this.QuantityRemains) yield return new ValidationResult("Số lượng xuất không được lớn hơn số lượng còn lại [" + this.CommodityName + "]", new[] { "Quantity" });
        }
    }
}
