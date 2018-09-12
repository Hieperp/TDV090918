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
            this.GetBomByCommodities();       

            this.AddBomCommodities();
            this.RemoveBomCommodities();        
        }


        private void GetBomByCommodities()
        {
            string queryString;

            string queryWhere = "Boms.InActive = 0 AND Boms.CommodityCategoryID = @CommodityCategoryID AND Boms.CommodityClassID = @CommodityClassID AND Boms.CommodityLineID = @CommodityLineID";

            queryString = " @CommodityID int, @CommodityCategoryID int, @CommodityClassID int, @CommodityLineID int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "               SELECT * FROM Boms WHERE BomID IN " + "\r\n";
            queryString = queryString + "                   (SELECT Boms.BomID FROM Boms WHERE " + queryWhere + "\r\n";
            queryString = queryString + "                   UNION ALL " + "\r\n";
            queryString = queryString + "                   SELECT Boms.BomID FROM Boms INNER JOIN CommodityBoms ON " + queryWhere + " AND CommodityBoms.CommodityID = @CommodityID AND Boms.BomID = CommodityBoms.BomID " + "\r\n";
            queryString = queryString + "                   )" + "\r\n";
            queryString = queryString + "               ORDER BY Code, Name " + "\r\n";
            
            queryString = queryString + "    END " + "\r\n";

            this.totalSmartPortalEntities.CreateStoredProcedure("GetBomByCommodities", queryString);
        }


        private void AddBomCommodities()
        {
            string queryString;

            queryString = " @BomID int, @CommodityID int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";
            queryString = queryString + "       INSERT INTO     CommodityBoms (CommodityID, BomID, EntryDate, Remarks, IsDefault, InActive) " + "\r\n";
            queryString = queryString + "       VALUES          (@CommodityID, @BomID, GETDATE(), '', 0, 0) " + "\r\n";
            queryString = queryString + "    END " + "\r\n";

            this.totalSmartPortalEntities.CreateStoredProcedure("AddBomCommodities", queryString);
        }

        private void RemoveBomCommodities()
        {
            string queryString;

            queryString = " @BomID int, @CommodityID int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";
            queryString = queryString + "       DELETE FROM     CommodityBoms " + "\r\n";
            queryString = queryString + "       WHERE           BomID = @BomID AND CommodityID = @CommodityID " + "\r\n";
            queryString = queryString + "    END " + "\r\n";

            this.totalSmartPortalEntities.CreateStoredProcedure("RemoveBomCommodities", queryString);

        }


    }
}
