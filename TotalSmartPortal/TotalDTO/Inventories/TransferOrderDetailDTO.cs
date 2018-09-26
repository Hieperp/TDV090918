using System;
using System.ComponentModel.DataAnnotations;

using TotalModel;
using TotalDTO.Helpers;
using TotalBase.Enums;

namespace TotalDTO.Inventories
{
    public class TransferOrderDetailDTO : QuantityDetailDTO, IPrimitiveEntity
    {
        public int GetID() { return this.TransferOrderDetailID; }

        public int TransferOrderDetailID { get; set; }
        public int TransferOrderID { get; set; }

        public int TransferOrderTypeID { get; set; }
        public GlobalEnums.NmvnTaskID NMVNTaskID { get; set; }

        public int WarehouseID { get; set; }
        public Nullable<int> WarehouseReceiptID { get; set; }

        [UIHint("AutoCompletes/CommodityBase")]
        public override string CommodityCode { get; set; }

        public Nullable<int> CustomerID { get; set; }

        [Display(Name = "Tồn kho")]
        [UIHint("QuantityReadonly")]
        public decimal QuantityAvailables { get; set; }

        [Display(Name = "SL")]
        [UIHint("QuantityWithMinus")]
        public override decimal Quantity { get; set; }
    }
}