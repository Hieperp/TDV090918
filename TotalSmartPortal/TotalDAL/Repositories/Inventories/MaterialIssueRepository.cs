using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;

using TotalBase.Enums;
using TotalModel.Models;
using TotalCore.Repositories.Inventories;

namespace TotalDAL.Repositories.Inventories
{
    public class MaterialIssueRepository : GenericWithDetailRepository<MaterialIssue, MaterialIssueDetail>, IMaterialIssueRepository
    {
        public MaterialIssueRepository(TotalSmartPortalEntities totalSmartPortalEntities)
            : base(totalSmartPortalEntities, "MaterialIssueEditable", "MaterialIssueApproved")
        {
        }
    }








    public class MaterialIssueAPIRepository : GenericAPIRepository, IMaterialIssueAPIRepository
    {
        public MaterialIssueAPIRepository(TotalSmartPortalEntities totalSmartPortalEntities)
            : base(totalSmartPortalEntities, "GetMaterialIssueIndexes")
        {
        }

        public IEnumerable<MaterialIssuePendingFirmOrder> GetFirmOrders(int? locationID)
        {
            this.TotalSmartPortalEntities.Configuration.ProxyCreationEnabled = false;
            IEnumerable<MaterialIssuePendingFirmOrder> pendingFirmOrders = base.TotalSmartPortalEntities.GetMaterialIssuePendingFirmOrders(locationID).ToList();
            this.TotalSmartPortalEntities.Configuration.ProxyCreationEnabled = true;

            return pendingFirmOrders;
        }

        public IEnumerable<MaterialIssuePendingFirmOrderDetail> GetPendingFirmOrderDetails(int? locationID, int? materialIssueID, int? firmOrderID, int? warehouseID, string firmOrderMaterialIDs, bool isReadonly)
        {
            this.TotalSmartPortalEntities.Configuration.ProxyCreationEnabled = false;
            IEnumerable<MaterialIssuePendingFirmOrderDetail> pendingFirmOrderDetails = base.TotalSmartPortalEntities.GetMaterialIssuePendingFirmOrderDetails(locationID, materialIssueID, firmOrderID, warehouseID, firmOrderMaterialIDs, isReadonly).ToList();
            this.TotalSmartPortalEntities.Configuration.ProxyCreationEnabled = true;

            return pendingFirmOrderDetails;
        }

    }


}
