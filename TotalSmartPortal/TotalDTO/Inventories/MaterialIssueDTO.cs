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
    public class MaterialIssuePrimitiveDTO : QuantityDTO<MaterialIssueDetailDTO>, IPrimitiveEntity, IPrimitiveDTO
    {
        public virtual GlobalEnums.NmvnTaskID NMVNTaskID { get { return GlobalEnums.NmvnTaskID.MaterialIssue; } }

        public int GetID() { return this.MaterialIssueID; }
        public void SetID(int id) { this.MaterialIssueID = id; }

        public int MaterialIssueID { get; set; }

        public int MaterialIssueTypeID { get; set; }

        public virtual Nullable<int> CustomerID { get; set; }

        public int ProductionOrderID { get; set; }
        public int ProductionOrderDetailID { get; set; }

        public int PlannedOrderID { get; set; }

        public int FirmOrderID { get; set; }
        public string FirmOrderReference { get; set; }
        public string FirmOrderCode { get; set; }
        public DateTime FirmOrderEntryDate { get; set; }
        public string FirmOrderSpecification { get; set; }
        

        [Display(Name = "Số chứng từ")]
        [UIHint("Commons/SOCode")]
        public string Code { get; set; }

        public virtual int WorkshiftID { get; set; }
        [Display(Name = "Ca sản xuất")]
        public string WorkshiftCode { get; set; }

        public virtual int ProductionLineID { get; set; }
        [Display(Name = "Line")]
        public string ProductionLineCode { get; set; }

        public virtual Nullable<int> WarehouseID { get; set; }

        public virtual int StorekeeperID { get; set; }

        public override void PerformPresaveRule()
        {
            base.PerformPresaveRule();

            this.DtoDetails().ToList().ForEach(e => { e.MaterialIssueTypeID = this.MaterialIssueTypeID; e.PlannedOrderID = this.PlannedOrderID; e.FirmOrderID = this.FirmOrderID; e.ProductionOrderID = this.ProductionOrderID; e.ProductionOrderDetailID = this.ProductionOrderDetailID; e.CustomerID = this.CustomerID; e.WorkshiftID = this.WorkshiftID; e.ProductionLineID = this.ProductionLineID; e.WarehouseID = this.WarehouseID; });
        }
    }


    public class MaterialIssueDTO : MaterialIssuePrimitiveDTO, IBaseDetailEntity<MaterialIssueDetailDTO>
    {
        public MaterialIssueDTO()
        {
            this.MaterialIssueViewDetails = new List<MaterialIssueDetailDTO>();
        }

        public override Nullable<int> CustomerID { get { return (this.Customer != null ? (this.Customer.CustomerID > 0 ? (Nullable<int>)this.Customer.CustomerID : null) : null); } }
        [Display(Name = "Khách hàng")]
        [UIHint("Commons/CustomerBase")]
        public CustomerBaseDTO Customer { get; set; }

        public override Nullable<int> WarehouseID { get { return (this.Warehouse != null ? this.Warehouse.WarehouseID : null); } }
        [Display(Name = "Kho hàng")]
        [UIHint("AutoCompletes/WarehouseBase")]
        public WarehouseBaseDTO Warehouse { get; set; }

        public override int StorekeeperID { get { return (this.Storekeeper != null ? this.Storekeeper.EmployeeID : 0); } }
        [Display(Name = "Nhân viên kho")]
        [UIHint("AutoCompletes/EmployeeBase")]
        public EmployeeBaseDTO Storekeeper { get; set; }


        public List<MaterialIssueDetailDTO> MaterialIssueViewDetails { get; set; }
        public List<MaterialIssueDetailDTO> ViewDetails { get { return this.MaterialIssueViewDetails; } set { this.MaterialIssueViewDetails = value; } }

        public ICollection<MaterialIssueDetailDTO> GetDetails() { return this.MaterialIssueViewDetails; }

        protected override IEnumerable<MaterialIssueDetailDTO> DtoDetails() { return this.MaterialIssueViewDetails; }
    }
}