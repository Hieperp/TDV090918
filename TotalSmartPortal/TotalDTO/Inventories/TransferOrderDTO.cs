﻿using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using TotalModel;
using TotalBase.Enums;
using TotalDTO.Helpers;
using TotalDTO.Commons;
using TotalDTO.Helpers.Interfaces;

namespace TotalDTO.Inventories
{
    public interface ITOOption { GlobalEnums.NmvnTaskID NMVNTaskID { get; } }

    public class TOOptionMaterial : ITOOption { public GlobalEnums.NmvnTaskID NMVNTaskID { get { return GlobalEnums.NmvnTaskID.MaterialTransferOrder; } } }
    public class TOOptionItem : ITOOption { public GlobalEnums.NmvnTaskID NMVNTaskID { get { return GlobalEnums.NmvnTaskID.ItemTransferOrder; } } }
    public class TOOptionProduct : ITOOption { public GlobalEnums.NmvnTaskID NMVNTaskID { get { return GlobalEnums.NmvnTaskID.ProductTransferOrder; } } }

    public interface ITransferOrderPrimitiveDTO : IQuantityDTO, IPrimitiveEntity, IPrimitiveDTO, IBaseDTO
    {
        int TransferOrderID { get; set; }
        int TransferOrderTypeID { get; set; }
        Nullable<int> WarehouseID { get; set; }
        Nullable<int> WarehouseReceiptID { get; set; }
        Nullable<int> CustomerID { get; set; }

        [Display(Name = "Mục đích")]
        string AdjustmentJobs { get; set; }
        int StorekeeperID { get; set; }
    }

    public class TransferOrderPrimitiveDTO<TTOOption> : QuantityDTO<TransferOrderDetailDTO>, IPrimitiveEntity, IPrimitiveDTO
        where TTOOption : ITOOption, new()
    {
        public virtual GlobalEnums.NmvnTaskID NMVNTaskID { get { return new TTOOption().NMVNTaskID; } }

        public int GetID() { return this.TransferOrderID; }
        public void SetID(int id) { this.TransferOrderID = id; }

        public int TransferOrderID { get; set; }

        public int TransferOrderTypeID { get; set; }

        public virtual Nullable<int> WarehouseID { get; set; }
        public virtual Nullable<int> WarehouseReceiptID { get; set; }
        public virtual Nullable<int> CustomerID { get; set; }

        public string AdjustmentJobs { get; set; }

        public virtual int StorekeeperID { get; set; }

        public override void PerformPresaveRule()
        {
            base.PerformPresaveRule();

            this.DtoDetails().ToList().ForEach(e => { e.TransferOrderTypeID = this.TransferOrderTypeID; e.NMVNTaskID = this.NMVNTaskID; e.WarehouseID = (int)this.WarehouseID; e.WarehouseReceiptID = this.WarehouseReceiptID; e.CustomerID = this.CustomerID; });
        }

    }

    public interface ITransferOrderDTO : ITransferOrderPrimitiveDTO
    {
        [Display(Name = "Kho xuất")]
        [UIHint("AutoCompletes/WarehouseBase")]
        WarehouseBaseDTO Warehouse { get; set; }
        [Display(Name = "Kho nhập")]
        [UIHint("AutoCompletes/WarehouseBase")]
        WarehouseBaseDTO WarehouseReceipt { get; set; }
        [Display(Name = "Nhân viên kho")]
        [UIHint("AutoCompletes/EmployeeBase")]
        EmployeeBaseDTO Storekeeper { get; set; }
        [Display(Name = "Khách hàng")]
        [UIHint("Commons/CustomerBase")]
        CustomerBaseDTO Customer { get; set; }

        List<TransferOrderDetailDTO> TransferOrderViewDetails { get; set; }
        List<TransferOrderDetailDTO> ViewDetails { get; set; }
        
        [UIHint("AutoCompletes/VoidType")]
        VoidTypeBaseDTO VoidType { get; set; }

        string ControllerName { get; }

        bool IsMaterial { get; }
        bool IsItem { get; }
        bool IsProduct { get; }
    }

    public class TransferOrderDTO<TTOOption> : TransferOrderPrimitiveDTO<TTOOption>, IBaseDetailEntity<TransferOrderDetailDTO>, ITransferOrderDTO
        where TTOOption : ITOOption, new()
    {
        public TransferOrderDTO()
        {
            this.TransferOrderViewDetails = new List<TransferOrderDetailDTO>();
        }

        public override Nullable<int> WarehouseID { get { return (this.Warehouse != null ? this.Warehouse.WarehouseID : null); } }
        public WarehouseBaseDTO Warehouse { get; set; }

        public override Nullable<int> WarehouseReceiptID { get { return (this.WarehouseReceipt != null ? this.WarehouseReceipt.WarehouseID : null); } }
        public WarehouseBaseDTO WarehouseReceipt { get; set; }

        public override int StorekeeperID { get { return (this.Storekeeper != null ? this.Storekeeper.EmployeeID : 0); } }
        public EmployeeBaseDTO Storekeeper { get; set; }

        public override Nullable<int> CustomerID { get { int? customerID = null; if (this.Customer != null) customerID = this.Customer.CustomerID; return customerID; } }
        public CustomerBaseDTO Customer { get; set; }

        public override Nullable<int> VoidTypeID { get { return (this.VoidType != null ? this.VoidType.VoidTypeID : null); } }        
        public VoidTypeBaseDTO VoidType { get; set; }

        public List<TransferOrderDetailDTO> TransferOrderViewDetails { get; set; }
        public List<TransferOrderDetailDTO> ViewDetails { get { return this.TransferOrderViewDetails; } set { this.TransferOrderViewDetails = value; } }

        public ICollection<TransferOrderDetailDTO> GetDetails() { return this.TransferOrderViewDetails; }

        protected override IEnumerable<TransferOrderDetailDTO> DtoDetails() { return this.TransferOrderViewDetails; }



        public string ControllerName { get { return this.NMVNTaskID.ToString() + "s"; } }


        public bool IsMaterial { get { return this.NMVNTaskID == GlobalEnums.NmvnTaskID.MaterialTransferOrder; } }
        public bool IsItem { get { return this.NMVNTaskID == GlobalEnums.NmvnTaskID.ItemTransferOrder; } }
        public bool IsProduct { get { return this.NMVNTaskID == GlobalEnums.NmvnTaskID.ProductTransferOrder; } }
    }

}
