﻿using TotalBase;
using TotalBase.Enums;
using TotalModel.Models;

namespace TotalDAL.Helpers.SqlProgrammability.Productions
{
    public class FinishedProduct
    {
        private readonly TotalSmartPortalEntities totalSmartPortalEntities;

        public FinishedProduct(TotalSmartPortalEntities totalSmartPortalEntities)
        {
            this.totalSmartPortalEntities = totalSmartPortalEntities;
        }

        public void RestoreProcedure()
        {
            this.GetFinishedProductIndexes();

            this.GetFinishedProductPendingFirmOrders();

            this.GetFinishedProductViewDetails();

            this.FinishedProductSaveRelative();
            this.FinishedProductPostSaveValidate();

            this.FinishedProductApproved();
            this.FinishedProductEditable();

            this.FinishedProductToggleApproved();

            this.FinishedProductInitReference();
        }


        private void GetFinishedProductIndexes()
        {
            string queryString;

            queryString = " @AspUserID nvarchar(128), @FromDate DateTime, @ToDate DateTime " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      FinishedProducts.FinishedProductID, CAST(FinishedProducts.EntryDate AS DATE) AS EntryDate, FinishedProducts.Reference, Locations.Code AS LocationCode, Customers.Code AS CustomerCode, Customers.Name AS CustomerName, FirmOrders.Specification, FinishedProducts.Description, FinishedProducts.Approved " + "\r\n";
            queryString = queryString + "       FROM        FinishedProducts " + "\r\n";
            queryString = queryString + "                   INNER JOIN Locations ON FinishedProducts.EntryDate >= @FromDate AND FinishedProducts.EntryDate <= @ToDate AND FinishedProducts.OrganizationalUnitID IN (SELECT AccessControls.OrganizationalUnitID FROM AccessControls INNER JOIN AspNetUsers ON AccessControls.UserID = AspNetUsers.UserID WHERE AspNetUsers.Id = @AspUserID AND AccessControls.NMVNTaskID = " + (int)TotalBase.Enums.GlobalEnums.NmvnTaskID.FinishedProduct + " AND AccessControls.AccessLevel > 0) AND Locations.LocationID = FinishedProducts.LocationID " + "\r\n";
            queryString = queryString + "                   INNER JOIN FirmOrders ON FinishedProducts.FirmOrderID = FirmOrders.FirmOrderID " + "\r\n";
            queryString = queryString + "                   INNER JOIN Customers ON FinishedProducts.CustomerID = Customers.CustomerID " + "\r\n";
            queryString = queryString + "       " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartPortalEntities.CreateStoredProcedure("GetFinishedProductIndexes", queryString);
        }

        #region X


        private void GetFinishedProductViewDetails()
        {
            string queryString;

            queryString = " @FinishedProductID Int, @LocationID Int, @FirmOrderID Int, @IsReadonly bit " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "   BEGIN " + "\r\n";

            queryString = queryString + "       IF (@FinishedProductID <= 0) " + "\r\n";
            queryString = queryString + "               BEGIN " + "\r\n";
            queryString = queryString + "                   " + this.BUILDSQLNew() + "\r\n";
            queryString = queryString + "                   ORDER BY SemifinishedProductEntryDate, SemifinishedProductDetails.SemifinishedProductID, SemifinishedProductDetails.SemifinishedProductDetailID " + "\r\n";
            queryString = queryString + "               END " + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";

            queryString = queryString + "               IF (@IsReadonly = 1) " + "\r\n";
            queryString = queryString + "                   BEGIN " + "\r\n";
            queryString = queryString + "                       " + this.BUILDSQLEdit() + "\r\n";
            queryString = queryString + "                       ORDER BY SemifinishedProductEntryDate, SemifinishedProductDetails.SemifinishedProductID, SemifinishedProductDetails.SemifinishedProductDetailID " + "\r\n";
            queryString = queryString + "                   END " + "\r\n";

            queryString = queryString + "               ELSE " + "\r\n"; //FULL SELECT FOR EDIT MODE

            queryString = queryString + "                   BEGIN " + "\r\n";
            queryString = queryString + "                       " + this.BUILDSQLNew() + " AND SemifinishedProductDetails.SemifinishedProductDetailID NOT IN (SELECT SemifinishedProductDetailID FROM FinishedProductDetails WHERE FinishedProductID = @FinishedProductID) " + "\r\n";
            queryString = queryString + "                       UNION ALL " + "\r\n";
            queryString = queryString + "                       " + this.BUILDSQLEdit() + "\r\n";
            queryString = queryString + "                       ORDER BY SemifinishedProductEntryDate, SemifinishedProductDetails.SemifinishedProductID, SemifinishedProductDetails.SemifinishedProductDetailID " + "\r\n";
            queryString = queryString + "                   END " + "\r\n";

            queryString = queryString + "   END " + "\r\n";

            this.totalSmartPortalEntities.CreateStoredProcedure("GetFinishedProductViewDetails", queryString);
        }

