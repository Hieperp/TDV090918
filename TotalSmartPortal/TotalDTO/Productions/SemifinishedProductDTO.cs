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

namespace TotalDTO.Productions
{
    public class SemifinishedProductPrimitiveDTO : QuantityDTO<SemifinishedProductDetailDTO>, IPrimitiveEntity, IPrimitiveDTO
    {
        public virtual GlobalEnums.NmvnTaskID NMVNTaskID { get { return GlobalEnums.NmvnTaskID.SemifinishedProduct; } }

        public int GetID() { return this.SemifinishedProductID; }
        public void SetID(int id) { this.SemifinishedProductID = id; }
                               
        public int SemifinishedProductID { get; set; }

        public virtual Nullable<int> CustomerID { get; set; }

        public int MaterialIssueID { get; set; }
        public int MaterialIssueDetailID { get; set; }

        public int FirmOrderID { get; set; }
        [Display(Name = "Số KHSX")]
        public string FirmOrderReference { get; set; }
        [Display(Name = "Mã KHSX")]
        public string FirmOrderCode { get; set; }
        [Display(Name = "Ngày KHSX")]
        public DateTime FirmOrderEntryDate { get; set; }
        [Display(Name = "Thành phẩm khay")]
        public string FirmOrderSpecification { get; set; }

        public int GoodsReceiptID { get; set; }
        [Display(Name = "Số KHSX")]
        [UIHint("StringReadonly")]
        public string GoodsReceiptReference { get; set; }
        [Display(Name = "Mã KHSX")]
        [UIHint("StringReadonly")]
        public string GoodsReceiptCode { get; set; }
        [Display(Name = "Ngày KHSX")]
        [UIHint("DateTimeReadonly")]
        public Nullable<System.DateTime> GoodsReceiptEntryDate { get; set; }
        public int GoodsReceiptDetailID { get; set; }


        [Display(Name = "Số chứng từ")]
        [UIHint("Commons/SOCode")]
        public string Code { get; set; }

        public virtual int WorkshiftID { get; set; }
        [Display(Name = "Ca sản xuất")]
        public string WorkshiftCode { get; set; }
        [Display(Name = "Ngày sản xuất")]
        public DateTime WorkshiftEntryDate { get; set; }

        public virtual int ProductionLineID { get; set; }
        [Display(Name = "Mã số máy")]
        public string ProductionLineCode { get; set; }

        public virtual int SalespersonID { get; set; }

        public decimal TotalQuantityIssue { get; set; }

        public override void PerformPresaveRule()
        {
            base.PerformPresaveRule();

            this.DtoDetails().ToList().ForEach(e => { e.MaterialIssueID = this.MaterialIssueID; e.MaterialIssueDetailID = this.MaterialIssueDetailID; e.FirmOrderID = this.FirmOrderID; e.GoodsReceiptID = this.GoodsReceiptID; e.GoodsReceiptDetailID = this.GoodsReceiptDetailID; e.CustomerID = this.CustomerID; e.SalespersonID = this.SalespersonID; });
        }
    }


    public class SemifinishedProductDTO : SemifinishedProductPrimitiveDTO, IBaseDetailEntity<SemifinishedProductDetailDTO>
    {
        public SemifinishedProductDTO()
        {
            this.SemifinishedProductViewDetails = new List<SemifinishedProductDetailDTO>();
        }

        public override Nullable<int> CustomerID { get { return (this.Customer != null ? (this.Customer.CustomerID > 0 ? (Nullable<int>)this.Customer.CustomerID : null) : null); } }
        [Display(Name = "Khách hàng")]
        [UIHint("Commons/CustomerBase")]
        public CustomerBaseDTO Customer { get; set; }

        public override int SalespersonID { get { return (this.Salesperson != null ? this.Salesperson.EmployeeID : 0); } }
        [Display(Name = "Nhân viên kho")]
        [UIHint("AutoCompletes/EmployeeBase")]
        public EmployeeBaseDTO Salesperson { get; set; }


        public List<SemifinishedProductDetailDTO> SemifinishedProductViewDetails { get; set; }
        public List<SemifinishedProductDetailDTO> ViewDetails { get { return this.SemifinishedProductViewDetails; } set { this.SemifinishedProductViewDetails = value; } }

        public ICollection<SemifinishedProductDetailDTO> GetDetails() { return this.SemifinishedProductViewDetails; }

        protected override IEnumerable<SemifinishedProductDetailDTO> DtoDetails() { return this.SemifinishedProductViewDetails; }
    }
}