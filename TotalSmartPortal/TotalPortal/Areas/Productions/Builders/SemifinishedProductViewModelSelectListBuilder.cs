using TotalCore.Repositories.Commons;

using TotalPortal.Builders;
using TotalPortal.Areas.Commons.Builders;
using TotalPortal.Areas.Productions.ViewModels;

namespace TotalPortal.Areas.Productions.Builders
{
    public interface ISemifinishedProductViewModelSelectListBuilder : IViewModelSelectListBuilder<SemifinishedProductViewModel>
    {
    }

    public class SemifinishedProductViewModelSelectListBuilder : A01ViewModelSelectListBuilder<SemifinishedProductViewModel>, ISemifinishedProductViewModelSelectListBuilder
    {
        public SemifinishedProductViewModelSelectListBuilder(IAspNetUserSelectListBuilder aspNetUserSelectListBuilder, IAspNetUserRepository aspNetUserRepository)
            : base(aspNetUserSelectListBuilder, aspNetUserRepository)
        {
        }
    }
}