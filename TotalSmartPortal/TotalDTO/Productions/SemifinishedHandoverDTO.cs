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
    public class SemifinishedHandoverPrimitiveDTO : QuantityDTO<SemifinishedHandoverDetailDTO>, IPrimitiveEntity, IPrimitiveDTO
    {
        public GlobalEnums.NmvnTaskID NMVNTaskID { get { return GlobalEnums.NmvnTaskID.SemifinishedHandover; } }

        public int GetID() { return this.SemifinishedHandoverID; }
        public void SetID(int id) { this.SemifinishedHandoverID = id; }

        public int SemifinishedHandoverID { get; set; }
                                                    

        public virtual int WorkshiftID { get; set; }
        public virtual Nullable<int> CustomerID { get; set; }                

        public string ShiftName { get; set; }
        
        public int FinishedLeaderID { get; set; }

        public Nullable<int> SemifinishedLeaderID { get; set; }
        public string SemifinishedLeaderReference { get; set; }
        public string SemifinishedLeaderReferences { get; set; }
        public string SemifinishedLeaderCode { get; set; }
        public string SemifinishedLeaderCodes { get; set; }
        [Display(Name = "Phiếu")]
        public string SemifinishedLeaderReferenceNote { get { return this.SemifinishedLeaderID != null ? this.SemifinishedLeaderReference : (this.SemifinishedLeaderReferences != "" ? this.SemifinishedLeaderReferences : "Giao hàng tổng hợp của nhiều ĐH"); } }
        [Display(Name = "Số")]
        public string SemifinishedLeaderCodeNote { get { return this.SemifinishedLeaderID != null ? this.SemifinishedLeaderCode : (this.SemifinishedLeaderCodes != "" ? this.SemifinishedLeaderCodes : ""); } }
        [Display(Name = "Ngày")]
        public Nullable<System.DateTime> SemifinishedLeaderEntryDate { get; set; }


        public override void PerformPresaveRule()
        {
            base.PerformPresaveRule();
                       
            this.DtoDetails().ToList().ForEach(e => {  });            
        }
    }

    public class SemifinishedHandoverDTO : SemifinishedHandoverPrimitiveDTO, IBaseDetailEntity<SemifinishedHandoverDetailDTO>, ISearchCustomer, IPriceCategory
    {
        public SemifinishedHandoverDTO()
        {
            this.SemifinishedHandoverViewDetails = new List<SemifinishedHandoverDetailDTO>();
        }
        
        public override Nullable<int> CustomerID { get { return (this.Customer != null ? (this.Customer.CustomerID > 0 ? (Nullable<int>)this.Customer.CustomerID : null) : null); } }
        [Display(Name = "Khách hàng")]
        [UIHint("Commons/CustomerBase")]
        public CustomerBaseDTO Customer { get; set; }
     

        public List<SemifinishedHandoverDetailDTO> SemifinishedHandoverViewDetails { get; set; }
        public List<SemifinishedHandoverDetailDTO> ViewDetails { get { return this.SemifinishedHandoverViewDetails; } set { this.SemifinishedHandoverViewDetails = value; } }

        public ICollection<SemifinishedHandoverDetailDTO> GetDetails() { return this.SemifinishedHandoverViewDetails; }

        protected override IEnumerable<SemifinishedHandoverDetailDTO> DtoDetails() { return this.SemifinishedHandoverViewDetails; }
       

     
    }
}
