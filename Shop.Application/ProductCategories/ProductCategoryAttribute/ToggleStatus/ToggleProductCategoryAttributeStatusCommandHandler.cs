using System.Threading;
using System.Threading.Tasks;
using Common.Application;
using Shop.Domain.Categories.CategoryAttributes;

namespace Shop.Application.ProductCategories.ProductCategoryAttribute.ToggleStatus
{
    public class ToggleProductCategoryAttributeStatusCommandHandler : IBaseRequestHandler<ToggleProductCategoryAttributeStatusCommand>
    {
        private readonly ICategoryAttributeRepository _repository;

        public ToggleProductCategoryAttributeStatusCommandHandler(ICategoryAttributeRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(ToggleProductCategoryAttributeStatusCommand request, CancellationToken cancellationToken)
        {
            await _repository.ToggleStatus(request.Id);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}