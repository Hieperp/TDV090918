using System;
using System.Text;

using TotalBase;
using TotalBase.Enums;
using TotalModel.Models;

namespace TotalDAL.Helpers.SqlProgrammability.Productions
{
    public class FinishedHandover
    {
        private readonly TotalSmartPortalEntities totalSmartPortalEntities;

        public FinishedHandover(TotalSmartPortalEntities totalSmartPortalEntities)
        {
            this.totalSmartPortalEntities = totalSmartPortalEntities;
        }

        public void RestoreProcedure()
        {
            this.GetFinishedHandoverIndexes();

            this.GetFinishedHandoverViewDetails();

            this.GetFinishedHandoverPendingPlannedOrders();
            this.GetFinishedHandoverPendingCustomers();
            this.GetFinishedHandoverPendingDetails();

            this.FinishedHandoverSaveRelative();
            this.FinishedHandoverPostSaveValidate();

            this.FinishedHandoverApproved();
            this.FinishedHandoverEditable();

            this.FinishedHandoverToggleApproved();

            this.FinishedHandoverInitReference();


            this.FinishedHandoverSheet();
        }

        private void GetFinishedHandoverIndexes()
        {
            string queryString;

            queryString = " @AspUserID nvarchar(128), @FromDate DateTime, @ToDate DateTime " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      FinishedHandovers.FinishedHandoverID, CAST(FinishedHandovers.EntryDate AS DATE) AS EntryDate, FinishedHandovers.Reference, Locations.Code AS LocationCode, ISNULL(Customers.Name + ',    ' + Customers.BillingAddress, N'Bàn giao phôi định hình') AS CustomerDescription, FinishedHandovers.Description, FinishedHandovers.TotalQuantity, FinishedHandovers.Approved " + "\r\n";
            queryString = queryString + "       FROM        FinishedHandovers " + "\r\n";
            queryString = queryString + "                   INNER JOIN Locations ON FinishedHandovers.EntryDate >= @FromDate AND FinishedHandovers.EntryDate <= @ToDate AND FinishedHandovers.OrganizationalUnitID IN (SELECT AccessControls.OrganizationalUnitID FROM AccessControls INNER JOIN AspNetUsers ON AccessControls.UserID = AspNetUsers.UserID WHERE AspNetUsers.Id = @AspUserID AND AccessControls.NMVNTaskID = " + (int)TotalBase.Enums.GlobalEnums.NmvnTaskID.FinishedHandover + " AND AccessControls.AccessLevel > 0) AND Locations.LocationID = FinishedHandovers.LocationID " + "\r\n";
            queryString = queryString + "                   LEFT JOIN Customers ON FinishedHandovers.CustomerID = Customers.CustomerID " + "\r\n";
            queryString = queryString + "       " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartPortalEntities.CreateStoredProcedure("GetFinishedHandoverIndexes", queryString);
        }

        private void GetFinishedHandoverViewDetails()
        {
            string queryString;

            queryString = " @FinishedHandoverID Int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      FinishedHandoverDetails.FinishedHandoverDetailID, FinishedHandoverDetails.FinishedHandoverID, FinishedProductDetails.FinishedProductID, FinishedProductDetails.FinishedProductDetailID, FinishedProductDetails.EntryDate, FinishedProductDetails.CustomerID, Customers.Code AS CustomerCode, Customers.Name AS CustomerName, " + "\r\n";
            queryString = queryString + "                   FinishedProductDetails.CommodityID, Commodities.Code AS CommodityCode, Commodities.Name AS CommodityName, Commodities.CommodityTypeID, " + "\r\n";
            queryString = queryString + "                   FinishedHandoverDetails.Quantity, FinishedHandoverDetails.Remarks" + "\r\n";

            queryString = queryString + "       FROM        FinishedHandoverDetails " + "\r\n";
            queryString = queryString + "                   INNER JOIN FinishedProductDetails ON FinishedHandoverDetails.FinishedHandoverID = @FinishedHandoverID AND FinishedHandoverDetails.FinishedProductDetailID = FinishedProductDetails.FinishedProductDetailID " + "\r\n";
            queryString = queryString + "                   INNER JOIN Customers ON FinishedProductDetails.CustomerID = Customers.CustomerID " + "\r\n";
            queryString = queryString + "                   INNER JOIN Commodities ON FinishedProductDetails.CommodityID = Commodities.CommodityID " + "\r\n";

            queryString = queryString + "       ORDER BY    FinishedHandoverDetails.FinishedHandoverDetailID " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartPortalEntities.CreateStoredProcedure("GetFinishedHandoverViewDetails", queryString);
        }











