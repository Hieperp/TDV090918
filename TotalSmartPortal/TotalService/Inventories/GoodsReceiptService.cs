using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;

using TotalDTO;
using TotalModel;
using TotalModel.Models;
using TotalDTO.Inventories;
using TotalCore.Repositories.Inventories;
using TotalCore.Services.Inventories;

namespace TotalService.Inventories
{
    public class GoodsReceiptService<TDto, TPrimitiveDto, TDtoDetail> : GoodsReceiptBaseService<TDto, TPrimitiveDto, TDtoDetail>, IGoodsReceiptService<TDto, TPrimitiveDto, TDtoDetail>
        where TDto : TPrimitiveDto, IBaseDetailEntity<TDtoDetail>, IGoodsReceiptDTO
        where TPrimitiveDto : BaseDTO, IPrimitiveEntity, IPrimitiveDTO, new()
        where TDtoDetail : class, IPrimitiveEntity
    {
        public GoodsReceiptService(IGoodsReceiptRepository goodsReceiptRepository)
            : base(goodsReceiptRepository)
        {
        }

        public override bool Approvable(TDto dto)
        {
            return (dto.WarehouseAdjustmentID == null) && base.Approvable(dto);
        }

        public override bool UnApprovable(TDto dto)
        {
            return (dto.WarehouseAdjustmentID == null) && base.UnApprovable(dto);
        }

        public override bool Editable(TDto dto)
        {
            return (dto.WarehouseAdjustmentID == null) && base.Editable(dto);
        }
    }

    public class GoodsReceiptBaseService<TDto, TPrimitiveDto, TDtoDetail> : GenericWithViewDetailService<GoodsReceipt, GoodsReceiptDetail, GoodsReceiptViewDetail, TDto, TPrimitiveDto, TDtoDetail>, IGoodsReceiptBaseService<TDto, TPrimitiveDto, TDtoDetail>
        where TDto : TPrimitiveDto, IBaseDetailEntity<TDtoDetail>, IGoodsReceiptDTO
        where TPrimitiveDto : BaseDTO, IPrimitiveEntity, IPrimitiveDTO, new()
        where TDtoDetail : class, IPrimitiveEntity
    {
        public GoodsReceiptBaseService(IGoodsReceiptRepository goodsReceiptRepository)
            : base(goodsReceiptRepository, "GoodsReceiptPostSaveValidate", "GoodsReceiptSaveRelative", "GoodsReceiptToggleApproved", null, null, "GetGoodsReceiptViewDetails")
        {
        }

        public new bool Save(TDto goodsReceiptDTO, bool useExistingTransaction)
        {
            goodsReceiptDTO.GoodsReceiptViewDetails.RemoveAll(x => x.Quantity == 0);
            return base.Save(goodsReceiptDTO, useExistingTransaction);
        }

        public new bool Delete(int id, bool useExistingTransaction)
        {
            return base.Delete(id, useExistingTransaction);
        }

        public override ICollection<GoodsReceiptViewDetail> GetViewDetails(int goodsReceiptID)
        {
            ObjectParameter[] parameters = new ObjectParameter[] { new ObjectParameter("GoodsReceiptID", goodsReceiptID) };
            return this.GetViewDetails(parameters);
        }
    }








    public class MaterialReceiptService : GoodsReceiptService<GoodsReceiptDTO<GROptionMaterial>, GoodsReceiptPrimitiveDTO<GROptionMaterial>, GoodsReceiptDetailDTO>, IMaterialReceiptService
    {
        public MaterialReceiptService(IGoodsReceiptRepository warehouseReceiptRepository)
            : base(warehouseReceiptRepository) { }
    }
    public class ItemReceiptService : GoodsReceiptService<GoodsReceiptDTO<GROptionItem>, GoodsReceiptPrimitiveDTO<GROptionItem>, GoodsReceiptDetailDTO>, IItemReceiptService
    {
        public ItemReceiptService(IGoodsReceiptRepository warehouseReceiptRepository)
            : base(warehouseReceiptRepository) { }
    }
    public class ProductReceiptService : GoodsReceiptService<GoodsReceiptDTO<GROptionProduct>, GoodsReceiptPrimitiveDTO<GROptionProduct>, GoodsReceiptDetailDTO>, IProductReceiptService
    {
        public ProductReceiptService(IGoodsReceiptRepository warehouseReceiptRepository)
            : base(warehouseReceiptRepository) { }
    }
}