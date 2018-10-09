using System;
using System.ComponentModel.DataAnnotations;

using TotalModel;
using TotalDTO.Helpers;

namespace TotalDTO.Productions
{
    public class ProductionOrderDetailDTO : QuantityDetailDTO, IPrimitiveEntity
    {
        public int GetID() { return this.ProductionOrderDetailID; }

        public int ProductionOrderDetailID { get; set; }
        public int ProductionOrderID { get; set; }

        public Nullable<int> PlannedOrderID { get; set; }
        public Nullable<int> FirmOrderID { get; set; }

        [Display(Name = "KHSX")]
        [UIHint("StringReadonly")]
        public string FirmOrderReference { get; set; }
        [Display(Name = "Mã CT")]
        [UIHint("StringReadonly")]
        public string FirmOrderCode { get; set; }
        [Display(Name = "Ngày KH")]
        [UIHint("DateTimeReadonly")]
        public Nullable<System.DateTime> FirmOrderEntryDate { get; set; }

        public int CustomerID { get; set; }
        [Display(Name = "Mã khách hàng")]
        [Required(ErrorMessage = "Vui lòng chọn khách hàng")]
        [UIHint("AutoCompletes/CustomerBasic")]
        public virtual string CustomerCode { get; set; }

        [Display(Name = "Tên khách hàng")]
        [UIHint("StringReadonly")]
        public virtual string CustomerName { get; set; }

        [Display(Name = "Tên hàng")]
        [UIHint("StringReadonly")]
        public virtual string Specs { get; set; }

        [Display(Name = "Mã hàng")]
        [UIHint("StringReadonly")]
        public virtual string Specification { get; set; }

        public int BomID { get; set; }
        [Display(Name = "Mã khuôn")]
        [Required(ErrorMessage = "Vui lòng chọn mã nguyên liệu")]
        [UIHint("StringReadonly")]
        public virtual string BomCode { get; set; }

        public string VoidTypeCode { get; set; }
        [Display(Name = "Lý do")]
        [UIHint("AutoCompletes/VoidTypeBase")]
        public string VoidTypeName { get; set; }
        public Nullable<int> VoidClassID { get; set; }

        [Display(Name = "Tồn đơn")]
        [UIHint("QuantityReadonly")]
        public decimal QuantityRemains { get; set; }

        #region NO USE
        public override int CommodityID { get { return 1; } set { } } 
        public override string CommodityCode { get { return "#"; } set { } } 
        public override int CommodityTypeID { get { return 1; } set { } } 

        public override decimal Quantity { get { return 0; } set { } } 
        #endregion NO USE
    }
}