        private void GetFinishedHandoverPendingPlannedOrders()
        {
            string queryString = " @LocationID int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "       SELECT          PlannedOrders.PlannedOrderID, PlannedOrders.EntryDate, PlannedOrders.Code AS PlannedOrderCode, Customers.CustomerID, Customers.Code AS CustomerCode, Customers.Name AS CustomerName " + "\r\n";
            queryString = queryString + "       FROM            Customers " + "\r\n";
            queryString = queryString + "                       INNER JOIN PlannedOrders ON PlannedOrders.PlannedOrderID IN (SELECT DISTINCT PlannedOrderID FROM FinishedProductDetails WHERE FinishedHandoverID IS NULL AND Approved = 1) AND PlannedOrders.CustomerID = Customers.CustomerID " + "\r\n";

            this.totalSmartPortalEntities.CreateStoredProcedure("GetFinishedHandoverPendingPlannedOrders", queryString);
        }

        private void GetFinishedHandoverPendingCustomers()
        {
            string queryString = " @LocationID int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "       SELECT          Customers.CustomerID, Customers.Code AS CustomerCode, Customers.Name AS CustomerName " + "\r\n";
            queryString = queryString + "       FROM            Customers " + "\r\n";
            queryString = queryString + "       WHERE           CustomerID IN (SELECT DISTINCT CustomerID FROM FinishedProductDetails WHERE FinishedHandoverID IS NULL AND Approved = 1 GROUP BY CustomerID) " + "\r\n";
            
            this.totalSmartPortalEntities.CreateStoredProcedure("GetFinishedHandoverPendingCustomers", queryString);
        }


        private void GetFinishedHandoverPendingDetails()
        {
            string queryString;

            queryString = " @FinishedHandoverID Int, @PlannedOrderID Int, @CustomerID Int, @FinishedProductDetailIDs varchar(3999), @IsReadonly bit " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";

            queryString = queryString + "   BEGIN " + "\r\n";
            queryString = queryString + "       IF  (@PlannedOrderID <> 0) " + "\r\n";
            queryString = queryString + "           " + this.GetPendingBUILDSQL(true) + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "           " + this.GetPendingBUILDSQL(false) + "\r\n";
            queryString = queryString + "   END " + "\r\n";

            this.totalSmartPortalEntities.CreateStoredProcedure("GetFinishedHandoverPendingDetails", queryString);
        }

        private string GetPendingBUILDSQL(bool isPlannedOrderID)
        {
            string queryString = "";
            queryString = queryString + "   BEGIN " + "\r\n";
            queryString = queryString + "       IF  (@FinishedProductDetailIDs <> '') " + "\r\n";
            queryString = queryString + "           " + this.GetPendingBUILDSQL(isPlannedOrderID, true) + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "           " + this.GetPendingBUILDSQL(isPlannedOrderID, false) + "\r\n";
            queryString = queryString + "   END " + "\r\n";

            return queryString;
        }

        private string GetPendingBUILDSQL(bool isPlannedOrderID, bool isFinishedProductDetailIDs)
        {
            string queryString = "";
            queryString = queryString + "   BEGIN " + "\r\n";

            queryString = queryString + "       IF (@FinishedHandoverID <= 0) " + "\r\n";
            queryString = queryString + "               BEGIN " + "\r\n";
            queryString = queryString + "                   " + this.GetPendingBUILDSQLNew(isPlannedOrderID, isFinishedProductDetailIDs) + "\r\n";
            queryString = queryString + "                   ORDER BY Customers.Name, Customers.Code, Commodities.Code, FinishedProductDetails.EntryDate " + "\r\n";
            queryString = queryString + "               END " + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";

            queryString = queryString + "               IF (@IsReadonly = 1) " + "\r\n";
            queryString = queryString + "                   BEGIN " + "\r\n";
            queryString = queryString + "                       " + this.GetPendingBUILDSQLEdit(isPlannedOrderID, isFinishedProductDetailIDs) + "\r\n";
            queryString = queryString + "                       ORDER BY Customers.Name, Customers.Code, Commodities.Code, FinishedProductDetails.EntryDate " + "\r\n";
            queryString = queryString + "                   END " + "\r\n";

            queryString = queryString + "               ELSE " + "\r\n"; //FULL SELECT FOR EDIT MODE

            queryString = queryString + "                   BEGIN " + "\r\n";
            queryString = queryString + "                       " + this.GetPendingBUILDSQLNew(isPlannedOrderID, isFinishedProductDetailIDs) + "\r\n";
            queryString = queryString + "                       UNION ALL " + "\r\n";
            queryString = queryString + "                       " + this.GetPendingBUILDSQLEdit(isPlannedOrderID, isFinishedProductDetailIDs) + "\r\n";
            queryString = queryString + "                       ORDER BY Customers.Name, Customers.Code, Commodities.Code, FinishedProductDetails.EntryDate " + "\r\n";
            queryString = queryString + "                   END " + "\r\n";

            queryString = queryString + "   END " + "\r\n";

            return queryString;
        }

