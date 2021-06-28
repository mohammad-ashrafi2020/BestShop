using System.Threading;
using System.Threading.Tasks;
using Common.Application;
using Shop.Domain.Categories;

namespace Shop.Application.ProductCategories.ProductCategory.ToggleStatus
{
    public class ProductCategoryToggleStatusCommandHandler : IBaseRequestHandler<ProductCategoryToggleStatusCommand>
    {
        private readonly ICategoryRepository _repository;

        public ProductCategoryToggleStatusCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<OperationResult> Handle(ProductCategoryToggleStatusCommand request, CancellationToken cancellationToken)
        {
            await _repository.ToggleStatus(request.Id);
            await _repository.Save();

            return OperationResult.Success();
        }
    }
}