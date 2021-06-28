using System.Threading;
using System.Threading.Tasks;
using Common.Application;
using Shop.Domain.ProductCategories.ProductCategoryAttributes;

namespace Shop.Application.ProductCategories.ProductCategoryAttribute.Edit
{
    public class EditProductCategoryAttributeCommandHandler : IBaseRequestHandler<EditProductCategoryAttributeCommand>
    {
        private readonly IProductCategoryAttributeRepository _repository;

        public EditProductCategoryAttributeCommandHandler(IProductCategoryAttributeRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(EditProductCategoryAttributeCommand request, CancellationToken cancellationToken)
        {
            var model = await _repository.GetTracking(request.Id);
            if(model==null)
                return OperationResult.NotFound();

            model.Edit(request.Key,request.Hint,request.DisplayOrder);
            _repository.Update(model);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}