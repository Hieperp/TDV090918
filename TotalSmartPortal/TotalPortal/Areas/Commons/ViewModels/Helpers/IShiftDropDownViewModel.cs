using System.Web.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TotalPortal.Areas.Commons.ViewModels.Helpers
{
    public interface IShiftDropDownViewModel
    {
        [Display(Name = "Ca SX")]
        int ShiftID { get; set; }
        IEnumerable<SelectListItem> ShiftSelectList { get; set; }
    }
}