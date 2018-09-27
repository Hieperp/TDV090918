using TotalModel.Models;

namespace TotalCore.Repositories.Inventories
{

    public interface IWarehouseTransferRepository : IGenericWithDetailRepository<WarehouseTransfer, WarehouseTransferDetail>
    {
    }

    public interface IWarehouseTransferAPIRepository : IGenericAPIRepository
    {
    }    
}
