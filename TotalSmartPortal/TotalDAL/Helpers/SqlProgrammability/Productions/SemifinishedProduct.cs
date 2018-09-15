using System;
using System.Text;

using TotalBase;
using TotalBase.Enums;
using TotalModel.Models;

namespace TotalDAL.Helpers.SqlProgrammability.Productions
{
    public class SemifinishedProduct
    {
        private readonly TotalSmartPortalEntities totalSmartPortalEntities;

        public SemifinishedProduct(TotalSmartPortalEntities totalSmartPortalEntities)
        {
            this.totalSmartPortalEntities = totalSmartPortalEntities;
        }

        public void RestoreProcedure()
        {
            this.GetSemifinishedProductIndexes();

            this.GetSemifinishedProductPendingMaterialIssueDetails();

            this.GetSemifinishedProductViewDetails();

            this.SemifinishedProductSaveRelative();
            this.SemifinishedProductPostSaveValidate();

            this.SemifinishedProductApproved();
            this.SemifinishedProductEditable();

            this.SemifinishedProductToggleApproved();

            this.SemifinishedProductInitReference();
        }


        private void GetSemifinishedProductIndexes()
        {
            string queryString;

            queryString = " @AspUserID nvarchar(128), @FromDate DateTime, @ToDate DateTime " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      SemifinishedProducts.SemifinishedProductID, CAST(SemifinishedProducts.EntryDate AS DATE) AS EntryDate, SemifinishedProducts.Reference, Locations.Code AS LocationCode, SemifinishedProducts.Description, SemifinishedProducts.Approved " + "\r\n";
            queryString = queryString + "       FROM        SemifinishedProducts " + "\r\n";
            queryString = queryString + "                   INNER JOIN Locations ON SemifinishedProducts.EntryDate >= @FromDate AND SemifinishedProducts.EntryDate <= @ToDate AND SemifinishedProducts.OrganizationalUnitID IN (SELECT AccessControls.OrganizationalUnitID FROM AccessControls INNER JOIN AspNetUsers ON AccessControls.UserID = AspNetUsers.UserID WHERE AspNetUsers.Id = @AspUserID AND AccessControls.NMVNTaskID = " + (int)TotalBase.Enums.GlobalEnums.NmvnTaskID.SemifinishedProduct + " AND AccessControls.AccessLevel > 0) AND Locations.LocationID = SemifinishedProducts.LocationID " + "\r\n";
            queryString = queryString + "       " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartPortalEntities.CreateStoredProcedure("GetSemifinishedProductIndexes", queryString);
        }

        #region X


        private void GetSemifinishedProductViewDetails()
        {
            string queryString;

            queryString = " @SemifinishedProductID Int, @FirmOrderID Int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT          ISNULL(SemifinishedProductDetails.SemifinishedProductDetailID, 0) AS SemifinishedProductDetailID, ISNULL(SemifinishedProductDetails.SemifinishedProductID, 0) AS SemifinishedProductID, FirmOrderDetails.FirmOrderDetailID, FirmOrderDetails.PlannedOrderDetailID, Commodities.CommodityID, Commodities.Code AS CommodityCode, Commodities.Name AS CommodityName, Commodities.CommodityTypeID, " + "\r\n";
            queryString = queryString + "                       ROUND(FirmOrderDetails.Quantity - FirmOrderDetails.QuantitySemifinished + ISNULL(SemifinishedProductDetails.Quantity, 0) + ISNULL(SemifinishedProductDetails.QuantityWastage, 0) + ISNULL(SemifinishedProductDetails.QuantityFailure, 0) + ISNULL(SemifinishedProductDetails.QuantityRejected, 0), " + (int)GlobalEnums.rndQuantity + ") AS QuantityRemains, ISNULL(SemifinishedProductDetails.Quantity, 0) AS Quantity, ISNULL(SemifinishedProductDetails.QuantityWastage, 0) AS QuantityWastage, ISNULL(SemifinishedProductDetails.QuantityFailure, 0) AS QuantityFailure, ISNULL(SemifinishedProductDetails.QuantityRejected, 0) AS QuantityRejected, SemifinishedProductDetails.Remarks " + "\r\n";
            
            queryString = queryString + "       FROM            FirmOrderDetails " + "\r\n";
            queryString = queryString + "                       INNER JOIN Commodities ON FirmOrderDetails.FirmOrderID = @FirmOrderID AND FirmOrderDetails.CommodityID = Commodities.CommodityID " + "\r\n";
            queryString = queryString + "                       LEFT JOIN SemifinishedProductDetails ON SemifinishedProductDetails.SemifinishedProductID = @SemifinishedProductID AND FirmOrderDetails.FirmOrderDetailID = SemifinishedProductDetails.FirmOrderDetailID " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartPortalEntities.CreateStoredProcedure("GetSemifinishedProductViewDetails", queryString);
        }

