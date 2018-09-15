using System;
using System.Text;

using TotalBase;
using TotalBase.Enums;
using TotalModel.Models;

namespace TotalDAL.Helpers.SqlProgrammability.Productions
{
    public class SemifinishedHandover
    {
        private readonly TotalSmartPortalEntities totalSmartPortalEntities;

        public SemifinishedHandover(TotalSmartPortalEntities totalSmartPortalEntities)
        {
            this.totalSmartPortalEntities = totalSmartPortalEntities;
        }

        public void RestoreProcedure()
        {
            this.GetSemifinishedHandoverIndexes();

            this.GetSemifinishedHandoverViewDetails();

            this.GetSemifinishedHandoverPendingWorkshifts();
            this.GetSemifinishedHandoverPendingCustomers();
            this.GetSemifinishedHandoverPendingDetails();

            this.SemifinishedHandoverSaveRelative();
            this.SemifinishedHandoverPostSaveValidate();

            this.SemifinishedHandoverInitReference();


            this.SemifinishedHandoverSheet();
        }

        private void GetSemifinishedHandoverIndexes()
        {
            string queryString;

            queryString = " @AspUserID nvarchar(128), @FromDate DateTime, @ToDate DateTime " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      SemifinishedHandovers.SemifinishedHandoverID, CAST(SemifinishedHandovers.EntryDate AS DATE) AS EntryDate, SemifinishedHandovers.Reference, Locations.Code AS LocationCode, ISNULL(Customers.Name + ',    ' + Customers.BillingAddress, N'Phiếu giao hàng gộp chung của nhiều khách hàng') AS CustomerDescription, Workshifts.EntryDate AS WorkshiftEntryDate, Workshifts.Code AS WorkshiftCode, SemifinishedHandovers.Description, SemifinishedHandovers.TotalQuantity " + "\r\n";
            queryString = queryString + "       FROM        SemifinishedHandovers " + "\r\n";
            queryString = queryString + "                   INNER JOIN Locations ON SemifinishedHandovers.EntryDate >= @FromDate AND SemifinishedHandovers.EntryDate <= @ToDate AND SemifinishedHandovers.OrganizationalUnitID IN (SELECT AccessControls.OrganizationalUnitID FROM AccessControls INNER JOIN AspNetUsers ON AccessControls.UserID = AspNetUsers.UserID WHERE AspNetUsers.Id = @AspUserID AND AccessControls.NMVNTaskID = " + (int)TotalBase.Enums.GlobalEnums.NmvnTaskID.SemifinishedHandover + " AND AccessControls.AccessLevel > 0) AND Locations.LocationID = SemifinishedHandovers.LocationID " + "\r\n";
            queryString = queryString + "                   INNER JOIN Workshifts ON SemifinishedHandovers.WorkshiftID = Workshifts.WorkshiftID " + "\r\n";
            queryString = queryString + "                   LEFT JOIN Customers ON SemifinishedHandovers.CustomerID = Customers.CustomerID " + "\r\n";
            queryString = queryString + "       " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartPortalEntities.CreateStoredProcedure("GetSemifinishedHandoverIndexes", queryString);
        }

        private void GetSemifinishedHandoverViewDetails()
        {
            string queryString;

            queryString = " @SemifinishedHandoverID Int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      SemifinishedHandoverDetails.SemifinishedHandoverDetailID, SemifinishedHandoverDetails.SemifinishedHandoverID, SemifinishedProductDetails.SemifinishedProductID, SemifinishedProductDetails.SemifinishedProductDetailID, SemifinishedProductDetails.EntryDate, SemifinishedProductDetails.CustomerID, Customers.Code AS CustomerCode, Customers.Name AS CustomerName, " + "\r\n";
            queryString = queryString + "                   SemifinishedProductDetails.CommodityID, Commodities.Code AS CommodityCode, SemifinishedProductDetails.ProductionLineID, ProductionLines.Code AS ProductionLineCode, " + "\r\n";
            queryString = queryString + "                   SemifinishedHandoverDetails.Quantity, SemifinishedHandoverDetails.Remarks" + "\r\n";

            queryString = queryString + "       FROM        SemifinishedHandoverDetails " + "\r\n";
            queryString = queryString + "                   INNER JOIN SemifinishedProductDetails ON SemifinishedHandoverDetails.SemifinishedHandoverID = @SemifinishedHandoverID AND SemifinishedHandoverDetails.SemifinishedProductDetailID = SemifinishedProductDetails.SemifinishedProductDetailID " + "\r\n";
            queryString = queryString + "                   INNER JOIN Customers ON SemifinishedProductDetails.CustomerID = Customers.CustomerID " + "\r\n";
            queryString = queryString + "                   INNER JOIN Commodities ON SemifinishedProductDetails.CommodityID = Commodities.CommodityID " + "\r\n";
            queryString = queryString + "                   INNER JOIN ProductionLines ON SemifinishedProductDetails.ProductionLineID = ProductionLines.ProductionLineID " + "\r\n";

            queryString = queryString + "       ORDER BY    SemifinishedHandoverDetails.SemifinishedHandoverDetailID " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartPortalEntities.CreateStoredProcedure("GetSemifinishedHandoverViewDetails", queryString);
        }











