﻿using System;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;

using Microsoft.AspNet.Identity;

using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

using TotalDTO.Commons;
using TotalModel.Models;
using TotalCore.Repositories.Commons;
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

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public JsonResult GetCommodityBoms([DataSourceRequest] DataSourceRequest dataSourceRequest, int? commmodityID)
        {
            if (commmodityID == null) return Json(null);

            var result = bomAPIRepository.GetCommodityBoms((int)commmodityID); 
            
            return Json(result.ToDataSourceResult(dataSourceRequest), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddCommodityBom(int? bomID, int? commodityID)
        {
            try
            {
                this.bomAPIRepository.AddCommodityBom(bomID, commodityID);
                return Json(new { AddResult = "Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { AddResult = "Trùng dữ liệu, hoặc " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult RemoveCommodityBom(int? commodityBomID)
        {
            try
            {
                this.bomAPIRepository.RemoveCommodityBom(commodityBomID);
                return Json(new { RemoveResult = "Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { RemoveResult = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}