        private void GetSemifinishedProductPendingMaterialIssueDetails()
        {
            string queryString = " @LocationID int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";

            queryString = queryString + "       SELECT          MaterialIssueDetails.MaterialIssueDetailID, MaterialIssueDetails.MaterialIssueID, MaterialIssueDetails.FirmOrderID, FirmOrders.EntryDate AS FirmOrderEntryDate, FirmOrders.Reference AS FirmOrderReference, FirmOrders.Code AS FirmOrderCode, FirmOrders.Specification AS FirmOrderSpecification, MaterialIssueDetails.GoodsReceiptID, GoodsReceipts.Reference AS GoodsReceiptReference, GoodsReceipts.Code AS GoodsReceiptCode, GoodsReceipts.EntryDate AS GoodsReceiptEntryDate, MaterialIssueDetails.GoodsReceiptDetailID, " + "\r\n";
            queryString = queryString + "                       MaterialIssueDetails.CustomerID, Customers.Code AS CustomerCode, Customers.Name AS CustomerName, MaterialIssueDetails.WorkshiftID, Workshifts.EntryDate AS WorkshiftEntryDate, Workshifts.Code AS WorkshiftCode, MaterialIssueDetails.ProductionLineID, ProductionLines.Code AS ProductionLineCode, ROUND(MaterialIssueDetails.Quantity - MaterialIssueDetails.QuantitySemifinished, " + (int)GlobalEnums.rndQuantity + ") AS QuantityRemains " + "\r\n";

            queryString = queryString + "       FROM            MaterialIssueDetails  " + "\r\n";
            queryString = queryString + "                       INNER JOIN FirmOrders ON MaterialIssueDetails.LocationID = @LocationID AND MaterialIssueDetails.Approved = 1 AND ROUND(MaterialIssueDetails.Quantity - MaterialIssueDetails.QuantitySemifinished, " + (int)GlobalEnums.rndQuantity + ") > 0 AND MaterialIssueDetails.FirmOrderID = FirmOrders.FirmOrderID " + "\r\n";
            queryString = queryString + "                       INNER JOIN GoodsReceipts ON MaterialIssueDetails.GoodsReceiptID = GoodsReceipts.GoodsReceiptID " + "\r\n";
            queryString = queryString + "                       INNER JOIN Customers ON MaterialIssueDetails.CustomerID = Customers.CustomerID " + "\r\n";
            queryString = queryString + "                       INNER JOIN Workshifts ON MaterialIssueDetails.WorkshiftID = Workshifts.WorkshiftID " + "\r\n";
            queryString = queryString + "                       INNER JOIN ProductionLines ON MaterialIssueDetails.ProductionLineID = ProductionLines.ProductionLineID " + "\r\n";

            this.totalSmartPortalEntities.CreateStoredProcedure("GetSemifinishedProductPendingMaterialIssueDetails", queryString);
        }


        private void SemifinishedProductSaveRelative()
        {
            string queryString = " @EntityID int, @SaveRelativeOption int " + "\r\n"; //SaveRelativeOption: 1: Update, -1:Undo
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";

            this.totalSmartPortalEntities.CreateStoredProcedure("SemifinishedProductSaveRelative", queryString);
        }

