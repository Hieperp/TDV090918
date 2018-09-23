using System;
using System.Text;

using TotalBase;
using TotalBase.Enums;
using TotalModel.Models;

namespace TotalDAL.Helpers.SqlProgrammability.Commons
{
    public class Commodity
    {
        private readonly TotalSmartPortalEntities totalSmartPortalEntities;

        public Commodity(TotalSmartPortalEntities totalSmartPortalEntities)
        {
            this.totalSmartPortalEntities = totalSmartPortalEntities;
        }

        public void RestoreProcedure()
        {
            this.GetCommodityIndexes();

            this.CommodityEditable();

            this.GetCommodityBases();
        }


        private void GetCommodityIndexes()
        {
            string queryString;

            queryString = " @NMVNTaskID int, @AspUserID nvarchar(128), @FromDate DateTime, @ToDate DateTime " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      Commodities.CommodityID, EntireCommodityCategories.Name1 AS CommodityCategoryName1, EntireCommodityCategories.Name2 AS CommodityCategoryName2, Commodities.Code, Commodities.OfficialCode, Commodities.CodePartA, Commodities.CodePartB, Commodities.CodePartC, Commodities.CodePartD, Commodities.CodePartE, Commodities.CodePartF, Commodities.Name, Commodities.SalesUnit, Commodities.Remarks, Commodities.Discontinue, Commodities.InActive, " + "\r\n";
            queryString = queryString + "                   CommodityBoms.BomID, CommodityBoms.Code AS BomCode, CommodityBoms.Name AS BomName, CommodityBoms.BlockUnit, CommodityBoms.BlockQuantity, CommodityMolds.MoldID, CommodityMolds.Code AS MoldCode, CommodityMolds.Name AS MoldName, CommodityMolds.Quantity AS MoldQuantity " + " \r\n";
            queryString = queryString + "       FROM        Commodities " + "\r\n";
            queryString = queryString + "                   INNER JOIN EntireCommodityCategories ON Commodities.NMVNTaskID = @NMVNTaskID AND Commodities.CommodityCategoryID = EntireCommodityCategories.CommodityCategoryID " + "\r\n";
            queryString = queryString + "                   LEFT JOIN (SELECT CommodityBoms.CommodityID, CommodityBoms.BomID, Boms.Code, Boms.Name, CommodityBoms.BlockUnit, CommodityBoms.BlockQuantity FROM CommodityBoms INNER JOIN Boms ON CommodityBoms.IsDefault = 1 AND CommodityBoms.BomID = Boms.BomID) CommodityBoms ON Commodities.CommodityID = CommodityBoms.CommodityID " + "\r\n";
            queryString = queryString + "                   LEFT JOIN (SELECT CommodityMolds.CommodityID, CommodityMolds.MoldID, Molds.Code, Molds.Name, CommodityMolds.Quantity FROM CommodityMolds INNER JOIN Molds ON CommodityMolds.IsDefault = 1 AND CommodityMolds.MoldID = Molds.MoldID) CommodityMolds ON Commodities.CommodityID = CommodityMolds.CommodityID " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartPortalEntities.CreateStoredProcedure("GetCommodityIndexes", queryString);
        }

        private void CommodityEditable()
        {
            string[] queryArray = new string[1];

            queryArray[0] = " SELECT TOP 1 @FoundEntity = CommodityID FROM Commodities WHERE @EntityID = 1"; //AT TUE VIET ONLY: Don't allow edit default mold, because it is related to Customers

            //queryArray[0] = " SELECT TOP 1 @FoundEntity = CommodityID FROM Commodities WHERE CommodityID = @EntityID AND (InActive = 1 OR InActivePartial = 1)"; //Don't allow approve after void
            //queryArray[1] = " SELECT TOP 1 @FoundEntity = CommodityID FROM GoodsIssueDetails WHERE CommodityID = @EntityID ";

            this.totalSmartPortalEntities.CreateProcedureToCheckExisting("CommodityEditable", queryArray);
        }

