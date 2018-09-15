using System;
using System.Text;

using TotalBase;
using TotalBase.Enums;
using TotalModel.Models;

namespace TotalDAL.Helpers.SqlProgrammability.Commons
{
    public class Mold
    {
        private readonly TotalSmartPortalEntities totalSmartPortalEntities;

        public Mold(TotalSmartPortalEntities totalSmartPortalEntities)
        {
            this.totalSmartPortalEntities = totalSmartPortalEntities;
        }

        public void RestoreProcedure()
        {
            this.GetMoldIndexes();

            this.MoldEditable();


            this.GetCommodityMolds();

            this.AddCommodityMold();
            this.RemoveCommodityMold();

            this.UpdateCommodityMold();

            this.GetMoldBases();
        }


        private void GetMoldIndexes()
        {
            string queryString;

            queryString = " @AspUserID nvarchar(128), @FromDate DateTime, @ToDate DateTime " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      MoldID, Code, Name, Quantity, Weight, CyclePerHours, InActive, Remarks " + "\r\n";
            queryString = queryString + "       FROM        Molds " + "\r\n";
            queryString = queryString + "       " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartPortalEntities.CreateStoredProcedure("GetMoldIndexes", queryString);
        }

        private void MoldEditable()
        {
            string[] queryArray = new string[1];

            queryArray[0] = " SELECT TOP 1 @FoundEntity = MoldID FROM Molds WHERE @EntityID = @EntityID"; 

            //queryArray[0] = " SELECT TOP 1 @FoundEntity = MoldID FROM Molds WHERE MoldID = @EntityID AND (InActive = 1 OR InActivePartial = 1)"; //Don't allow approve after void
            //queryArray[1] = " SELECT TOP 1 @FoundEntity = MoldID FROM GoodsIssueDetails WHERE MoldID = @EntityID ";

            this.totalSmartPortalEntities.CreateProcedureToCheckExisting("MoldEditable", queryArray);
        }






        private void GetCommodityMolds()
        {
            string queryString;

            queryString = " @CommodityID int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      CommodityMolds.CommodityMoldID, CommodityMolds.MoldID, Molds.Code, Molds.Name, CommodityMolds.EntryDate, CommodityMolds.Remarks, CommodityMolds.Quantity, CommodityMolds.IsDefault, CommodityMolds.InActive " + "\r\n";
            queryString = queryString + "       FROM        CommodityMolds INNER JOIN Molds ON CommodityMolds.CommodityID = @CommodityID AND CommodityMolds.MoldID = Molds.MoldID " + "\r\n";
            queryString = queryString + "       ORDER BY    CommodityMolds.EntryDate, CommodityMolds.CommodityMoldID " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartPortalEntities.CreateStoredProcedure("GetCommodityMolds", queryString);
        }



        private void AddCommodityMold()
        {
            string queryString;

            queryString = " @CommodityID int, @MoldID int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";
            queryString = queryString + "       INSERT INTO     CommodityMolds  (CommodityID, MoldID, EntryDate, Quantity, Remarks, IsDefault, InActive) " + "\r\n";
            queryString = queryString + "       VALUES                          (@CommodityID, @MoldID, GETDATE(), 0, NULL, 0, 0) " + "\r\n";
            queryString = queryString + "    END " + "\r\n";

            this.totalSmartPortalEntities.CreateStoredProcedure("AddCommodityMold", queryString);
        }

        private void RemoveCommodityMold()
        {
            string queryString;

            queryString = " @CommodityMoldID int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";
            queryString = queryString + "       DELETE FROM     CommodityMolds WHERE CommodityMoldID = @CommodityMoldID" + "\r\n";
            queryString = queryString + "    END " + "\r\n";

            this.totalSmartPortalEntities.CreateStoredProcedure("RemoveCommodityMold", queryString);
        }

        private void UpdateCommodityMold()
        {
            string queryString = " @CommodityMoldID int, @CommodityID int, @Quantity decimal(18, 2), @IsDefault bit " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";

            queryString = queryString + "       BEGIN " + "\r\n";

            queryString = queryString + "           UPDATE          CommodityMolds " + "\r\n";
            queryString = queryString + "           SET             Quantity = @Quantity " + "\r\n";
            queryString = queryString + "           WHERE           CommodityMoldID = @CommodityMoldID " + "\r\n";

            queryString = queryString + "           UPDATE          CommodityMolds " + "\r\n";
            queryString = queryString + "           SET             IsDefault = IIF(CommodityMoldID = @CommodityMoldID, @IsDefault, 0) " + "\r\n";
            queryString = queryString + "           WHERE           CommodityID = @CommodityID " + "\r\n";

            queryString = queryString + "       END " + "\r\n";

            this.totalSmartPortalEntities.CreateStoredProcedure("UpdateCommodityMold", queryString);
        }

        private void GetMoldBases()
        {
            string queryString;

            queryString = " @SearchText nvarchar(60), @CommodityID int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      MoldID, Code, Name, Reference, Quantity " + " \r\n";
            queryString = queryString + "       FROM        Molds " + "\r\n";
            queryString = queryString + "       WHERE       InActive = 0 AND (@SearchText = '' OR Code LIKE '%' + @SearchText + '%' OR OfficialCode LIKE '%' + @SearchText + '%' OR Name LIKE '%' + @SearchText + '%' OR Reference LIKE '%' + @SearchText + '%') AND (@CommodityID = 0 OR MoldID IN (SELECT MoldID FROM CommodityMolds WHERE CommodityID = @CommodityID)) " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartPortalEntities.CreateStoredProcedure("GetMoldBases", queryString);
        }

    }
}

