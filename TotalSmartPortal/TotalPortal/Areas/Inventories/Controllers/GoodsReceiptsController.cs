﻿using System.Net;
using System.Web.Mvc;
using System.Text;

using AutoMapper;
using RequireJsNet;

using TotalBase.Enums;

using TotalModel.Models;

using TotalCore.Services.Inventories;
using TotalCore.Repositories.Commons;

using TotalDTO.Inventories;

using TotalPortal.Controllers;
using TotalPortal.Areas.Inventories.ViewModels;
using TotalPortal.Areas.Inventories.Builders;

namespace TotalPortal.Areas.Inventories.Controllers
{
    public class GoodsReceiptsController : GenericViewDetailController<GoodsReceipt, GoodsReceiptDetail, GoodsReceiptViewDetail, GoodsReceiptDTO, GoodsReceiptPrimitiveDTO, GoodsReceiptDetailDTO, GoodsReceiptViewModel>
    {
        public GoodsReceiptsController(IGoodsReceiptService goodsReceiptService, IGoodsReceiptViewModelSelectListBuilder goodsReceiptViewModelSelectListBuilder)
            : base(goodsReceiptService, goodsReceiptViewModelSelectListBuilder, true)
        {
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

        public virtual ActionResult GetPendingPurchaseRequisitionDetails()
        {
            this.AddRequireJsOptions();
            return View();
        }

        public virtual ActionResult GetPendingWarehouseTransferDetails()
        {
            this.AddRequireJsOptions();
            return View();
        }

        public virtual ActionResult GetPendingMaterialIssueDetails()
        {
            this.AddRequireJsOptions();
            return View();
        }

        public virtual ActionResult GetPendingPlannedOrderDetails()
        {
            this.AddRequireJsOptions();
            return View();
        }
    }

}