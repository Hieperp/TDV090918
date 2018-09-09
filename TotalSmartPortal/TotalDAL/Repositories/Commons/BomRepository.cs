using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

using TotalModel.Models;
using TotalCore.Repositories.Commons;

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

        public IList<BomBase> GetBomBases(string searchText, int commodityID)
        {
            return this.TotalSmartPortalEntities.GetBomBases(searchText, commodityID).ToList();
        }
    }

}