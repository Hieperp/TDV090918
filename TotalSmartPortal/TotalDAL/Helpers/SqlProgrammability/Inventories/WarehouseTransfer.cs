using System;
using System.Text;

using TotalBase;
using TotalBase.Enums;
using TotalModel.Models;

namespace TotalDAL.Helpers.SqlProgrammability.Inventories
{
    public class WarehouseTransfer
    {
        //private readonly TotalSmartPortalEntities totalSmartPortalEntities;

        //public WarehouseTransfer(TotalSmartPortalEntities totalSmartPortalEntities)
        //{
        //    this.totalSmartPortalEntities = totalSmartPortalEntities;
        //}

        //public void RestoreProcedure()
        //{
        //    this.GetWarehouseTransferIndexes();

        //    this.GetWarehouseTransferViewDetails();

        //    this.GetWarehouseTransferPendingTransferOrders();
        //    this.GetWarehouseTransferPendingTransferOrderMaterials();

        //    this.WarehouseTransferSaveRelative();
        //    this.WarehouseTransferPostSaveValidate();

        //    this.WarehouseTransferApproved();
        //    this.WarehouseTransferEditable();

        //    this.WarehouseTransferToggleApproved();

        //    this.WarehouseTransferInitReference();
        //}


        //private void GetWarehouseTransferIndexes()
        //{
        //    string queryString;

        //    queryString = " @AspUserID nvarchar(128), @FromDate DateTime, @ToDate DateTime " + "\r\n";
        //    queryString = queryString + " WITH ENCRYPTION " + "\r\n";
        //    queryString = queryString + " AS " + "\r\n";
        //    queryString = queryString + "    BEGIN " + "\r\n";

        //    queryString = queryString + "       SELECT      WarehouseTransfers.WarehouseTransferID, CAST(WarehouseTransfers.EntryDate AS DATE) AS EntryDate, WarehouseTransfers.Reference, Locations.Code AS LocationCode, Workshifts.Name AS WorkshiftName, WarehouseTransfers.Description, WarehouseTransfers.TotalQuantity, WarehouseTransfers.Approved, " + "\r\n";
        //    queryString = queryString + "                   Workshifts.EntryDate AS WorkshiftEntryDate, ProductionLines.Code AS ProductionLinesCode, TransferOrders.Reference AS TransferOrdersReference, TransferOrders.Code AS TransferOrdersCode, TransferOrders.EntryDate AS TransferOrderEntryDate, TransferOrders.Specification AS TransferOrderSpecification " + "\r\n";
        //    queryString = queryString + "       FROM        WarehouseTransfers " + "\r\n";
        //    queryString = queryString + "                   INNER JOIN Locations ON WarehouseTransfers.EntryDate >= @FromDate AND WarehouseTransfers.EntryDate <= @ToDate AND WarehouseTransfers.OrganizationalUnitID IN (SELECT AccessControls.OrganizationalUnitID FROM AccessControls INNER JOIN AspNetUsers ON AccessControls.UserID = AspNetUsers.UserID WHERE AspNetUsers.Id = @AspUserID AND AccessControls.NMVNTaskID = " + (int)TotalBase.Enums.GlobalEnums.NmvnTaskID.WarehouseTransfer + " AND AccessControls.AccessLevel > 0) AND Locations.LocationID = WarehouseTransfers.LocationID " + "\r\n";
        //    queryString = queryString + "                   INNER JOIN Workshifts ON WarehouseTransfers.WorkshiftID = Workshifts.WorkshiftID " + "\r\n";
        //    queryString = queryString + "                   INNER JOIN ProductionLines ON WarehouseTransfers.ProductionLineID = ProductionLines.ProductionLineID " + "\r\n";
        //    queryString = queryString + "                   INNER JOIN TransferOrders ON WarehouseTransfers.TransferOrderID = TransferOrders.TransferOrderID " + "\r\n";

        //    queryString = queryString + "    END " + "\r\n";

        //    this.totalSmartPortalEntities.CreateStoredProcedure("GetWarehouseTransferIndexes", queryString);
        //}


        //private void GetWarehouseTransferViewDetails()
        //{
        //    string queryString;

        //    queryString = " @WarehouseTransferID Int " + "\r\n";
        //    queryString = queryString + " WITH ENCRYPTION " + "\r\n";
        //    queryString = queryString + " AS " + "\r\n";
        //    queryString = queryString + "    BEGIN " + "\r\n";

