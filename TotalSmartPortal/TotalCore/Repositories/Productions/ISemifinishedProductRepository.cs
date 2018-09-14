using System;
using System.Collections.Generic;

using TotalModel.Models;

namespace TotalCore.Repositories.Productions
{   
    public interface ISemifinishedProductRepository : IGenericWithDetailRepository<SemifinishedProduct, SemifinishedProductDetail>
    {
    }

    public interface ISemifinishedProductAPIRepository : IGenericAPIRepository
    {
        IEnumerable<SemifinishedProductPendingMaterialIssueDetail> GetMaterialIssueDetails(int? locationID);
        
    }
}
