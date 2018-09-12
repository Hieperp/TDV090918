﻿using System;
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
            this.GetBomBases();
        }


        private void GetCommodityIndexes()
        {
            string queryString;

            queryString = " @NMVNTaskID int, @AspUserID nvarchar(128), @FromDate DateTime, @ToDate DateTime " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      Commodities.CommodityID, EntireCommodityCategories.Name1 AS CommodityCategoryName1, EntireCommodityCategories.Name2 AS CommodityCategoryName2, Commodities.Code, Commodities.OfficialCode, Commodities.CodePartA, Commodities.CodePartB, Commodities.CodePartC, Commodities.CodePartD, Commodities.CodePartE, Commodities.CodePartF, Commodities.Name, Commodities.SalesUnit, Commodities.Remarks, Commodities.Discontinue, Commodities.InActive " + "\r\n";
            queryString = queryString + "       FROM        Commodities " + "\r\n";
            queryString = queryString + "                   INNER JOIN EntireCommodityCategories ON Commodities.NMVNTaskID = @NMVNTaskID AND Commodities.CommodityCategoryID = EntireCommodityCategories.CommodityCategoryID " + "\r\n";

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

            queryString = " @CommodityTypeIDList varchar(200), @SearchText nvarchar(60) " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      TOP 60 Commodities.CommodityID, Commodities.Code AS CommodityCode, Commodities.Name AS CommodityName, Commodities.CommodityTypeID, Commodities.ListedPrice, Commodities.GrossPrice, 0.0 AS DiscountPercent, 0.0 AS TradeDiscountRate, CommodityCategories.VATPercent " + " \r\n";
            queryString = queryString + "       FROM        Commodities " + "\r\n";
            queryString = queryString + "                   INNER JOIN CommodityCategories ON Commodities.InActive = 0 AND (@SearchText = '' OR Commodities.Code = @SearchText OR Commodities.Code LIKE '%' + @SearchText + '%' OR Commodities.OfficialCode LIKE '%' + @SearchText + '%' OR Commodities.Name LIKE '%' + @SearchText + '%') AND Commodities.CommodityTypeID IN (SELECT Id FROM dbo.SplitToIntList (@CommodityTypeIDList)) AND Commodities.CommodityCategoryID = CommodityCategories.CommodityCategoryID " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartPortalEntities.CreateStoredProcedure("GetCommodityBases", queryString);
        }

        private void GetBomBases()
        {
            string queryString;

            queryString = " @SearchText nvarchar(60), @CommodityID int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      TOP 30 BomID, Code AS BomCode, Name AS BomName, Reference AS BomReference " + " \r\n";
            queryString = queryString + "       FROM        Boms " + "\r\n";
            queryString = queryString + "       WHERE       InActive = 0 AND BomID IN (SELECT BomID FROM CommodityBoms WHERE CommodityID = @CommodityID) AND (@SearchText = '' OR Code LIKE '%' + @SearchText + '%' OR Reference LIKE '%' + @SearchText + '%') " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartPortalEntities.CreateStoredProcedure("GetBomBases", queryString);
        }

    }
}

