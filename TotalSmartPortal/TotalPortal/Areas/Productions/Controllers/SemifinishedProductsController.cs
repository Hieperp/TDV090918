using System.Net;
using System.Web.Mvc;
using System.Text;

using AutoMapper;
using RequireJsNet;

using TotalBase.Enums;

using TotalModel.Models;

using TotalCore.Services.Productions;
using TotalCore.Repositories.Commons;

using TotalDTO.Productions;

using TotalPortal.Controllers;
using TotalPortal.Areas.Productions.ViewModels;
using TotalPortal.Areas.Productions.Builders;
using System.Collections.Generic;

namespace TotalPortal.Areas.Productions.Controllers
{
    public class SemifinishedProductsController : GenericViewDetailController<SemifinishedProduct, SemifinishedProductDetail, SemifinishedProductViewDetail, SemifinishedProductDTO, SemifinishedProductPrimitiveDTO, SemifinishedProductDetailDTO, SemifinishedProductViewModel>
    {
        private readonly ISemifinishedProductService semifinishedProductService;

        public SemifinishedProductsController(ISemifinishedProductService semifinishedProductService, ISemifinishedProductViewModelSelectListBuilder semifinishedProductViewModelSelectListBuilder)
            : base(semifinishedProductService, semifinishedProductViewModelSelectListBuilder, true)
        {
            this.semifinishedProductService = semifinishedProductService;
        }

        protected override ICollection<SemifinishedProductViewDetail> GetEntityViewDetails(SemifinishedProductViewModel semifinishedProductViewModel)
        {
            ICollection<SemifinishedProductViewDetail> semifinishedProductViewDetails = this.semifinishedProductService.GetSemifinishedProductViewDetails(semifinishedProductViewModel.SemifinishedProductID, semifinishedProductViewModel.FirmOrderID);

            return semifinishedProductViewDetails;
        }

        public override void AddRequireJsOptions()
        {
            base.AddRequireJsOptions();

            StringBuilder commodityTypeIDList = new StringBuilder();
            commodityTypeIDList.Append((int)GlobalEnums.CommodityTypeID.Items);
            commodityTypeIDList.Append(","); commodityTypeIDList.Append((int)GlobalEnums.CommodityTypeID.Consumables);

            RequireJsOptions.Add("commodityTypeIDList", commodityTypeIDList.ToString(), RequireJsOptionsScope.Page);


            StringBuilder warehouseTaskIDList = new StringBuilder();
            warehouseTaskIDList.Append((int)GlobalEnums.WarehouseTaskID.DeliveryAdvice);

            ViewBag.WarehouseTaskID = (int)GlobalEnums.WarehouseTaskID.DeliveryAdvice;
            ViewBag.WarehouseTaskIDList = warehouseTaskIDList.ToString();
        }

        public virtual ActionResult GetPendingFirmOrderMaterials()
        {
            this.AddRequireJsOptions();
            return View();
        }
    }
}