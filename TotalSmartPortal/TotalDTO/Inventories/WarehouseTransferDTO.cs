using System;
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
    public interface IWTOption { GlobalEnums.NmvnTaskID NMVNTaskID { get; } }

    public class WTOptionMaterial : IWTOption { public GlobalEnums.NmvnTaskID NMVNTaskID { get { return GlobalEnums.NmvnTaskID.MaterialTransfer; } } }
    public class WTOptionItem : IWTOption { public GlobalEnums.NmvnTaskID NMVNTaskID { get { return GlobalEnums.NmvnTaskID.ItemTransfer; } } }
    public class WTOptionProduct : IWTOption { public GlobalEnums.NmvnTaskID NMVNTaskID { get { return GlobalEnums.NmvnTaskID.ProductTransfer; } } }                        

    public interface IWarehouseTransferPrimitiveDTO : IQuantityDTO, IPrimitiveEntity, IPrimitiveDTO, IBaseDTO
    {
        int WarehouseTransferID { get; set; }
        int WarehouseTransferTypeID { get; set; }
        Nullable<int> WarehouseID { get; set; }
        Nullable<int> WarehouseReceiptID { get; set; }
        Nullable<int> CustomerID { get; set; }
        Nullable<int> TransferOrderID { get; set; }

        [Display(Name = "Mục đích")]
        string AdjustmentJobs { get; set; }
        int StorekeeperID { get; set; }
    }

    public class WarehouseTransferPrimitiveDTO<TWTOption> : QuantityDTO<WarehouseTransferDetailDTO>, IPrimitiveEntity, IPrimitiveDTO
        where TWTOption : IWTOption, new()
    {
        public virtual GlobalEnums.NmvnTaskID NMVNTaskID { get { return new TWTOption().NMVNTaskID; } }

        public int GetID() { return this.WarehouseTransferID; }
        public void SetID(int id) { this.WarehouseTransferID = id; }

        public int WarehouseTransferID { get; set; }

        public int WarehouseTransferTypeID { get; set; }

        public virtual Nullable<int> WarehouseID { get; set; }
        public virtual Nullable<int> WarehouseReceiptID { get; set; }
        public virtual Nullable<int> CustomerID { get; set; }

        public virtual Nullable<int> TransferOrderID { get; set; }

        public string AdjustmentJobs { get; set; }

        public virtual int StorekeeperID { get; set; }

        public override void PerformPresaveRule()
        {
            base.PerformPresaveRule();

            this.DtoDetails().ToList().ForEach(e => { e.WarehouseTransferTypeID = this.WarehouseTransferTypeID; e.NMVNTaskID = this.NMVNTaskID; e.WarehouseID = (int)this.WarehouseID; e.WarehouseReceiptID = this.WarehouseReceiptID; e.CustomerID = this.CustomerID; });
        }

    }

    public interface IWarehouseTransferDTO : IWarehouseTransferPrimitiveDTO, IMaterialItemProduct
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

        List<WarehouseTransferDetailDTO> WarehouseTransferViewDetails { get; set; }
        List<WarehouseTransferDetailDTO> ViewDetails { get; set; }
        
        [UIHint("AutoCompletes/VoidType")]
        VoidTypeBaseDTO VoidType { get; set; }

        string ControllerName { get; }

        bool IsMaterial { get; }
        bool IsItem { get; }
        bool IsProduct { get; }
    }

    public class WarehouseTransferDTO<TWTOption> : WarehouseTransferPrimitiveDTO<TWTOption>, IBaseDetailEntity<WarehouseTransferDetailDTO>, IWarehouseTransferDTO
        where TWTOption : IWTOption, new()
    {
        public WarehouseTransferDTO()
        {
            this.WarehouseTransferViewDetails = new List<WarehouseTransferDetailDTO>();
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

        public List<WarehouseTransferDetailDTO> WarehouseTransferViewDetails { get; set; }
        public List<WarehouseTransferDetailDTO> ViewDetails { get { return this.WarehouseTransferViewDetails; } set { this.WarehouseTransferViewDetails = value; } }

        public ICollection<WarehouseTransferDetailDTO> GetDetails() { return this.WarehouseTransferViewDetails; }

        protected override IEnumerable<WarehouseTransferDetailDTO> DtoDetails() { return this.WarehouseTransferViewDetails; }



        public string ControllerName { get { return this.NMVNTaskID.ToString() + "s"; } }


        public bool IsMaterial { get { return this.NMVNTaskID == GlobalEnums.NmvnTaskID.MaterialTransfer; } }
        public bool IsItem { get { return this.NMVNTaskID == GlobalEnums.NmvnTaskID.ItemTransfer; } }
        public bool IsProduct { get { return this.NMVNTaskID == GlobalEnums.NmvnTaskID.ProductTransfer; } }
    }

}