        private void GetCommodityBases()
        {
            string queryString;
            string querySELECT = "                              Commodities.CommodityID, Commodities.Code AS CommodityCode, Commodities.Name AS CommodityName, Commodities.CommodityTypeID, Commodities.PiecePerPack, Commodities.ListedPrice, Commodities.GrossPrice, 0.0 AS DiscountPercent, 0.0 AS TradeDiscountRate, CommodityCategories.VATPercent " + " \r\n";

            queryString = " @CommodityTypeIDList varchar(200), @NmvnTaskID int, @SearchText nvarchar(60) " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       DECLARE         @Commodities TABLE (CommodityID int NOT NULL, Code nvarchar(50) NOT NULL, Name nvarchar(200) NOT NULL, PiecePerPack int NOT NULL, ListedPrice decimal(18, 2) NOT NULL, GrossPrice decimal(18, 2) NOT NULL, DiscountPercent decimal(18, 2) NOT NULL, TradeDiscountRate decimal(18, 2) NOT NULL, CommodityTypeID int NOT NULL, CommodityCategoryID int NOT NULL)" + "\r\n";
            queryString = queryString + "       INSERT INTO     @Commodities SELECT TOP 30 CommodityID, Code, Name, PiecePerPack, ListedPrice, GrossPrice, 0.0 AS DiscountPercent, 0.0 AS TradeDiscountRate, CommodityTypeID, CommodityCategoryID FROM Commodities WHERE InActive = 0 AND (@SearchText = '' OR Code = @SearchText OR Code LIKE '%' + @SearchText + '%' OR OfficialCode LIKE '%' + @SearchText + '%' OR Name LIKE '%' + @SearchText + '%') AND CommodityTypeID IN (SELECT Id FROM dbo.SplitToIntList (@CommodityTypeIDList)) " + "\r\n";

            queryString = queryString + "       IF (@NmvnTaskID = " + (int)GlobalEnums.NmvnTaskID.PlannedOrder + ") " + " \r\n";
            queryString = queryString + "           SELECT      " + querySELECT + ", CommodityBoms.BomID, CommodityBoms.Code AS BomCode, CommodityBoms.Name AS BomName, CommodityBoms.BlockUnit, CommodityBoms.BlockQuantity, CommodityMolds.MoldID, CommodityMolds.Code AS MoldCode, CommodityMolds.Name AS MoldName, CommodityMolds.Quantity AS MoldQuantity " + " \r\n";
            queryString = queryString + "           FROM        @Commodities Commodities " + "\r\n";
            queryString = queryString + "                       INNER JOIN CommodityCategories ON Commodities.CommodityCategoryID = CommodityCategories.CommodityCategoryID " + "\r\n";
            queryString = queryString + "                       LEFT JOIN (SELECT CommodityBoms.CommodityID, CommodityBoms.BomID, Boms.Code, Boms.Name, CommodityBoms.BlockUnit, CommodityBoms.BlockQuantity FROM CommodityBoms INNER JOIN Boms ON CommodityBoms.CommodityID IN (SELECT CommodityID FROM @Commodities) AND CommodityBoms.IsDefault = 1 AND CommodityBoms.BomID = Boms.BomID) CommodityBoms ON Commodities.CommodityID = CommodityBoms.CommodityID " + "\r\n";
            queryString = queryString + "                       LEFT JOIN (SELECT CommodityMolds.CommodityID, CommodityMolds.MoldID, Molds.Code, Molds.Name, CommodityMolds.Quantity FROM CommodityMolds INNER JOIN Molds ON CommodityMolds.CommodityID IN (SELECT CommodityID FROM @Commodities) AND CommodityMolds.IsDefault = 1 AND CommodityMolds.MoldID = Molds.MoldID) CommodityMolds ON Commodities.CommodityID = CommodityMolds.CommodityID " + "\r\n";
            queryString = queryString + "       ELSE " + " \r\n";
            queryString = queryString + "           SELECT      " + querySELECT + ", NULL AS BomID, NULL AS BomCode, NULL AS BomName, NULL AS BlockUnit, NULL AS BlockQuantity, NULL AS MoldID, NULL AS MoldCode, NULL AS MoldName, NULL AS MoldQuantity " + " \r\n";
            queryString = queryString + "           FROM        @Commodities Commodities " + "\r\n";
            queryString = queryString + "                       INNER JOIN CommodityCategories ON Commodities.CommodityCategoryID = CommodityCategories.CommodityCategoryID " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartPortalEntities.CreateStoredProcedure("GetCommodityBases", queryString);
        }

    }
}