        //    queryString = queryString + "       SELECT      WarehouseTransferDetails.WarehouseTransferDetailID, WarehouseTransferDetails.WarehouseTransferID, TransferOrderMaterials.TransferOrderMaterialID, Commodities.CommodityID, Commodities.Code AS CommodityCode, Commodities.Name AS CommodityName, Commodities.CommodityTypeID, " + "\r\n";
        //    queryString = queryString + "                   GoodsReceiptDetails.GoodsReceiptID, GoodsReceiptDetails.GoodsReceiptDetailID, GoodsReceiptDetails.Reference AS GoodsReceiptReference, GoodsReceiptDetails.Code AS GoodsReceiptCode, GoodsReceiptDetails.EntryDate AS GoodsReceiptEntryDate, GoodsReceiptDetails.BatchID, GoodsReceiptDetails.BatchEntryDate, " + "\r\n";
        //    queryString = queryString + "                   ROUND(TransferOrderMaterials.Quantity - TransferOrderMaterials.QuantityIssued + Issued_TransferOrderMaterials.QuantityIssued, " + (int)GlobalEnums.rndQuantity + ") AS TransferOrderRemains, ROUND(GoodsReceiptDetails.Quantity - GoodsReceiptDetails.QuantityIssued + Issued_GoodsReceiptDetails.QuantityIssued, " + (int)GlobalEnums.rndQuantity + ") AS QuantityAvailables, WarehouseTransferDetails.Quantity, WarehouseTransferDetails.Remarks " + "\r\n";

        //    queryString = queryString + "       FROM        WarehouseTransferDetails " + "\r\n";
        //    queryString = queryString + "                   INNER JOIN TransferOrderMaterials ON WarehouseTransferDetails.WarehouseTransferID = @WarehouseTransferID AND WarehouseTransferDetails.TransferOrderMaterialID = TransferOrderMaterials.TransferOrderMaterialID " + "\r\n";
        //    queryString = queryString + "                   INNER JOIN (SELECT TransferOrderMaterialID, SUM(Quantity) AS QuantityIssued FROM WarehouseTransferDetails WHERE WarehouseTransferID = @WarehouseTransferID GROUP BY TransferOrderMaterialID) AS Issued_TransferOrderMaterials ON WarehouseTransferDetails.TransferOrderMaterialID = Issued_TransferOrderMaterials.TransferOrderMaterialID " + "\r\n";

        //    queryString = queryString + "                   INNER JOIN Commodities ON TransferOrderMaterials.MaterialID = Commodities.CommodityID " + "\r\n";

        //    queryString = queryString + "                   INNER JOIN GoodsReceiptDetails ON WarehouseTransferDetails.GoodsReceiptDetailID = GoodsReceiptDetails.GoodsReceiptDetailID " + "\r\n";
        //    queryString = queryString + "                   INNER JOIN (SELECT GoodsReceiptDetailID, SUM(Quantity) AS QuantityIssued FROM WarehouseTransferDetails WHERE WarehouseTransferID = @WarehouseTransferID GROUP BY GoodsReceiptDetailID) AS Issued_GoodsReceiptDetails ON WarehouseTransferDetails.GoodsReceiptDetailID = Issued_GoodsReceiptDetails.GoodsReceiptDetailID " + "\r\n";

        //    queryString = queryString + "       ORDER BY    WarehouseTransferDetails.WarehouseTransferID, WarehouseTransferDetails.WarehouseTransferDetailID " + "\r\n";

        //    queryString = queryString + "    END " + "\r\n";

        //    this.totalSmartPortalEntities.CreateStoredProcedure("GetWarehouseTransferViewDetails", queryString);
        //}





        //private void GetWarehouseTransferPendingTransferOrders()
        //{
        //    string queryString = " @LocationID int " + "\r\n";
        //    queryString = queryString + " WITH ENCRYPTION " + "\r\n";
        //    queryString = queryString + " AS " + "\r\n";

        //    queryString = queryString + "       SELECT          " + (int)@GlobalEnums.WarehouseTransferTypeID.TransferOrders + " AS WarehouseTransferTypeID, TransferOrderDetails.TransferOrderDetailID, TransferOrderDetails.TransferOrderID, TransferOrderDetails.PlannedOrderID, TransferOrderDetails.TransferOrderID, TransferOrders.Code AS TransferOrderCode, TransferOrders.Reference AS TransferOrderReference, TransferOrders.EntryDate AS TransferOrderEntryDate, TransferOrders.Specification AS TransferOrderSpecification, TransferOrders.TotalQuantity, TransferOrders.TotalQuantitySemifinished, " + "\r\n";
        //    queryString = queryString + "                       TransferOrderDetails.CustomerID, Customers.Code AS CustomerCode, Customers.Name AS CustomerName, Warehouses.WarehouseID, Warehouses.Code AS WarehouseCode, Warehouses.Name AS WarehouseName " + "\r\n";

        //    queryString = queryString + "       FROM            TransferOrderDetails " + "\r\n";
        //    queryString = queryString + "                       INNER JOIN TransferOrders ON TransferOrderDetails.TransferOrderID IN (SELECT DISTINCT TransferOrderID FROM TransferOrderMaterials WHERE LocationID = @LocationID AND Approved = 1 AND InActive = 0 AND InActivePartial = 0 AND ROUND(Quantity - QuantityIssued, " + (int)GlobalEnums.rndQuantity + ") > 0) AND TransferOrderDetails.Approved = 1 AND TransferOrderDetails.InActive = 0 AND TransferOrderDetails.InActivePartial = 0 AND TransferOrderDetails.TransferOrderID = TransferOrders.TransferOrderID " + "\r\n";