        private string BUILDSQLNew()
        {
            string queryString = "";

            queryString = queryString + "       SELECT      0 AS FinishedProductDetailID, SemifinishedProductDetails.FirmOrderID, SemifinishedProductDetails.FirmOrderDetailID, SemifinishedProductDetails.PlannedOrderDetailID, SemifinishedProductDetails.SemifinishedProductID, SemifinishedProductDetails.SemifinishedProductDetailID, SemifinishedProductDetails.SemifinishedHandoverID, SemifinishedProductDetails.EntryDate AS SemifinishedProductEntryDate, Commodities.CommodityID, Commodities.Code AS CommodityCode, Commodities.Name AS CommodityName, Commodities.CommodityTypeID, NULL AS Remarks, " + "\r\n";
            queryString = queryString + "                   SemifinishedProductDetails.WorkshiftID, Workshifts.EntryDate AS WorkshiftEntryDate, Workshifts.Code AS WorkshiftCode, GoodsReceiptDetails.Reference AS GoodsReceiptReference, GoodsReceiptDetails.Code AS GoodsReceiptCode, GoodsReceiptDetails.BatchEntryDate, ROUND(SemifinishedProductDetails.Quantity - SemifinishedProductDetails.QuantityFinished, " + (int)GlobalEnums.rndQuantity + ") AS QuantityRemains, 0.0 AS Quantity " + "\r\n";

            queryString = queryString + "       FROM        SemifinishedProductDetails " + "\r\n";
            queryString = queryString + "                   INNER JOIN Commodities ON SemifinishedProductDetails.FirmOrderID = @FirmOrderID AND SemifinishedProductDetails.LocationID = @LocationID AND SemifinishedProductDetails.Approved = 1 AND SemifinishedProductDetails.HandoverApproved = 1 AND ROUND(SemifinishedProductDetails.Quantity - SemifinishedProductDetails.QuantityFinished, " + (int)GlobalEnums.rndQuantity + ") > 0 AND SemifinishedProductDetails.CommodityID = Commodities.CommodityID " + "\r\n";
            queryString = queryString + "                   INNER JOIN Workshifts ON SemifinishedProductDetails.WorkshiftID = Workshifts.WorkshiftID " + "\r\n";
            queryString = queryString + "                   INNER JOIN GoodsReceiptDetails ON SemifinishedProductDetails.GoodsReceiptDetailID = GoodsReceiptDetails.GoodsReceiptDetailID " + "\r\n";

            return queryString;
        }

