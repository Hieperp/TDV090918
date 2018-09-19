using System;
using System.ComponentModel.DataAnnotations;

namespace TotalDTO.Commons
{
    public interface IProductionLineBaseDTO
    {
        Nullable<int> ProductionLineID { get; set; }
        [Display(Name = "Màng")]
        [UIHint("AutoCompletes/ProductionLineBase")]
        [Required(ErrorMessage = "Vui lòng nhập màng")]
        string Code { get; set; }
        string Name { get; set; }
    }

    public class ProductionLineBaseDTO : BaseDTO, IProductionLineBaseDTO
    {
        public Nullable<int> ProductionLineID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class ProductionLineDTO
    {
    }
}