        //    queryString = queryString + "                       INNER JOIN Customers ON TransferOrderDetails.CustomerID = Customers.CustomerID " + "\r\n";

        //    queryString = queryString + "                       INNER JOIN Warehouses ON Warehouses.WarehouseID = 2 " + "\r\n";


        //    this.totalSmartPortalEntities.CreateStoredProcedure("GetWarehouseTransferPendingTransferOrders", queryString);
        //}

        //private void GetWarehouseTransferPendingTransferOrderMaterials()
        //{
        //    string queryString;

        //    queryString = " @LocationID Int, @WarehouseTransferID Int, @TransferOrderID Int, @WarehouseID Int, @GoodsReceiptDetailIDs varchar(3999), @IsReadonly bit " + "\r\n";
        //    queryString = queryString + " WITH ENCRYPTION " + "\r\n";
        //    queryString = queryString + " AS " + "\r\n";

        //    queryString = queryString + "   BEGIN " + "\r\n";

        //    queryString = queryString + "       IF  (@GoodsReceiptDetailIDs <> '') " + "\r\n";
        //    queryString = queryString + "           " + this.BuildSQLPendingDetails(true) + "\r\n";
        //    queryString = queryString + "       ELSE " + "\r\n";
        //    queryString = queryString + "           " + this.BuildSQLPendingDetails(false) + "\r\n";

        //    queryString = queryString + "   END " + "\r\n";

        //    this.totalSmartPortalEntities.CreateStoredProcedure("GetWarehouseTransferPendingTransferOrderMaterials", queryString);
        //}

        //private string BuildSQLPendingDetails(bool isGoodsReceiptDetailIDs)
        //{
        //    string queryString = "";
        //    queryString = queryString + "   BEGIN " + "\r\n";

        //    queryString = queryString + "       IF (@WarehouseTransferID <= 0) " + "\r\n";
        //    queryString = queryString + "               BEGIN " + "\r\n";
        //    queryString = queryString + "                   " + this.BuildSQLNew(isGoodsReceiptDetailIDs) + "\r\n";
        //    queryString = queryString + "                   ORDER BY TransferOrderMaterials.TransferOrderMaterialID " + "\r\n";
        //    queryString = queryString + "               END " + "\r\n";
        //    queryString = queryString + "       ELSE " + "\r\n";

        //    queryString = queryString + "               IF (@IsReadonly = 1) " + "\r\n";
        //    queryString = queryString + "                   BEGIN " + "\r\n";
        //    queryString = queryString + "                       " + this.BuildSQLEdit(isGoodsReceiptDetailIDs) + "\r\n";
        //    queryString = queryString + "                       ORDER BY TransferOrderMaterials.TransferOrderMaterialID " + "\r\n";
        //    queryString = queryString + "                   END " + "\r\n";

        //    queryString = queryString + "               ELSE " + "\r\n"; //FULL SELECT FOR EDIT MODE

        //    queryString = queryString + "                   BEGIN " + "\r\n";
        //    queryString = queryString + "                       " + this.BuildSQLNew(isGoodsReceiptDetailIDs) + " WHERE TransferOrderMaterials.TransferOrderMaterialID NOT IN (SELECT TransferOrderMaterialID FROM WarehouseTransferDetails WHERE WarehouseTransferID = @WarehouseTransferID) " + "\r\n";
        //    queryString = queryString + "                       UNION ALL " + "\r\n";
        //    queryString = queryString + "                       " + this.BuildSQLEdit(isGoodsReceiptDetailIDs) + "\r\n";
        //    queryString = queryString + "                       ORDER BY TransferOrderMaterials.TransferOrderMaterialID " + "\r\n";
        //    queryString = queryString + "                   END " + "\r\n";

        //    queryString = queryString + "   END " + "\r\n";

        //    return queryString;
        //}

        //private string BuildSQLNew(bool isGoodsReceiptDetailIDs)
        //{
        //    string queryString = "";

        //    queryString = queryString + "       SELECT      TransferOrderMaterials.TransferOrderMaterialID, Commodities.CommodityID, Commodities.Code AS CommodityCode, Commodities.Name AS CommodityName, Commodities.OfficialCode, Commodities.CodePartA, Commodities.CodePartB, Commodities.CodePartC, Commodities.CodePartD, Commodities.CodePartE, Commodities.CodePartF, Commodities.CommodityTypeID, " + "\r\n";
        //    queryString = queryString + "                   GoodsReceiptDetails.GoodsReceiptID, GoodsReceiptDetails.GoodsReceiptDetailID, GoodsReceipts.Reference AS GoodsReceiptReference, GoodsReceipts.Code AS GoodsReceiptCode, GoodsReceipts.EntryDate AS GoodsReceiptEntryDate, GoodsReceiptDetails.BatchID, GoodsReceiptDetails.BatchEntryDate, " + "\r\n";
        //    queryString = queryString + "                   ROUND(TransferOrderMaterials.Quantity - TransferOrderMaterials.QuantityIssued, " + (int)GlobalEnums.rndQuantity + ") AS TransferOrderRemains, ROUND(GoodsReceiptDetails.Quantity - GoodsReceiptDetails.QuantityIssued, " + (int)GlobalEnums.rndQuantity + ") AS QuantityAvailables, 0 AS Quantity, CAST(0 AS bit) AS IsSelected " + "\r\n";