        private string BUILDSQLEdit()
        {
            string queryString = "";

            queryString = queryString + "       SELECT      FinishedProductDetails.FinishedProductDetailID, SemifinishedProductDetails.FirmOrderID, SemifinishedProductDetails.FirmOrderDetailID, SemifinishedProductDetails.PlannedOrderDetailID, SemifinishedProductDetails.SemifinishedProductID, SemifinishedProductDetails.SemifinishedProductDetailID, SemifinishedProductDetails.SemifinishedHandoverID, SemifinishedProductDetails.EntryDate AS SemifinishedProductEntryDate, Commodities.CommodityID, Commodities.Code AS CommodityCode, Commodities.Name AS CommodityName, Commodities.CommodityTypeID, FinishedProductDetails.Remarks, " + "\r\n";
            queryString = queryString + "                   SemifinishedProductDetails.WorkshiftID, Workshifts.EntryDate AS WorkshiftEntryDate, Workshifts.Code AS WorkshiftCode, GoodsReceiptDetails.Reference AS GoodsReceiptReference, GoodsReceiptDetails.Code AS GoodsReceiptCode, GoodsReceiptDetails.BatchEntryDate, ROUND(SemifinishedProductDetails.Quantity - SemifinishedProductDetails.QuantityFinished + FinishedProductDetails.Quantity, " + (int)GlobalEnums.rndQuantity + ") AS QuantityRemains, FinishedProductDetails.Quantity " + "\r\n";

            queryString = queryString + "       FROM        FinishedProductDetails " + "\r\n";
            queryString = queryString + "                   INNER JOIN SemifinishedProductDetails ON FinishedProductDetails.FinishedProductID = @FinishedProductID AND FinishedProductDetails.SemifinishedProductDetailID = SemifinishedProductDetails.SemifinishedProductDetailID " + "\r\n";
            queryString = queryString + "                   INNER JOIN Commodities ON SemifinishedProductDetails.CommodityID = Commodities.CommodityID " + "\r\n";
            queryString = queryString + "                   INNER JOIN Workshifts ON SemifinishedProductDetails.WorkshiftID = Workshifts.WorkshiftID " + "\r\n";
            queryString = queryString + "                   INNER JOIN GoodsReceiptDetails ON SemifinishedProductDetails.GoodsReceiptDetailID = GoodsReceiptDetails.GoodsReceiptDetailID " + "\r\n";

            return queryString;
        }
       


        private void GetFinishedProductPendingFirmOrders()
        {
            string queryString = " @LocationID int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";

            queryString = queryString + "       SELECT          FirmOrders.FirmOrderID, FirmOrders.EntryDate AS FirmOrderEntryDate, FirmOrders.Reference AS FirmOrderReference, FirmOrders.Code AS FirmOrderCode, FirmOrders.Specification AS FirmOrderSpecification, FirmOrders.CustomerID, Customers.Code AS CustomerCode, Customers.Name AS CustomerName " + "\r\n";
            queryString = queryString + "       FROM            FirmOrders " + "\r\n";
            queryString = queryString + "                       INNER JOIN Customers ON FirmOrders.FirmOrderID IN (SELECT DISTINCT FirmOrderID FROM SemifinishedProductDetails WHERE LocationID = @LocationID AND Approved = 1 AND HandoverApproved = 1 AND ROUND(Quantity - QuantityFinished, " + (int)GlobalEnums.rndQuantity + ") > 0) AND FirmOrders.CustomerID = Customers.CustomerID " + "\r\n";

            this.totalSmartPortalEntities.CreateStoredProcedure("GetFinishedProductPendingFirmOrders", queryString);
        }

        private void FinishedProductSaveRelative()
        {
            string queryString = " @EntityID int, @SaveRelativeOption int " + "\r\n"; //SaveRelativeOption: 1: Update, -1:Undo
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "   BEGIN  " + "\r\n";

            queryString = queryString + "       UPDATE          SemifinishedProductDetails " + "\r\n";
            queryString = queryString + "       SET             SemifinishedProductDetails.QuantityFinished = ROUND(SemifinishedProductDetails.QuantityFinished + FinishedProductDetails.Quantity * @SaveRelativeOption, " + (int)GlobalEnums.rndQuantity + ") " + "\r\n";
            queryString = queryString + "       FROM            FinishedProductDetails " + "\r\n";
            queryString = queryString + "                       INNER JOIN SemifinishedProductDetails ON SemifinishedProductDetails.Approved = 1 AND SemifinishedProductDetails.HandoverApproved = 1 AND FinishedProductDetails.FinishedProductID = @EntityID AND FinishedProductDetails.SemifinishedProductDetailID = SemifinishedProductDetails.SemifinishedProductDetailID " + "\r\n";

            queryString = queryString + "       IF @@ROWCOUNT <> (SELECT COUNT(*) FROM FinishedProductDetails WHERE FinishedProductID = @EntityID) " + "\r\n";
            queryString = queryString + "           BEGIN " + "\r\n";
            queryString = queryString + "               DECLARE     @msg NVARCHAR(300) = N'Phie61i BTP không tồn tại, chưa duyệt hoặc đã hủy' ; " + "\r\n";
            queryString = queryString + "               THROW       61001,  @msg, 1; " + "\r\n";
            queryString = queryString + "           END " + "\r\n";

            queryString = queryString + "   END " + "\r\n";

            this.totalSmartPortalEntities.CreateStoredProcedure("FinishedProductSaveRelative", queryString);
        }

