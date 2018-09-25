using System;
using System.Text;

using TotalBase;
using TotalBase.Enums;
using TotalModel.Models;

namespace TotalDAL.Helpers.SqlProgrammability.Inventories
{
    public class TransferOrder
    {
        private readonly TotalSmartPortalEntities totalSmartPortalEntities;

        public TransferOrder(TotalSmartPortalEntities totalSmartPortalEntities)
        {
            this.totalSmartPortalEntities = totalSmartPortalEntities;
        }

        public void RestoreProcedure()
        {
            this.GetTransferOrderIndexes();

            this.GetTransferOrderViewDetails();

            this.TransferOrderApproved();
            this.TransferOrderEditable();

            this.TransferOrderToggleApproved();

            this.TransferOrderInitReference();
        }


        private void GetTransferOrderIndexes()
        {
            string queryString;

            queryString = " @NMVNTaskID int, @AspUserID nvarchar(128), @FromDate DateTime, @ToDate DateTime " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      TransferOrders.TransferOrderID, CAST(TransferOrders.EntryDate AS DATE) AS EntryDate, TransferOrders.Reference, Locations.Code AS LocationCode, Customers.Name AS CustomerName, TransferOrders.TransferOrderTypeID, TransferOrderTypes.Name AS TransferOrderTypeName, TransferOrders.AdjustmentJobs, TransferOrders.Description, TransferOrders.TotalQuantity, TransferOrders.Approved " + "\r\n";
            queryString = queryString + "       FROM        TransferOrders " + "\r\n";
            queryString = queryString + "                   INNER JOIN Locations ON TransferOrders.NMVNTaskID = @NMVNTaskID AND TransferOrders.EntryDate >= @FromDate AND TransferOrders.EntryDate <= @ToDate AND TransferOrders.OrganizationalUnitID IN (SELECT AccessControls.OrganizationalUnitID FROM AccessControls INNER JOIN AspNetUsers ON AccessControls.UserID = AspNetUsers.UserID WHERE AspNetUsers.Id = @AspUserID AND AccessControls.NMVNTaskID = @NMVNTaskID AND AccessControls.AccessLevel > 0) AND Locations.LocationID = TransferOrders.LocationID " + "\r\n";
            queryString = queryString + "                   INNER JOIN Customers Customers ON TransferOrders.CustomerID = Customers.CustomerID " + "\r\n";
            queryString = queryString + "                   INNER JOIN TransferOrderTypes ON TransferOrders.TransferOrderTypeID = TransferOrderTypes.TransferOrderTypeID " + "\r\n";
            queryString = queryString + "       " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartPortalEntities.CreateStoredProcedure("GetTransferOrderIndexes", queryString);
        }


        #region X


        private void GetTransferOrderViewDetails()
        {
            string queryString;

            queryString = " @TransferOrderID Int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       DECLARE     @TransferOrderDetails TABLE (TransferOrderDetailID int NOT NULL, TransferOrderID int NOT NULL, CommodityID int NOT NULL, Quantity decimal(18, 2) NOT NULL, Remarks nvarchar(100) NULL) " + "\r\n";
            queryString = queryString + "       INSERT INTO @TransferOrderDetails (TransferOrderDetailID, TransferOrderID, CommodityID, Quantity, Remarks) SELECT TransferOrderDetailID, TransferOrderID, CommodityID, Quantity, Remarks FROM TransferOrderDetails WHERE TransferOrderID = @TransferOrderID " + "\r\n";

            queryString = queryString + "       SELECT      TransferOrderDetails.TransferOrderDetailID, TransferOrderDetails.TransferOrderID, Commodities.CommodityID, Commodities.Code AS CommodityCode, Commodities.Name AS CommodityName, Commodities.CommodityTypeID, " + "\r\n";
            queryString = queryString + "                   ISNULL(CommoditiesAvailables.QuantityAvailables, 0) AS QuantityAvailables, TransferOrderDetails.Quantity, TransferOrderDetails.Remarks " + "\r\n";
            queryString = queryString + "       FROM        @TransferOrderDetails TransferOrderDetails " + "\r\n";
            queryString = queryString + "                   INNER JOIN Commodities ON TransferOrderDetails.CommodityID = Commodities.CommodityID " + "\r\n";
            queryString = queryString + "                   INNER JOIN (SELECT CommodityID, SUM(Quantity - QuantityIssued) AS QuantityAvailables FROM GoodsReceiptDetails WHERE ROUND(Quantity - QuantityIssued, " + (int)GlobalEnums.rndQuantity + ") > 0 AND WarehouseID = (SELECT TOP 1 WarehouseID FROM @TransferOrderDetails) AND CommodityID IN (SELECT DISTINCT CommodityID FROM @TransferOrderDetails) GROUP BY CommodityID) CommoditiesAvailables ON TransferOrderDetails.CommodityID = CommoditiesAvailables.CommodityID " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartPortalEntities.CreateStoredProcedure("GetTransferOrderViewDetails", queryString);
        }


        private void TransferOrderApproved()
        {
            string[] queryArray = new string[1];

            queryArray[0] = " SELECT TOP 1 @FoundEntity = TransferOrderID FROM TransferOrders WHERE TransferOrderID = @EntityID AND Approved = 1";

            this.totalSmartPortalEntities.CreateProcedureToCheckExisting("TransferOrderApproved", queryArray);
        }


        private void TransferOrderEditable()
        {
            string[] queryArray = new string[0];

            //queryArray[0] = " SELECT TOP 1 @FoundEntity = GoodsReceiptID FROM MaterialIssueDetails WHERE GoodsReceiptID = @GoodsReceiptID ";
            //queryArray[1] = " SELECT TOP 1 @FoundEntity = GoodsReceiptID FROM TransferOrderDetails WHERE GoodsReceiptID = @GoodsReceiptID ";

            this.totalSmartPortalEntities.CreateProcedureToCheckExisting("TransferOrderEditable", queryArray);
        }

        private void TransferOrderToggleApproved()
        {
            string queryString = " @EntityID int, @Approved bit " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";

            queryString = queryString + "       UPDATE      TransferOrders  SET Approved = @Approved, ApprovedDate = GetDate() WHERE TransferOrderID = @EntityID AND Approved = ~@Approved" + "\r\n";

            queryString = queryString + "       IF @@ROWCOUNT = 1 " + "\r\n";
            queryString = queryString + "           BEGIN " + "\r\n";
            queryString = queryString + "               UPDATE          TransferOrderDetails  SET Approved = @Approved WHERE TransferOrderID = @EntityID ; " + "\r\n";
            queryString = queryString + "           END " + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "           BEGIN " + "\r\n";
            queryString = queryString + "               DECLARE     @msg NVARCHAR(300) = N'Dữ liệu không tồn tại hoặc đã ' + iif(@Approved = 0, N'hủy', '')  + N' duyệt' ; " + "\r\n";
            queryString = queryString + "               THROW       61001,  @msg, 1; " + "\r\n";
            queryString = queryString + "           END " + "\r\n";

            this.totalSmartPortalEntities.CreateStoredProcedure("TransferOrderToggleApproved", queryString);
        }

        private void TransferOrderInitReference()
        {
            SimpleInitReference simpleInitReference = new SimpleInitReference("TransferOrders", "TransferOrderID", "Reference", ModelSettingManager.ReferenceLength, ModelSettingManager.ReferencePrefix(GlobalEnums.NmvnTaskID.TransferOrder));
            this.totalSmartPortalEntities.CreateTrigger("TransferOrderInitReference", simpleInitReference.CreateQuery());
        }
        #endregion
    }
}