        //    queryString = queryString + "       FROM        TransferOrderMaterials " + "\r\n";
        //    queryString = queryString + "                   INNER JOIN Commodities ON TransferOrderMaterials.TransferOrderID = @TransferOrderID AND TransferOrderMaterials.Approved = 1 AND TransferOrderMaterials.InActive = 0 AND TransferOrderMaterials.InActivePartial = 0 AND ROUND(TransferOrderMaterials.Quantity - TransferOrderMaterials.QuantityIssued, " + (int)GlobalEnums.rndQuantity + ") > 0 AND TransferOrderMaterials.MaterialID = Commodities.CommodityID " + "\r\n";

        //    queryString = queryString + "                   LEFT JOIN GoodsReceiptDetails ON GoodsReceiptDetails.WarehouseID = @WarehouseID AND TransferOrderMaterials.MaterialID = GoodsReceiptDetails.CommodityID AND GoodsReceiptDetails.Approved = 1 AND ROUND(GoodsReceiptDetails.Quantity - GoodsReceiptDetails.QuantityIssued, " + (int)GlobalEnums.rndQuantity + ") > 0 " + (isGoodsReceiptDetailIDs ? " AND GoodsReceiptDetails.GoodsReceiptDetailID NOT IN (SELECT Id FROM dbo.SplitToIntList (@GoodsReceiptDetailIDs))" : "") + "\r\n";
        //    queryString = queryString + "                   LEFT JOIN GoodsReceipts ON GoodsReceiptDetails.GoodsReceiptID = GoodsReceipts.GoodsReceiptID " + "\r\n";

        //    return queryString;
        //}

        //private string BuildSQLEdit(bool isGoodsReceiptDetailIDs)
        //{
        //    string queryString = "";

        //    queryString = queryString + "       SELECT      TransferOrderMaterials.TransferOrderMaterialID, Commodities.CommodityID, Commodities.Code AS CommodityCode, Commodities.Name AS CommodityName, Commodities.OfficialCode, Commodities.CodePartA, Commodities.CodePartB, Commodities.CodePartC, Commodities.CodePartD, Commodities.CodePartE, Commodities.CodePartF, Commodities.CommodityTypeID, " + "\r\n";
        //    queryString = queryString + "                   GoodsReceiptDetails.GoodsReceiptID, GoodsReceiptDetails.GoodsReceiptDetailID, GoodsReceipts.Reference AS GoodsReceiptReference, GoodsReceipts.Code AS GoodsReceiptCode, GoodsReceipts.EntryDate AS GoodsReceiptEntryDate, GoodsReceiptDetails.BatchID, GoodsReceiptDetails.BatchEntryDate, " + "\r\n";
        //    queryString = queryString + "                   ROUND(TransferOrderMaterials.Quantity - TransferOrderMaterials.QuantityIssued + WarehouseTransferDetails.Quantity, " + (int)GlobalEnums.rndQuantity + ") AS TransferOrderRemains, ROUND(GoodsReceiptDetails.Quantity - GoodsReceiptDetails.QuantityIssued + ISNULL(IssuedGoodsReceiptDetails.Quantity, 0), " + (int)GlobalEnums.rndQuantity + ") AS QuantityAvailables, 0 AS Quantity, CAST(0 AS bit) AS IsSelected " + "\r\n";

        //    queryString = queryString + "       FROM        TransferOrderMaterials " + "\r\n";
        //    queryString = queryString + "                   INNER JOIN (SELECT TransferOrderMaterialID, SUM(Quantity) AS Quantity FROM WarehouseTransferDetails WHERE WarehouseTransferID = @WarehouseTransferID GROUP BY TransferOrderMaterialID) AS WarehouseTransferDetails ON TransferOrderMaterials.TransferOrderMaterialID = WarehouseTransferDetails.TransferOrderMaterialID " + "\r\n";
        //    queryString = queryString + "                   INNER JOIN Commodities ON TransferOrderMaterials.MaterialID = Commodities.CommodityID " + "\r\n";

