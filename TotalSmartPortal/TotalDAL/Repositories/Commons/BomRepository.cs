using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

using TotalModel.Models;
using TotalCore.Repositories.Commons;
using System.Data.Entity.Core.Objects;

namespace TotalDAL.Repositories.Commons
{
    public class BomRepository : GenericRepository<Bom>, IBomRepository
    {
        public BomRepository(TotalSmartPortalEntities totalSmartPortalEntities)
            : base(totalSmartPortalEntities)
        {
        }
    }



    public class BomAPIRepository : GenericAPIRepository, IBomAPIRepository
    {
        public BomAPIRepository(TotalSmartPortalEntities totalSmartPortalEntities)
            : base(totalSmartPortalEntities, "GetBomIndexes")
        {
        }

        public IList<BomBase> GetBomBases(string searchText, int commodityID, int commodityCategoryID, int commodityClassID, int commodityLineID)
        {
            return this.TotalSmartPortalEntities.GetBomBases(searchText, commodityID, commodityCategoryID, commodityClassID, commodityLineID).ToList();
        }

        public IList<CommodityBom> GetCommodityBoms(int commodityID)
        {
            return this.TotalSmartPortalEntities.GetCommodityBoms(commodityID).ToList();
        }

        public void AddCommodityBoms(int? bomID, int? commodityID)
        {
            ObjectParameter[] parameters = new ObjectParameter[] { new ObjectParameter("BomID", bomID), new ObjectParameter("CommodityID", commodityID) };
            this.ExecuteFunction("AddCommodityBoms", parameters);
        }

        public void RemoveCommodityBoms(int? commodityBomID)
        {
            ObjectParameter[] parameters = new ObjectParameter[] { new ObjectParameter("CommodityBomID", commodityBomID) };
            this.ExecuteFunction("RemoveCommodityBoms", parameters);
        }
    }

}