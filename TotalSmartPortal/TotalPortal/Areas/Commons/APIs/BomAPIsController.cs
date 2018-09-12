using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;

using Microsoft.AspNet.Identity;

using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

using TotalCore.Repositories.Commons;
using TotalModel.Models;
using TotalDTO.Commons;
using TotalPortal.APIs.Sessions;

namespace TotalPortal.Areas.Commons.APIs
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class BomAPIsController : Controller
    {
        private readonly IBomAPIRepository bomAPIRepository;

        public BomAPIsController(IBomAPIRepository bomAPIRepository)
        {
            this.bomAPIRepository = bomAPIRepository;
        }


        public JsonResult GetBomBases(string searchText, int commodityID, int commodityCategoryID, int commodityClassID, int commodityLineID)
        {
            var result = this.bomAPIRepository.GetBomBases(searchText, commodityID, commodityCategoryID, commodityClassID, commodityLineID);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}