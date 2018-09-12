using System.Collections.Generic;

using TotalModel.Models;

namespace TotalCore.Repositories.Commons
{
    public interface IBomRepository : IGenericRepository<Bom>
    {
    }

    public interface IBomAPIRepository : IGenericAPIRepository
    {
        IList<BomBase> GetBomBases(string searchText, int commodityID, int commodityCategoryID, int commodityClassID, int commodityLineID);
    }
}