        //    queryString = queryString + "                   LEFT JOIN GoodsReceiptDetails ON GoodsReceiptDetails.WarehouseID = @WarehouseID AND TransferOrderMaterials.MaterialID = GoodsReceiptDetails.CommodityID AND GoodsReceiptDetails.Approved = 1 AND (ROUND(GoodsReceiptDetails.Quantity - GoodsReceiptDetails.QuantityIssued, " + (int)GlobalEnums.rndQuantity + ") > 0 OR GoodsReceiptDetails.GoodsReceiptDetailID IN (SELECT GoodsReceiptDetailID FROM WarehouseTransferDetails WHERE WarehouseTransferID = @WarehouseTransferID)) " + (isGoodsReceiptDetailIDs ? " AND GoodsReceiptDetails.GoodsReceiptDetailID NOT IN (SELECT Id FROM dbo.SplitToIntList (@GoodsReceiptDetailIDs))" : "") + "\r\n";
        //    queryString = queryString + "                   LEFT JOIN (SELECT GoodsReceiptDetailID, SUM(Quantity) AS Quantity FROM WarehouseTransferDetails WHERE WarehouseTransferID = @WarehouseTransferID GROUP BY GoodsReceiptDetailID) AS IssuedGoodsReceiptDetails ON GoodsReceiptDetails.GoodsReceiptDetailID = IssuedGoodsReceiptDetails.GoodsReceiptDetailID " + "\r\n";
        //    queryString = queryString + "                   LEFT JOIN GoodsReceipts ON GoodsReceiptDetails.GoodsReceiptID = GoodsReceipts.GoodsReceiptID " + "\r\n";

        //    return queryString;
        //}


        //private void WarehouseTransferSaveRelative()
        //{
        //    string queryString = " @EntityID int, @SaveRelativeOption int " + "\r\n"; //SaveRelativeOption: 1: Update, -1:Undo
        //    queryString = queryString + " WITH ENCRYPTION " + "\r\n";
        //    queryString = queryString + " AS " + "\r\n";

        //    queryString = queryString + "       BEGIN  " + "\r\n";

        //    queryString = queryString + "           DECLARE @msg NVARCHAR(300) ";

        //    queryString = queryString + "           IF (@SaveRelativeOption = 1) " + "\r\n";
        //    queryString = queryString + "               BEGIN " + "\r\n";
        //    queryString = queryString + "                   IF (NOT EXISTS(SELECT TransferOrderDetailID FROM TransferOrderDetails WHERE TransferOrderDetailID = (SELECT TOP 1 TransferOrderDetailID FROM WarehouseTransfers WHERE WarehouseTransferID = @EntityID) AND TransferOrderDetails.Approved = 1 AND TransferOrderDetails.InActive = 0 AND TransferOrderDetails.InActivePartial = 0)) " + "\r\n";
        //    queryString = queryString + "                   BEGIN " + "\r\n";
        //    queryString = queryString + "                       SET         @msg = N'Lệnh sản xuất đã hủy, chưa duyệt hoặc đã xóa.' ; " + "\r\n";
        //    queryString = queryString + "                       THROW       61001,  @msg, 1; " + "\r\n";
        //    queryString = queryString + "                   END " + "\r\n";


        //    #region UPDATE WorkshiftID
        //    queryString = queryString + "                   DECLARE         @EntryDate Datetime, @ShiftID int, @WorkshiftID int " + "\r\n";
        //    queryString = queryString + "                   SELECT          @EntryDate = CONVERT(date, EntryDate), @ShiftID = ShiftID FROM WarehouseTransfers WHERE WarehouseTransferID = @EntityID " + "\r\n";
        //    queryString = queryString + "                   SET             @WorkshiftID = (SELECT TOP 1 WorkshiftID FROM Workshifts WHERE EntryDate = @EntryDate AND ShiftID = @ShiftID) " + "\r\n";

        //    queryString = queryString + "                   IF             (@WorkshiftID IS NULL) " + "\r\n";
        //    queryString = queryString + "                       BEGIN ";
        //    queryString = queryString + "                           INSERT INTO     Workshifts(EntryDate, ShiftID, Code, Name, WorkingHours, Remarks) SELECT @EntryDate, ShiftID, Code, Name, WorkingHours, Remarks FROM Shifts WHERE ShiftID = @ShiftID " + "\r\n";
        //    queryString = queryString + "                           SELECT          @WorkshiftID = SCOPE_IDENTITY(); " + "\r\n";
        //    queryString = queryString + "                       END ";

        //    queryString = queryString + "                   UPDATE          WarehouseTransfers        SET WorkshiftID = @WorkshiftID WHERE WarehouseTransferID = @EntityID " + "\r\n";
        //    queryString = queryString + "                   UPDATE          WarehouseTransferDetails  SET WorkshiftID = @WorkshiftID WHERE WarehouseTransferID = @EntityID " + "\r\n";
        //    #endregion UPDATE WorkshiftID



        //    queryString = queryString + "               END " + "\r\n";


