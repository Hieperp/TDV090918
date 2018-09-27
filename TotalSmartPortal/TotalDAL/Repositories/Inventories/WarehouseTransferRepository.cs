using System;
using System.Data.Entity.Core.Objects;

using TotalModel.Models;
using TotalCore.Repositories.Inventories;

namespace TotalDAL.Repositories.Inventories
{  
    public class WarehouseTransferRepository : GenericWithDetailRepository<WarehouseTransfer, WarehouseTransferDetail>, IWarehouseTransferRepository
    {
        public WarehouseTransferRepository(TotalSmartPortalEntities totalSmartPortalEntities)
            : base(totalSmartPortalEntities, "WarehouseTransferEditable", "WarehouseTransferApproved", null, "WarehouseTransferVoidable")
        {
        }
    }








    public class WarehouseTransferAPIRepository : GenericAPIRepository, IWarehouseTransferAPIRepository
    {
        public WarehouseTransferAPIRepository(TotalSmartPortalEntities totalSmartPortalEntities)
            : base(totalSmartPortalEntities, "GetWarehouseTransferIndexes")
        {
        }

        protected override ObjectParameter[] GetEntityIndexParameters(string aspUserID, DateTime fromDate, DateTime toDate)
        {

            ObjectParameter[] baseParameters = base.GetEntityIndexParameters(aspUserID, fromDate, toDate);
            ObjectParameter[] objectParameters = new ObjectParameter[] { new ObjectParameter("NMVNTaskID", this.RepositoryBag.ContainsKey("NMVNTaskID") && this.RepositoryBag["NMVNTaskID"] != null ? this.RepositoryBag["NMVNTaskID"] : 0), baseParameters[0], baseParameters[1], baseParameters[2] };

            this.RepositoryBag.Remove("NMVNTaskID");

            return objectParameters;
        }
    }
}