        private void SemifinishedProductPostSaveValidate()
        {
            string[] queryArray = new string[0];

            //queryArray[0] = " SELECT TOP 1 @FoundEntity = N'Ngày đặt hàng: ' + CAST(MaterialIssues.EntryDate AS nvarchar) FROM SemifinishedProductDetails INNER JOIN MaterialIssues ON SemifinishedProductDetails.SemifinishedProductID = @EntityID AND SemifinishedProductDetails.MaterialIssueID = MaterialIssues.MaterialIssueID AND SemifinishedProductDetails.EntryDate < MaterialIssues.EntryDate ";
            //queryArray[1] = " SELECT TOP 1 @FoundEntity = N'Số lượng xuất vượt quá số lượng đặt hàng: ' + CAST(ROUND(Quantity - QuantitySemifinished, " + (int)GlobalEnums.rndQuantity + ") AS nvarchar) FROM MaterialIssueDetails WHERE (ROUND(Quantity - QuantitySemifinished, " + (int)GlobalEnums.rndQuantity + ") < 0) ";

            this.totalSmartPortalEntities.CreateProcedureToCheckExisting("SemifinishedProductPostSaveValidate", queryArray);
        }




        private void SemifinishedProductApproved()
        {
            string[] queryArray = new string[1];

            queryArray[0] = " SELECT TOP 1 @FoundEntity = SemifinishedProductID FROM SemifinishedProducts WHERE SemifinishedProductID = @EntityID AND Approved = 1";

            this.totalSmartPortalEntities.CreateProcedureToCheckExisting("SemifinishedProductApproved", queryArray);
        }


        private void SemifinishedProductEditable()
        {
            string[] queryArray = new string[0];

            //queryArray[0] = " SELECT TOP 1 @FoundEntity = SemifinishedProductID FROM SemifinishedProducts WHERE SemifinishedProductID = @EntityID AND (InActive = 1 OR InActivePartial = 1)"; //Don't allow approve after void
            //queryArray[1] = " SELECT TOP 1 @FoundEntity = SemifinishedProductID FROM SemifinishedProductDetails WHERE SemifinishedProductID = @EntityID ";

            this.totalSmartPortalEntities.CreateProcedureToCheckExisting("SemifinishedProductEditable", queryArray);
        }

        private void SemifinishedProductToggleApproved()
        {
            string queryString = " @EntityID int, @Approved bit " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";

            queryString = queryString + "       UPDATE      SemifinishedProducts  SET Approved = @Approved, ApprovedDate = GetDate() WHERE SemifinishedProductID = @EntityID AND Approved = ~@Approved" + "\r\n";

            queryString = queryString + "       IF @@ROWCOUNT = 1 " + "\r\n";
            queryString = queryString + "           BEGIN " + "\r\n";
            queryString = queryString + "               UPDATE          SemifinishedProductDetails  SET Approved = @Approved WHERE SemifinishedProductID = @EntityID ; " + "\r\n";
            queryString = queryString + "           END " + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "           BEGIN " + "\r\n";
            queryString = queryString + "               DECLARE     @msg NVARCHAR(300) = N'Dữ liệu không tồn tại hoặc đã ' + iif(@Approved = 0, 'hủy', '')  + ' duyệt' ; " + "\r\n";
            queryString = queryString + "               THROW       61001,  @msg, 1; " + "\r\n";
            queryString = queryString + "           END " + "\r\n";

            this.totalSmartPortalEntities.CreateStoredProcedure("SemifinishedProductToggleApproved", queryString);
        }

        private void SemifinishedProductInitReference()
        {
            SimpleInitReference simpleInitReference = new SimpleInitReference("SemifinishedProducts", "SemifinishedProductID", "Reference", ModelSettingManager.ReferenceLength, ModelSettingManager.ReferencePrefix(GlobalEnums.NmvnTaskID.SemifinishedProduct));
            this.totalSmartPortalEntities.CreateTrigger("SemifinishedProductInitReference", simpleInitReference.CreateQuery());
        }


        #endregion
    }
}
