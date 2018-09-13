using System;
using System.Text;

using TotalBase;
using TotalBase.Enums;
using TotalModel.Models;

namespace TotalDAL.Helpers.SqlProgrammability.Commons
{
    public class Bom
    {
        private readonly TotalSmartPortalEntities totalSmartPortalEntities;

        public Bom(TotalSmartPortalEntities totalSmartPortalEntities)
        {
            this.totalSmartPortalEntities = totalSmartPortalEntities;
        }

        public void RestoreProcedure()
        {
            this.GetCommodityBoms();

            this.AddCommodityBom();
            this.RemoveCommodityBom();

            this.GetBomBases();
        }


        private void GetCommodityBoms()
        {
            string queryString;

            queryString = " @CommodityID int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      CommodityBoms.CommodityBomID, CommodityBoms.BomID, Boms.Code, Boms.Name, CommodityBoms.EntryDate, CommodityBoms.Remarks, CommodityBoms.IsDefault, CommodityBoms.InActive " + "\r\n";
            queryString = queryString + "       FROM        CommodityBoms INNER JOIN Boms ON CommodityBoms.CommodityID = @CommodityID AND CommodityBoms.BomID = Boms.BomID " + "\r\n";
            queryString = queryString + "       ORDER BY    CommodityBoms.EntryDate, CommodityBoms.CommodityBomID " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartPortalEntities.CreateStoredProcedure("GetCommodityBoms", queryString);
        }

        

        private void AddCommodityBom()
        {
            string queryString;

            queryString = " @CommodityID int, @BomID int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";
            queryString = queryString + "       INSERT INTO     CommodityBoms   (CommodityID, BomID, EntryDate, Remarks, IsDefault, InActive) " + "\r\n";
            queryString = queryString + "       VALUES                          (@CommodityID, @BomID, GETDATE(), NULL, 0, 0) " + "\r\n";
            queryString = queryString + "    END " + "\r\n";

            this.totalSmartPortalEntities.CreateStoredProcedure("AddCommodityBom", queryString);
        }

        private void RemoveCommodityBom()
        {
            string queryString;

            queryString = " @CommodityBomID int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";
            queryString = queryString + "       DELETE FROM     CommodityBoms WHERE CommodityBomID = @CommodityBomID" + "\r\n";
            queryString = queryString + "    END " + "\r\n";

            this.totalSmartPortalEntities.CreateStoredProcedure("RemoveCommodityBom", queryString);

        }

        private void GetBomBases()
        {
            string queryString;

            string querySQL = "             SELECT      BomID, Code, Name, Reference AS Reference " + " \r\n";
            querySQL = querySQL + "         FROM        Boms " + "\r\n";
            querySQL = querySQL + "         WHERE       InActive = 0 AND (@SearchText = '' OR Code LIKE '%' + @SearchText + '%' OR Reference LIKE '%' + @SearchText + '%') " + "\r\n";

            queryString = " @SearchText nvarchar(60), @CommodityID int, @CommodityCategoryID int, @CommodityClassID int, @CommodityLineID int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       IF (@CommodityID > 0) " + "\r\n"; //GET ALL BOMS BY @CommodityID
            queryString = queryString + "           " + querySQL + " AND BomID IN (SELECT BomID FROM CommodityBoms WHERE CommodityID = @CommodityID) " + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n"; //GET ALL BOMS BY @CommodityCategoryID AND @CommodityClassID AND @CommodityLineID
            queryString = queryString + "           " + querySQL + " AND CommodityCategoryID = @CommodityCategoryID AND CommodityClassID = @CommodityClassID AND CommodityLineID = @CommodityLineID " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartPortalEntities.CreateStoredProcedure("GetBomBases", queryString);
        }
    }
}