        private void GetSemifinishedHandoverPendingWorkshifts()
        {
            string queryString = " @LocationID int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "       SELECT          Workshifts.WorkshiftID, Workshifts.EntryDate, Workshifts.Code " + "\r\n";
            queryString = queryString + "       FROM            Workshifts " + "\r\n";
            queryString = queryString + "                       INNER JOIN (SELECT WorkshiftID FROM SemifinishedProductDetails WHERE SemifinishedHandoverID IS NULL GROUP BY WorkshiftID) SemifinishedProductDetails ON Workshifts.WorkshiftID = SemifinishedProductDetails.WorkshiftID " + "\r\n";

            this.totalSmartPortalEntities.CreateStoredProcedure("GetSemifinishedHandoverPendingWorkshifts", queryString);
        }

        private void GetSemifinishedHandoverPendingCustomers()
        {
            string queryString = " @LocationID int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "       SELECT          Workshifts.WorkshiftID, Workshifts.EntryDate, Workshifts.Code AS WorkshiftCode, Customers.CustomerID, Customers.Code AS CustomerCode, Customers.Name AS CustomerName " + "\r\n";
            queryString = queryString + "       FROM            Workshifts " + "\r\n";
            queryString = queryString + "                       INNER JOIN (SELECT WorkshiftID, CustomerID FROM SemifinishedProductDetails WHERE SemifinishedHandoverID IS NULL GROUP BY WorkshiftID, CustomerID) SemifinishedProductDetails ON Workshifts.WorkshiftID = SemifinishedProductDetails.WorkshiftID " + "\r\n";
            queryString = queryString + "                       INNER JOIN Customers ON SemifinishedProductDetails.CustomerID = Customers.CustomerID " + "\r\n";

            this.totalSmartPortalEntities.CreateStoredProcedure("GetSemifinishedHandoverPendingCustomers", queryString);
        }


        private void GetSemifinishedHandoverPendingDetails()
        {
            string queryString;

            queryString = " @SemifinishedHandoverID Int, @WorkshiftID Int, @CustomerID Int, @SemifinishedProductDetailIDs varchar(3999), @IsReadonly bit " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";

            queryString = queryString + "   BEGIN " + "\r\n";
            queryString = queryString + "       IF  (@CustomerID <> 0) " + "\r\n";
            queryString = queryString + "           " + this.GetPendingBUILDSQL(true) + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "           " + this.GetPendingBUILDSQL(false) + "\r\n";
            queryString = queryString + "   END " + "\r\n";

            this.totalSmartPortalEntities.CreateStoredProcedure("GetSemifinishedHandoverPendingDetails", queryString);
        }

        private string GetPendingBUILDSQL(bool isCustomerID)
        {
            string queryString = "";
            queryString = queryString + "   BEGIN " + "\r\n";
            queryString = queryString + "       IF  (@SemifinishedProductDetailIDs <> '') " + "\r\n";
            queryString = queryString + "           " + this.GetPendingBUILDSQL(isCustomerID, true) + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "           " + this.GetPendingBUILDSQL(isCustomerID, false) + "\r\n";
            queryString = queryString + "   END " + "\r\n";

            return queryString;
        }