        //    queryString = queryString + "           DECLARE         @WarehouseTransferDetails TABLE (GoodsReceiptDetailID int NOT NULL PRIMARY KEY, WarehouseTransferTypeID int NOT NULL, Quantity decimal(18, 2) NOT NULL)" + "\r\n";
        //    queryString = queryString + "           INSERT INTO     @WarehouseTransferDetails (GoodsReceiptDetailID, WarehouseTransferTypeID, Quantity) SELECT GoodsReceiptDetailID, MIN(WarehouseTransferTypeID) AS WarehouseTransferTypeID, SUM(Quantity) AS Quantity FROM WarehouseTransferDetails WHERE WarehouseTransferID = @EntityID GROUP BY GoodsReceiptDetailID " + "\r\n";

        //    queryString = queryString + "           DECLARE         @WarehouseTransferTypeID int, @AffectedROWCOUNT int ";
        //    queryString = queryString + "           SELECT          @WarehouseTransferTypeID = WarehouseTransferTypeID FROM @WarehouseTransferDetails ";

        //    #region UPDATE GoodsReceiptDetails
        //    queryString = queryString + "           UPDATE          GoodsReceiptDetails " + "\r\n";
        //    queryString = queryString + "           SET             GoodsReceiptDetails.QuantityIssued = ROUND(GoodsReceiptDetails.QuantityIssued + WarehouseTransferDetails.Quantity * @SaveRelativeOption, " + (int)GlobalEnums.rndQuantity + ") " + "\r\n";
        //    queryString = queryString + "           FROM            GoodsReceiptDetails " + "\r\n";
        //    queryString = queryString + "                           INNER JOIN @WarehouseTransferDetails WarehouseTransferDetails ON GoodsReceiptDetails.GoodsReceiptDetailID = WarehouseTransferDetails.GoodsReceiptDetailID AND GoodsReceiptDetails.Approved = 1 " + "\r\n";

        //    queryString = queryString + "           IF @@ROWCOUNT <> (SELECT COUNT(*) FROM @WarehouseTransferDetails) " + "\r\n";
        //    queryString = queryString + "               BEGIN " + "\r\n";
        //    queryString = queryString + "                   SET         @msg = N'Phiếu nhập kho đã hủy, chưa duyệt hoặc đã xóa.' ; " + "\r\n";
        //    queryString = queryString + "                   THROW       61001,  @msg, 1; " + "\r\n";
        //    queryString = queryString + "               END " + "\r\n";
        //    #endregion


        //    #region ISSUE ADVICE
        //    queryString = queryString + "           IF (@WarehouseTransferTypeID > 0) " + "\r\n";
        //    queryString = queryString + "               BEGIN  " + "\r\n";

        //    queryString = queryString + "                   IF (@WarehouseTransferTypeID = " + (int)GlobalEnums.WarehouseTransferTypeID.TransferOrders + ") " + "\r\n";
        //    queryString = queryString + "                       BEGIN  " + "\r\n";

        //    queryString = queryString + "                           DECLARE         @IssueTransferOrderMaterials TABLE (TransferOrderMaterialID int NOT NULL PRIMARY KEY, Quantity decimal(18, 2) NOT NULL)" + "\r\n";
        //    queryString = queryString + "                           INSERT INTO     @IssueTransferOrderMaterials (TransferOrderMaterialID, Quantity) SELECT TransferOrderMaterialID, SUM(Quantity) AS Quantity FROM WarehouseTransferDetails WHERE WarehouseTransferID = @EntityID GROUP BY TransferOrderMaterialID " + "\r\n";

        //    queryString = queryString + "                           UPDATE          TransferOrderMaterials " + "\r\n";
        //    queryString = queryString + "                           SET             TransferOrderMaterials.QuantityIssued = ROUND(TransferOrderMaterials.QuantityIssued + IssueTransferOrderMaterials.Quantity * @SaveRelativeOption, " + (int)GlobalEnums.rndQuantity + ") " + "\r\n";
        //    queryString = queryString + "                           FROM            TransferOrderMaterials " + "\r\n";
        //    queryString = queryString + "                                           INNER JOIN @IssueTransferOrderMaterials IssueTransferOrderMaterials ON ((TransferOrderMaterials.Approved = 1 AND TransferOrderMaterials.InActive = 0 AND TransferOrderMaterials.InActivePartial = 0) OR @SaveRelativeOption = -1) AND TransferOrderMaterials.TransferOrderMaterialID = IssueTransferOrderMaterials.TransferOrderMaterialID " + "\r\n";

        //    queryString = queryString + "                           IF @@ROWCOUNT <> (SELECT COUNT(*) FROM @IssueTransferOrderMaterials) " + "\r\n";
        //    queryString = queryString + "                               BEGIN " + "\r\n";
        //    queryString = queryString + "                                   SET         @msg = N'Kế hoạch sản xuất đã hủy, chưa duyệt hoặc đã xóa.' ; " + "\r\n";
        //    queryString = queryString + "                                   THROW       61001,  @msg, 1; " + "\r\n";
        //    queryString = queryString + "                               END " + "\r\n";

        //    queryString = queryString + "                       END " + "\r\n";