        private string GetPendingBUILDSQLNew(bool isPlannedOrderID, bool isFinishedProductDetailIDs)
        {
            string queryString = "";

            queryString = queryString + "       SELECT      FinishedProductDetails.FinishedProductID, FinishedProductDetails.FinishedProductDetailID, FinishedProductDetails.EntryDate, FinishedProductDetails.CustomerID, Customers.Code AS CustomerCode, Customers.Name AS CustomerName, " + "\r\n";
            queryString = queryString + "                   FinishedProductDetails.CommodityID, Commodities.Code AS CommodityCode, Commodities.CommodityTypeID, FinishedProductDetails.Quantity, CAST(1 AS bit) AS IsSelected " + "\r\n";

            queryString = queryString + "       FROM        FinishedProductDetails " + "\r\n";
            queryString = queryString + "                   INNER JOIN Customers ON FinishedProductDetails.CustomerID = @CustomerID AND FinishedProductDetails.Approved = 1 " + (isPlannedOrderID ? " AND FinishedProductDetails.PlannedOrderID = @PlannedOrderID " : "") + " AND FinishedProductDetails.FinishedHandoverID IS NULL AND FinishedProductDetails.CustomerID = Customers.CustomerID " + (isFinishedProductDetailIDs ? " AND FinishedProductDetails.FinishedProductDetailID NOT IN (SELECT Id FROM dbo.SplitToIntList (@FinishedProductDetailIDs))" : "") + "\r\n";
            queryString = queryString + "                   INNER JOIN Commodities ON FinishedProductDetails.CommodityID = Commodities.CommodityID " + "\r\n";

            return queryString;
        }

        private string GetPendingBUILDSQLEdit(bool isPlannedOrderID, bool isFinishedProductDetailIDs)
        {
            string queryString = "";

            queryString = queryString + "       SELECT      FinishedProductDetails.FinishedProductID, FinishedProductDetails.FinishedProductDetailID, FinishedProductDetails.EntryDate, FinishedProductDetails.CustomerID, Customers.Code AS CustomerCode, Customers.Name AS CustomerName, " + "\r\n";
            queryString = queryString + "                   FinishedProductDetails.CommodityID, Commodities.Code AS CommodityCode, Commodities.CommodityTypeID, FinishedProductDetails.Quantity, CAST(1 AS bit) AS IsSelected " + "\r\n";

            queryString = queryString + "       FROM        FinishedProductDetails " + "\r\n";
            queryString = queryString + "                   INNER JOIN Customers ON FinishedProductDetails.FinishedHandoverID = @FinishedHandoverID AND FinishedProductDetails.CustomerID = Customers.CustomerID " + (isFinishedProductDetailIDs ? " AND FinishedProductDetails.FinishedProductDetailID NOT IN (SELECT Id FROM dbo.SplitToIntList (@FinishedProductDetailIDs))" : "") + "\r\n";
            queryString = queryString + "                   INNER JOIN Commodities ON FinishedProductDetails.CommodityID = Commodities.CommodityID " + "\r\n";

            return queryString;
        }