        private string GetPendingBUILDSQL(bool isCustomerID, bool isSemifinishedProductDetailIDs)
        {
            string queryString = "";
            queryString = queryString + "   BEGIN " + "\r\n";

            queryString = queryString + "       IF (@SemifinishedHandoverID <= 0) " + "\r\n";
            queryString = queryString + "               BEGIN " + "\r\n";
            queryString = queryString + "                   " + this.GetPendingBUILDSQLNew(isCustomerID, isSemifinishedProductDetailIDs) + "\r\n";
            queryString = queryString + "                   ORDER BY Customers.Name, Customers.Code, ProductionLines.Code, Commodities.Code, SemifinishedProductDetails.EntryDate " + "\r\n";
            queryString = queryString + "               END " + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";

            queryString = queryString + "               IF (@IsReadonly = 1) " + "\r\n";
            queryString = queryString + "                   BEGIN " + "\r\n";
            queryString = queryString + "                       " + this.GetPendingBUILDSQLEdit(isCustomerID, isSemifinishedProductDetailIDs) + "\r\n";
            queryString = queryString + "                       ORDER BY Customers.Name, Customers.Code, ProductionLines.Code, Commodities.Code, SemifinishedProductDetails.EntryDate " + "\r\n";
            queryString = queryString + "                   END " + "\r\n";

            queryString = queryString + "               ELSE " + "\r\n"; //FULL SELECT FOR EDIT MODE

            queryString = queryString + "                   BEGIN " + "\r\n";
            queryString = queryString + "                       " + this.GetPendingBUILDSQLNew(isCustomerID, isSemifinishedProductDetailIDs) + "\r\n";
            queryString = queryString + "                       UNION ALL " + "\r\n";
            queryString = queryString + "                       " + this.GetPendingBUILDSQLEdit(isCustomerID, isSemifinishedProductDetailIDs) + "\r\n";
            queryString = queryString + "                       ORDER BY Customers.Name, Customers.Code, ProductionLines.Code, Commodities.Code, SemifinishedProductDetails.EntryDate " + "\r\n";
            queryString = queryString + "                   END " + "\r\n";

            queryString = queryString + "   END " + "\r\n";

            return queryString;
        }

        private string GetPendingBUILDSQLNew(bool isCustomerID, bool isSemifinishedProductDetailIDs)
        {
            string queryString = "";

            queryString = queryString + "       SELECT      SemifinishedProductDetails.SemifinishedProductID, SemifinishedProductDetails.SemifinishedProductDetailID, SemifinishedProductDetails.EntryDate, SemifinishedProductDetails.CustomerID, Customers.Code AS CustomerCode, Customers.Name AS CustomerName, " + "\r\n";
            queryString = queryString + "                   SemifinishedProductDetails.CommodityID, Commodities.Code AS CommodityCode, SemifinishedProductDetails.ProductionLineID, ProductionLines.Code AS ProductionLineCode, " + "\r\n";
            queryString = queryString + "                   SemifinishedProductDetails.Quantity, CAST(0 AS bit) AS IsSelected " + "\r\n";

            queryString = queryString + "       FROM        SemifinishedProductDetails " + "\r\n";
            queryString = queryString + "                   INNER JOIN Customers ON SemifinishedProductDetails.WorkshiftID = @WorkshiftID AND SemifinishedProductDetails.Approved = 1 " + (isCustomerID ? " AND SemifinishedProductDetails.CustomerID = @CustomerID " : "") + " AND SemifinishedProductDetails.SemifinishedHandoverID IS NULL AND SemifinishedProductDetails.CustomerID = Customers.CustomerID " + (isSemifinishedProductDetailIDs ? " AND SemifinishedProductDetails.SemifinishedProductDetailID NOT IN (SELECT Id FROM dbo.SplitToIntList (@SemifinishedProductDetailIDs))" : "") + "\r\n";
            queryString = queryString + "                   INNER JOIN Commodities ON SemifinishedProductDetails.CommodityID = Commodities.CommodityID " + "\r\n";
            queryString = queryString + "                   INNER JOIN ProductionLines ON SemifinishedProductDetails.ProductionLineID = ProductionLines.ProductionLineID " + "\r\n";

            return queryString;
        }

