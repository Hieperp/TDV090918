using System;
using System.ComponentModel.DataAnnotations;


namespace TotalDTO.Commons
{
    public interface IBomBaseDTO
    {
        Nullable<int> BomID { get; set; }
        [Display(Name = "Màng")]
        [UIHint("AutoCompletes/BomBase")]
        [Required(ErrorMessage = "Vui lòng nhập màng")]
        string Code { get; set; }     
        string Name { get; set; }        
        Nullable<int> CustomerID { get; set; }
        Nullable<int> CommodityCategoryID { get; set; }
        Nullable<int> CommodityClassID { get; set; }
        Nullable<int> CommodityLineID { get; set; }
    }

    public class BomBaseDTO : BaseDTO, IBomBaseDTO
    {
        public Nullable<int> BomID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Nullable<int> CustomerID { get; set; }        
        public Nullable<int> CommodityCategoryID { get; set; }
        public Nullable<int> CommodityClassID { get; set; }
        public Nullable<int> CommodityLineID { get; set; }
    }

    public class BomDTO
    {
    }
}