        private void FinishedHandoverSaveRelative()
        {
            string queryString = " @EntityID int, @SaveRelativeOption int " + "\r\n"; //SaveRelativeOption: 1: Update, -1:Undo
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       IF (@SaveRelativeOption = 1) " + "\r\n";
            queryString = queryString + "           BEGIN " + "\r\n";
            queryString = queryString + "               UPDATE      FinishedProductDetails" + "\r\n";
            queryString = queryString + "               SET         FinishedProductDetails.FinishedHandoverID = FinishedHandoverDetails.FinishedHandoverID " + "\r\n";
            queryString = queryString + "               FROM        FinishedProductDetails INNER JOIN" + "\r\n";
            queryString = queryString + "                           FinishedHandoverDetails ON FinishedHandoverDetails.FinishedHandoverID = @EntityID AND FinishedProductDetails.Approved = 1 AND FinishedProductDetails.FinishedProductDetailID = FinishedHandoverDetails.FinishedProductDetailID " + "\r\n";

            queryString = queryString + "               IF @@ROWCOUNT <> (SELECT COUNT(*) FROM FinishedProductDetails WHERE FinishedHandoverID = @EntityID) " + "\r\n";
            queryString = queryString + "                   BEGIN " + "\r\n";
            queryString = queryString + "                       DECLARE     @msg NVARCHAR(300) = N'Dữ liệu không tồn tại hoặc chưa duyệt' ; " + "\r\n";
            queryString = queryString + "                       THROW       61001,  @msg, 1; " + "\r\n";
            queryString = queryString + "                   END " + "\r\n";
            queryString = queryString + "           END " + "\r\n";

            queryString = queryString + "       ELSE " + "\r\n"; //(@SaveRelativeOption = -1) 
            queryString = queryString + "           UPDATE      FinishedProductDetails" + "\r\n";
            queryString = queryString + "           SET         FinishedHandoverID = NULL " + "\r\n";
            queryString = queryString + "           WHERE       FinishedHandoverID = @EntityID " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartPortalEntities.CreateStoredProcedure("FinishedHandoverSaveRelative", queryString);
        }

        private void FinishedHandoverPostSaveValidate()
        {
            string[] queryArray = new string[1];

            queryArray[0] = " SELECT TOP 1 @FoundEntity = N'Ngày đóng hàng: ' + CAST(FinishedProductDetails.EntryDate AS nvarchar) FROM FinishedHandovers INNER JOIN FinishedProductDetails ON FinishedHandovers.FinishedHandoverID = @EntityID AND FinishedHandovers.FinishedHandoverID = FinishedProductDetails.FinishedHandoverID AND FinishedHandovers.EntryDate < FinishedProductDetails.EntryDate ";

            this.totalSmartPortalEntities.CreateProcedureToCheckExisting("FinishedHandoverPostSaveValidate", queryArray);
        }




        private void FinishedHandoverApproved()
        {
            string[] queryArray = new string[1];

            queryArray[0] = " SELECT TOP 1 @FoundEntity = FinishedHandoverID FROM FinishedHandovers WHERE FinishedHandoverID = @EntityID AND Approved = 1";

            this.totalSmartPortalEntities.CreateProcedureToCheckExisting("FinishedHandoverApproved", queryArray);
        }


        private void FinishedHandoverEditable()
        {
            string[] queryArray = new string[1];

            queryArray[0] = " SELECT TOP 1 @FoundEntity = GoodsReceiptDetailID FROM GoodsReceiptDetails WHERE FinishedProductDetailID IN (SELECT FinishedProductDetailID FROM FinishedProductDetails WHERE FinishedHandoverID = @EntityID) ";

            this.totalSmartPortalEntities.CreateProcedureToCheckExisting("FinishedHandoverEditable", queryArray);
        }

        private void FinishedHandoverToggleApproved()
        {
            string queryString = " @EntityID int, @Approved bit " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";

            queryString = queryString + "       UPDATE      FinishedHandovers  SET Approved = @Approved, ApprovedDate = GetDate() WHERE FinishedHandoverID = @EntityID AND Approved = ~@Approved" + "\r\n";

            queryString = queryString + "       IF @@ROWCOUNT = 1 " + "\r\n";
            queryString = queryString + "           BEGIN " + "\r\n";
            queryString = queryString + "               UPDATE          FinishedHandoverDetails     SET Approved            = @Approved WHERE FinishedHandoverID = @EntityID ; " + "\r\n";
            queryString = queryString + "               UPDATE          FinishedProductDetails      SET HandoverApproved    = @Approved WHERE FinishedHandoverID = @EntityID ; " + "\r\n";
            queryString = queryString + "           END " + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "           BEGIN " + "\r\n";
            queryString = queryString + "               DECLARE     @msg NVARCHAR(300) = N'Dữ liệu không tồn tại hoặc đã ' + iif(@Approved = 0, N'hủy', '')  + N' duyệt' ; " + "\r\n";
            queryString = queryString + "               THROW       61001,  @msg, 1; " + "\r\n";
            queryString = queryString + "           END " + "\r\n";

            this.totalSmartPortalEntities.CreateStoredProcedure("FinishedHandoverToggleApproved", queryString);
        }