        private string GetPendingBUILDSQLEdit(bool isCustomerID, bool isSemifinishedProductDetailIDs)
        {
            string queryString = "";

            queryString = queryString + "       SELECT      SemifinishedProductDetails.SemifinishedProductID, SemifinishedProductDetails.SemifinishedProductDetailID, SemifinishedProductDetails.EntryDate, SemifinishedProductDetails.CustomerID, Customers.Code AS CustomerCode, Customers.Name AS CustomerName, " + "\r\n";
            queryString = queryString + "                   SemifinishedProductDetails.CommodityID, Commodities.Code AS CommodityCode, SemifinishedProductDetails.ProductionLineID, ProductionLines.Code AS ProductionLineCode, " + "\r\n";
            queryString = queryString + "                   SemifinishedProductDetails.Quantity, CAST(0 AS bit) AS IsSelected " + "\r\n";

            queryString = queryString + "       FROM        SemifinishedProductDetails " + "\r\n";
            queryString = queryString + "                   INNER JOIN Customers ON SemifinishedProductDetails.SemifinishedHandoverID = @SemifinishedHandoverID AND SemifinishedProductDetails.CustomerID = Customers.CustomerID " + (isSemifinishedProductDetailIDs ? " AND SemifinishedProductDetails.SemifinishedProductDetailID NOT IN (SELECT Id FROM dbo.SplitToIntList (@SemifinishedProductDetailIDs))" : "") + "\r\n";
            queryString = queryString + "                   INNER JOIN Commodities ON SemifinishedProductDetails.CommodityID = Commodities.CommodityID " + "\r\n";
            queryString = queryString + "                   INNER JOIN ProductionLines ON SemifinishedProductDetails.ProductionLineID = ProductionLines.ProductionLineID " + "\r\n";

            return queryString;
        }


        private void SemifinishedHandoverSaveRelative()
        {
            string queryString = " @EntityID int, @SaveRelativeOption int " + "\r\n"; //SaveRelativeOption: 1: Update, -1:Undo
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       IF (@SaveRelativeOption = 1) " + "\r\n";
            queryString = queryString + "           UPDATE      SemifinishedProductDetails" + "\r\n";
            queryString = queryString + "           SET         SemifinishedProductDetails.SemifinishedHandoverID = SemifinishedHandoverDetails.SemifinishedHandoverID " + "\r\n";
            queryString = queryString + "           FROM        SemifinishedProductDetails INNER JOIN" + "\r\n";
            queryString = queryString + "                       SemifinishedHandoverDetails ON SemifinishedHandoverDetails.SemifinishedHandoverID = @EntityID AND SemifinishedProductDetails.SemifinishedProductDetailID = SemifinishedHandoverDetails.SemifinishedProductDetailID " + "\r\n";

            queryString = queryString + "       ELSE " + "\r\n"; //(@SaveRelativeOption = -1) 
            queryString = queryString + "           UPDATE      SemifinishedProductDetails" + "\r\n";
            queryString = queryString + "           SET         SemifinishedHandoverID = NULL " + "\r\n";
            queryString = queryString + "           WHERE       SemifinishedHandoverID = @EntityID " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartPortalEntities.CreateStoredProcedure("SemifinishedHandoverSaveRelative", queryString);
        }

        private void SemifinishedHandoverPostSaveValidate()
        {
            string[] queryArray = new string[1];

            queryArray[0] = " SELECT TOP 1 @FoundEntity = N'Ngày đóng hàng: ' + CAST(SemifinishedProductDetails.EntryDate AS nvarchar) FROM SemifinishedHandovers INNER JOIN SemifinishedProductDetails ON SemifinishedHandovers.SemifinishedHandoverID = @EntityID AND SemifinishedHandovers.SemifinishedHandoverID = SemifinishedProductDetails.SemifinishedHandoverID AND SemifinishedHandovers.EntryDate < SemifinishedProductDetails.EntryDate ";

            this.totalSmartPortalEntities.CreateProcedureToCheckExisting("SemifinishedHandoverPostSaveValidate", queryArray);
        }



        private void SemifinishedHandoverInitReference()
        {
            SimpleInitReference simpleInitReference = new SimpleInitReference("SemifinishedHandovers", "SemifinishedHandoverID", "Reference", ModelSettingManager.ReferenceLength, ModelSettingManager.ReferencePrefix(GlobalEnums.NmvnTaskID.SemifinishedHandover));
            this.totalSmartPortalEntities.CreateTrigger("SemifinishedHandoverInitReference", simpleInitReference.CreateQuery());
        }






