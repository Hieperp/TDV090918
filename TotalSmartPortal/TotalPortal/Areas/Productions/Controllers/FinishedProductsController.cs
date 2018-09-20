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
    public class FinishedProductsController : GenericViewDetailController<FinishedProduct, FinishedProductDetail, FinishedProductViewDetail, FinishedProductDTO, FinishedProductPrimitiveDTO, FinishedProductDetailDTO, FinishedProductViewModel>
    {
        private readonly IFinishedProductService finishedProductService;

        public FinishedProductsController(IFinishedProductService finishedProductService, IFinishedProductViewModelSelectListBuilder finishedProductViewModelSelectListBuilder)
            : base(finishedProductService, finishedProductViewModelSelectListBuilder, true)
        {
            this.finishedProductService = finishedProductService;
        }

        protected override ICollection<FinishedProductViewDetail> GetEntityViewDetails(FinishedProductViewModel finishedProductViewModel)
        {
            ICollection<FinishedProductViewDetail> finishedProductViewDetails = this.finishedProductService.GetFinishedProductViewDetails(finishedProductViewModel.FinishedProductID, this.finishedProductService.LocationID, finishedProductViewModel.FirmOrderID, false);

            return finishedProductViewDetails;
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