        private void FinishedProductPostSaveValidate()
        {
            string[] queryArray = new string[0];

            //queryArray[0] = " SELECT TOP 1 @FoundEntity = N'Ngày đặt hàng: ' + CAST(Semifinisheds.EntryDate AS nvarchar) FROM FinishedProductDetails INNER JOIN Semifinisheds ON FinishedProductDetails.FinishedProductID = @EntityID AND FinishedProductDetails.SemifinishedID = Semifinisheds.SemifinishedID AND FinishedProductDetails.EntryDate < Semifinisheds.EntryDate ";
            //queryArray[1] = " SELECT TOP 1 @FoundEntity = N'Số lượng xuất vượt quá số lượng đặt hàng: ' + CAST(ROUND(Quantity - QuantityFinished, " + (int)GlobalEnums.rndQuantity + ") AS nvarchar) FROM SemifinishedDetails WHERE (ROUND(Quantity - QuantityFinished, " + (int)GlobalEnums.rndQuantity + ") < 0) ";

            this.totalSmartPortalEntities.CreateProcedureToCheckExisting("FinishedProductPostSaveValidate", queryArray);
        }




        private void FinishedProductApproved()
        {
            string[] queryArray = new string[1];

            queryArray[0] = " SELECT TOP 1 @FoundEntity = FinishedProductID FROM FinishedProducts WHERE FinishedProductID = @EntityID AND Approved = 1";

            this.totalSmartPortalEntities.CreateProcedureToCheckExisting("FinishedProductApproved", queryArray);
        }


        private void FinishedProductEditable()
        {
            string[] queryArray = new string[0];

            //queryArray[0] = " SELECT TOP 1 @FoundEntity = FinishedProductID FROM FinishedProducts WHERE FinishedProductID = @EntityID AND (InActive = 1 OR InActivePartial = 1)"; //Don't allow approve after void
            //queryArray[1] = " SELECT TOP 1 @FoundEntity = FinishedProductID FROM FinishedProductDetails WHERE FinishedProductID = @EntityID ";

            this.totalSmartPortalEntities.CreateProcedureToCheckExisting("FinishedProductEditable", queryArray);
        }

        private void FinishedProductToggleApproved()
        {
            string queryString = " @EntityID int, @Approved bit " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";

            queryString = queryString + "       UPDATE      FinishedProducts  SET Approved = @Approved, ApprovedDate = GetDate() WHERE FinishedProductID = @EntityID AND Approved = ~@Approved" + "\r\n";

            queryString = queryString + "       IF @@ROWCOUNT = 1 " + "\r\n";
            queryString = queryString + "           BEGIN " + "\r\n";
            queryString = queryString + "               UPDATE          FinishedProductDetails  SET Approved = @Approved WHERE FinishedProductID = @EntityID ; " + "\r\n";
            queryString = queryString + "           END " + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "           BEGIN " + "\r\n";
            queryString = queryString + "               DECLARE     @msg NVARCHAR(300) = N'Dữ liệu không tồn tại hoặc đã ' + iif(@Approved = 0, N'hủy', '')  + N' duyệt' ; " + "\r\n";
            queryString = queryString + "               THROW       61001,  @msg, 1; " + "\r\n";
            queryString = queryString + "           END " + "\r\n";

            this.totalSmartPortalEntities.CreateStoredProcedure("FinishedProductToggleApproved", queryString);
        }

        private void FinishedProductInitReference()
        {
            SimpleInitReference simpleInitReference = new SimpleInitReference("FinishedProducts", "FinishedProductID", "Reference", ModelSettingManager.ReferenceLength, ModelSettingManager.ReferencePrefix(GlobalEnums.NmvnTaskID.FinishedProduct));
            this.totalSmartPortalEntities.CreateTrigger("FinishedProductInitReference", simpleInitReference.CreateQuery());
        }


        #endregion
    }
}