        private void SemifinishedHandoverSheet()
        {
            string queryString;

            queryString = " @SemifinishedHandoverID int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SET NOCOUNT ON" + "\r\n";

            queryString = queryString + "       DECLARE     @LocalSemifinishedHandoverID int      SET @LocalSemifinishedHandoverID = @SemifinishedHandoverID" + "\r\n";

            queryString = queryString + "       SELECT      SemifinishedHandovers.SemifinishedHandoverID, SemifinishedHandoverDetails.SemifinishedHandoverDetailID, SemifinishedHandovers.EntryDate, SemifinishedHandovers.Reference, Vehicles.Name AS VehicleName, Drivers.Name AS DriverName, Collectors.Name AS CollectorName, SemifinishedProductDetails.CustomerID, Customers.Name AS CustomerName, SemifinishedProductDetails.CustomerID, Customers.Name AS CustomerName, IIF(SemifinishedProductDetails.Addressee <> '', SemifinishedProductDetails.Addressee, Customers.Name) AS Addressee, SemifinishedProductDetails.ShippingAddress, MINSemifinishedHandoverDetails.MINSemifinishedHandoverDetailID, " + "\r\n";
            queryString = queryString + "                   SemifinishedProductDetails.Code, SemifinishedProductDetails.GoodsIssueReferences, SemifinishedProductDetails.PackingMaterialID, SemifinishedProductDetails.TotalQuantity AS Quantity, SemifinishedProductDetails.TotalWeight AS Weight, SemifinishedProductDetails.RealWeight " + "\r\n";

            queryString = queryString + "       FROM        SemifinishedHandovers " + "\r\n";
            queryString = queryString + "                   INNER JOIN SemifinishedHandoverDetails ON SemifinishedHandovers.SemifinishedHandoverID = @LocalSemifinishedHandoverID AND SemifinishedHandovers.SemifinishedHandoverID = SemifinishedHandoverDetails.SemifinishedHandoverID " + "\r\n";
            queryString = queryString + "                   INNER JOIN SemifinishedProductDetails ON SemifinishedHandoverDetails.SemifinishedProductID = SemifinishedProductDetails.SemifinishedProductID " + "\r\n";
            queryString = queryString + "                   INNER JOIN Customers ON SemifinishedProductDetails.CustomerID = Customers.CustomerID " + "\r\n";
            queryString = queryString + "                   INNER JOIN Customers AS Customers ON SemifinishedProductDetails.CustomerID = Customers.CustomerID " + "\r\n";
            queryString = queryString + "                   INNER JOIN Vehicles ON SemifinishedHandovers.VehicleID = Vehicles.VehicleID " + "\r\n";
            queryString = queryString + "                   INNER JOIN Employees AS Drivers ON SemifinishedHandovers.DriverID = Drivers.EmployeeID " + "\r\n";
            queryString = queryString + "                   INNER JOIN Employees AS Collectors ON SemifinishedHandovers.CollectorID = Collectors.EmployeeID " + "\r\n";

            queryString = queryString + "                   LEFT JOIN (SELECT MIN(SemifinishedHandoverDetails.SemifinishedHandoverDetailID) AS MINSemifinishedHandoverDetailID, SemifinishedProductDetails.ShippingAddress FROM SemifinishedHandoverDetails INNER JOIN SemifinishedProductDetails ON SemifinishedHandoverDetails.SemifinishedHandoverID = @LocalSemifinishedHandoverID AND SemifinishedHandoverDetails.SemifinishedProductID = SemifinishedProductDetails.SemifinishedProductID GROUP BY SemifinishedProductDetails.ShippingAddress) MINSemifinishedHandoverDetails ON SemifinishedProductDetails.ShippingAddress = MINSemifinishedHandoverDetails.ShippingAddress " + "\r\n"; //FOR SORT PURPOSE ONLY. MUST USE 'LEFT JOIN' BECAUSE: IF SemifinishedProductDetails.ShippingAddress IS NULL, CAN NOT RUN 'INNER JOIN'             

            queryString = queryString + "       ORDER BY    SemifinishedHandoverDetails.SemifinishedHandoverDetailID " + "\r\n";

            queryString = queryString + "       SET NOCOUNT OFF" + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            //this.totalSmartPortalEntities.CreateStoredProcedure("SemifinishedHandoverSheet", queryString);
        }

    }
}