        //    //queryString = queryString + "                   IF (@WarehouseTransferTypeID = " + (int)GlobalEnums.WarehouseTransferTypeID.GoodsIssueTransfer + ") " + "\r\n";
        //    //queryString = queryString + "                       BEGIN  " + "\r\n";
        //    //queryString = queryString + "                           UPDATE          GoodsIssueTransferDetails " + "\r\n";
        //    //queryString = queryString + "                           SET             GoodsIssueTransferDetails.QuantityIssued = ROUND(GoodsIssueTransferDetails.QuantityIssued + WarehouseTransferDetails.Quantity * @SaveRelativeOption, " + (int)GlobalEnums.rndQuantity + "), GoodsIssueTransferDetails.LineVolumeReceipt = ROUND(GoodsIssueTransferDetails.LineVolumeReceipt + WarehouseTransferDetails.LineVolume * @SaveRelativeOption, " + (int)GlobalEnums.rndVolume + ") " + "\r\n";
        //    //queryString = queryString + "                           FROM            WarehouseTransferDetails " + "\r\n";
        //    //queryString = queryString + "                                           INNER JOIN GoodsIssueTransferDetails ON WarehouseTransferDetails.WarehouseTransferID = @EntityID AND GoodsIssueTransferDetails.Approved = 1 AND WarehouseTransferDetails.GoodsIssueTransferDetailID = GoodsIssueTransferDetails.GoodsIssueTransferDetailID " + "\r\n";
        //    //queryString = queryString + "                           SET @AffectedROWCOUNT = @@ROWCOUNT " + "\r\n";
        //    //queryString = queryString + "                       END " + "\r\n";


        //    //queryString = queryString + "                   IF (@WarehouseTransferTypeID = " + (int)GlobalEnums.WarehouseTransferTypeID.WarehouseAdjustments + ") " + "\r\n";
        //    //queryString = queryString + "                       BEGIN  " + "\r\n";
        //    //queryString = queryString + "                           UPDATE          WarehouseAdjustmentDetails " + "\r\n";
        //    //queryString = queryString + "                           SET             WarehouseAdjustmentDetails.QuantityIssued = ROUND(WarehouseAdjustmentDetails.QuantityIssued + WarehouseTransferDetails.Quantity * @SaveRelativeOption, " + (int)GlobalEnums.rndQuantity + "), WarehouseAdjustmentDetails.LineVolumeReceipt = ROUND(WarehouseAdjustmentDetails.LineVolumeReceipt + WarehouseTransferDetails.LineVolume * @SaveRelativeOption, " + (int)GlobalEnums.rndVolume + ") " + "\r\n";
        //    //queryString = queryString + "                           FROM            WarehouseTransferDetails " + "\r\n";
        //    //queryString = queryString + "                                           INNER JOIN WarehouseAdjustmentDetails ON WarehouseTransferDetails.WarehouseTransferID = @EntityID AND WarehouseAdjustmentDetails.Quantity > 0 AND WarehouseTransferDetails.WarehouseAdjustmentDetailID = WarehouseAdjustmentDetails.WarehouseAdjustmentDetailID " + "\r\n";
        //    //queryString = queryString + "                           SET @AffectedROWCOUNT = @@ROWCOUNT " + "\r\n";
        //    ////------------------------------------------------------SHOULD UPDATE WarehouseTransferID, WarehouseTransferDetailID BACK TO WarehouseAdjustmentDetails FOR WarehouseTransfers OF WarehouseAdjustmentDetails? THE ANSWER: WE CAN DO IT HERE, BUT IT BREAK THE RELATIONSHIP (cyclic redundancy relationship: WarehouseTransferDetails => WarehouseAdjustmentDetails => THUS: WE SHOULD NOT MAKE ANOTHER RELATIONSHIP FROM WarehouseAdjustmentDetails => WarehouseTransferDetails ) => SO: SHOULD NOT!!!
        //    //queryString = queryString + "                       END " + "\r\n";

        //    //queryString = queryString + "                   IF @AffectedROWCOUNT <> (SELECT COUNT(*) FROM WarehouseTransferDetails WHERE WarehouseTransferID = @EntityID) " + "\r\n";
        //    //queryString = queryString + "                       BEGIN " + "\r\n";
        //    //queryString = queryString + "                           DECLARE     @msg NVARCHAR(300) = N'Phiếu giao hàng đã hủy, hoặc chưa duyệt' ; " + "\r\n";
        //    //queryString = queryString + "                           THROW       61001,  @msg, 1; " + "\r\n";
        //    //queryString = queryString + "                       END " + "\r\n";


        //    queryString = queryString + "               END  " + "\r\n";
        //    #endregion


        //    queryString = queryString + "       END " + "\r\n";

        //    this.totalSmartPortalEntities.CreateStoredProcedure("WarehouseTransferSaveRelative", queryString);
        //}

        //private void WarehouseTransferPostSaveValidate()
        //{
        //    string[] queryArray = new string[3];