        private void FinishedHandoverInitReference()
        {
            SimpleInitReference simpleInitReference = new SimpleInitReference("FinishedHandovers", "FinishedHandoverID", "Reference", ModelSettingManager.ReferenceLength, ModelSettingManager.ReferencePrefix(GlobalEnums.NmvnTaskID.FinishedHandover));
            this.totalSmartPortalEntities.CreateTrigger("FinishedHandoverInitReference", simpleInitReference.CreateQuery());
        }






        private void FinishedHandoverSheet()
        {
            string queryString;

            queryString = " @FinishedHandoverID int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SET NOCOUNT ON" + "\r\n";

            queryString = queryString + "       DECLARE     @LocalFinishedHandoverID int      SET @LocalFinishedHandoverID = @FinishedHandoverID" + "\r\n";

            queryString = queryString + "       SELECT      FinishedHandovers.FinishedHandoverID, FinishedHandoverDetails.FinishedHandoverDetailID, FinishedHandovers.EntryDate, FinishedHandovers.Reference, Vehicles.Name AS VehicleName, Drivers.Name AS DriverName, Collectors.Name AS CollectorName, FinishedProductDetails.CustomerID, Customers.Name AS CustomerName, FinishedProductDetails.CustomerID, Customers.Name AS CustomerName, IIF(FinishedProductDetails.Addressee <> '', FinishedProductDetails.Addressee, Customers.Name) AS Addressee, FinishedProductDetails.ShippingAddress, MINFinishedHandoverDetails.MINFinishedHandoverDetailID, " + "\r\n";
            queryString = queryString + "                   FinishedProductDetails.Code, FinishedProductDetails.GoodsIssueReferences, FinishedProductDetails.PackingMaterialID, FinishedProductDetails.TotalQuantity AS Quantity, FinishedProductDetails.TotalWeight AS Weight, FinishedProductDetails.RealWeight " + "\r\n";

            queryString = queryString + "       FROM        FinishedHandovers " + "\r\n";
            queryString = queryString + "                   INNER JOIN FinishedHandoverDetails ON FinishedHandovers.FinishedHandoverID = @LocalFinishedHandoverID AND FinishedHandovers.FinishedHandoverID = FinishedHandoverDetails.FinishedHandoverID " + "\r\n";
            queryString = queryString + "                   INNER JOIN FinishedProductDetails ON FinishedHandoverDetails.FinishedProductID = FinishedProductDetails.FinishedProductID " + "\r\n";
            queryString = queryString + "                   INNER JOIN Customers ON FinishedProductDetails.CustomerID = Customers.CustomerID " + "\r\n";
            queryString = queryString + "                   INNER JOIN Customers AS Customers ON FinishedProductDetails.CustomerID = Customers.CustomerID " + "\r\n";
            queryString = queryString + "                   INNER JOIN Vehicles ON FinishedHandovers.VehicleID = Vehicles.VehicleID " + "\r\n";
            queryString = queryString + "                   INNER JOIN Employees AS Drivers ON FinishedHandovers.DriverID = Drivers.EmployeeID " + "\r\n";
            queryString = queryString + "                   INNER JOIN Employees AS Collectors ON FinishedHandovers.CollectorID = Collectors.EmployeeID " + "\r\n";

            queryString = queryString + "                   LEFT JOIN (SELECT MIN(FinishedHandoverDetails.FinishedHandoverDetailID) AS MINFinishedHandoverDetailID, FinishedProductDetails.ShippingAddress FROM FinishedHandoverDetails INNER JOIN FinishedProductDetails ON FinishedHandoverDetails.FinishedHandoverID = @LocalFinishedHandoverID AND FinishedHandoverDetails.FinishedProductID = FinishedProductDetails.FinishedProductID GROUP BY FinishedProductDetails.ShippingAddress) MINFinishedHandoverDetails ON FinishedProductDetails.ShippingAddress = MINFinishedHandoverDetails.ShippingAddress " + "\r\n"; //FOR SORT PURPOSE ONLY. MUST USE 'LEFT JOIN' BECAUSE: IF FinishedProductDetails.ShippingAddress IS NULL, CAN NOT RUN 'INNER JOIN'             

            queryString = queryString + "       ORDER BY    FinishedHandoverDetails.FinishedHandoverDetailID " + "\r\n";

            queryString = queryString + "       SET NOCOUNT OFF" + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            //this.totalSmartPortalEntities.CreateStoredProcedure("FinishedHandoverSheet", queryString);
        }

    }
}