using System.Threading;
using System.Threading.Tasks;
using Common.Application;
using Shop.Domain.ProductCategories.ProductCategoryAttributes;

namespace Shop.Application.ProductCategories.ProductCategoryAttribute.Create
{
    public class CreateProductCategoryAttributeCommandHandler : IBaseRequestHandler<CreateProductCategoryAttributeCommand>
    {
        private readonly IProductCategoryAttributeRepository _repository;

        public CreateProductCategoryAttributeCommandHandler(IProductCategoryAttributeRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(CreateProductCategoryAttributeCommand request, CancellationToken cancellationToken)
        {
            if (request.ParentId is > 0)
            {
                var parent = await _repository.GetTracking((long)request.ParentId);
                if (parent == null)
                    return OperationResult.NotFound();
                parent.AddChild(request.Key, request.Hint, request.DisplayOrder);
                _repository.Update(parent);
                await _repository.Save();
                return OperationResult.Success();
            }

            var model = new Domain.ProductCategories.ProductCategoryAttributes
                .ProductCategoryAttribute(request.Key, request.CategoryId, request.Hint, request.DisplayOrder);
            await _repository.Create(model);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}