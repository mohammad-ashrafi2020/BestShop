using System.Threading;
using System.Threading.Tasks;
using Common.Application;
using Shop.Domain.ProductCategories.ProductCategory;

namespace Shop.Application.ProductCategories.ProductCategory.ToggleStatus
{
    public class ProductCategoryToggleStatusCommandHandler : IBaseRequestHandler<ProductCategoryToggleStatusCommand>
    {
        private readonly IProductCategoryRepository _repository;

        public ProductCategoryToggleStatusCommandHandler(IProductCategoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<OperationResult> Handle(ProductCategoryToggleStatusCommand request, CancellationToken cancellationToken)
        {
            var category = await _repository.Get(request.Id);

            if (category == null)
                return OperationResult.NotFound();


            if(category.IsDelete)
                category.Recovery();
            else
                category.Delete();

            _repository.Update(category);
            await _repository.Save();

            return OperationResult.Success();
        }
    }
}