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
using System;

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

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public JsonResult GetCommodityBoms([DataSourceRequest] DataSourceRequest dataSourceRequest, int? commmodityID)
        {
            if (commmodityID == null) return Json(null);

            var result = bomAPIRepository.GetCommodityBoms((int)commmodityID); 
            
            return Json(result.ToDataSourceResult(dataSourceRequest), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddCommodityBoms(int? bomID, int? commodityID)
        {
            try
            {
                this.bomAPIRepository.AddCommodityBoms(bomID, commodityID);
                return Json(new { AddResult = "Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { AddResult = "Trùng màng, hoặc " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        public JsonResult RemoveCommodityBoms(int? commodityBomID)
        {
            try
            {
                this.bomAPIRepository.RemoveCommodityBoms(commodityBomID);
                return Json(new { RemoveResult = "Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { RemoveResult = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}