        //    queryArray[0] = " SELECT TOP 1 @FoundEntity = N'Ngày nhập kho: ' + CAST(GoodsReceipts.EntryDate AS nvarchar) FROM WarehouseTransferDetails INNER JOIN GoodsReceipts ON WarehouseTransferDetails.WarehouseTransferID = @EntityID AND WarehouseTransferDetails.GoodsReceiptID = GoodsReceipts.GoodsReceiptID AND WarehouseTransferDetails.EntryDate < GoodsReceipts.EntryDate ";
        //    queryArray[1] = " SELECT TOP 1 @FoundEntity = N'Lệnh sản xuất: ' + CAST(TransferOrders.EntryDate AS nvarchar) FROM WarehouseTransfers INNER JOIN TransferOrders ON WarehouseTransfers.WarehouseTransferID = @EntityID AND WarehouseTransfers.TransferOrderID = TransferOrders.TransferOrderID AND WarehouseTransfers.EntryDate < TransferOrders.EntryDate ";
        //    queryArray[2] = " SELECT TOP 1 @FoundEntity = N'Số lượng xuất vượt quá số lượng tồn kho: ' + CAST(ROUND(Quantity - QuantityIssued, " + (int)GlobalEnums.rndQuantity + ") AS nvarchar) FROM GoodsReceiptDetails WHERE (ROUND(Quantity - QuantityIssued, " + (int)GlobalEnums.rndQuantity + ") < 0) ";
        //    //ALLOW TO ISSUE OVER TransferOrderMaterials: queryArray[3] = " SELECT TOP 1 @FoundEntity = N'Số lượng xuất vượt quá số định mức nguyên vật liệu: ' + CAST(ROUND(Quantity - QuantityIssued, " + (int)GlobalEnums.rndQuantity + ") AS nvarchar) FROM TransferOrderMaterials WHERE (ROUND(Quantity - QuantityIssued, " + (int)GlobalEnums.rndQuantity + ") < 0) ";

        //    this.totalSmartPortalEntities.CreateProcedureToCheckExisting("WarehouseTransferPostSaveValidate", queryArray);
        //}




        //private void WarehouseTransferApproved()
        //{
        //    string[] queryArray = new string[1];

        //    queryArray[0] = " SELECT TOP 1 @FoundEntity = WarehouseTransferID FROM WarehouseTransfers WHERE WarehouseTransferID = @EntityID AND Approved = 1";

        //    this.totalSmartPortalEntities.CreateProcedureToCheckExisting("WarehouseTransferApproved", queryArray);
        //}


        //private void WarehouseTransferEditable()
        //{
        //    string[] queryArray = new string[0];

        //    //queryArray[0] = " SELECT TOP 1 @FoundEntity = WarehouseTransferID FROM WarehouseTransferDetails WHERE WarehouseTransferID = @EntityID ";

        //    this.totalSmartPortalEntities.CreateProcedureToCheckExisting("WarehouseTransferEditable", queryArray);
        //}

        //private void WarehouseTransferToggleApproved()
        //{
        //    string queryString = " @EntityID int, @Approved bit " + "\r\n";
        //    queryString = queryString + " WITH ENCRYPTION " + "\r\n";
        //    queryString = queryString + " AS " + "\r\n";

        //    queryString = queryString + "       UPDATE      WarehouseTransfers  SET Approved = @Approved, ApprovedDate = GetDate() WHERE WarehouseTransferID = @EntityID AND Approved = ~@Approved" + "\r\n";

        //    queryString = queryString + "       IF @@ROWCOUNT = 1 " + "\r\n";
        //    queryString = queryString + "           BEGIN " + "\r\n";
        //    queryString = queryString + "               UPDATE          WarehouseTransferDetails  SET Approved = @Approved WHERE WarehouseTransferID = @EntityID ; " + "\r\n";
        //    queryString = queryString + "           END " + "\r\n";
        //    queryString = queryString + "       ELSE " + "\r\n";
        //    queryString = queryString + "           BEGIN " + "\r\n";
        //    queryString = queryString + "               DECLARE     @msg NVARCHAR(300) = N'Dữ liệu không tồn tại hoặc đã ' + iif(@Approved = 0, N'hủy', '')  + N' duyệt' ; " + "\r\n";
        //    queryString = queryString + "               THROW       61001,  @msg, 1; " + "\r\n";
        //    queryString = queryString + "           END " + "\r\n";

        //    this.totalSmartPortalEntities.CreateStoredProcedure("WarehouseTransferToggleApproved", queryString);
        //}


        //private void WarehouseTransferInitReference()
        //{
        //    SimpleInitReference simpleInitReference = new SimpleInitReference("WarehouseTransfers", "WarehouseTransferID", "Reference", ModelSettingManager.ReferenceLength, ModelSettingManager.ReferencePrefix(GlobalEnums.NmvnTaskID.WarehouseTransfer));
        //    this.totalSmartPortalEntities.CreateTrigger("WarehouseTransferInitReference", simpleInitReference.CreateQuery());
        //}
    }
}

