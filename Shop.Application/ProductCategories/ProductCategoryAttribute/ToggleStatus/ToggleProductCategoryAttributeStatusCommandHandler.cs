using System.Threading;
using System.Threading.Tasks;
using Common.Application;
using Shop.Domain.ProductCategories.ProductCategoryAttributes;

namespace Shop.Application.ProductCategories.ProductCategoryAttribute.ToggleStatus
{
    public class ToggleProductCategoryAttributeStatusCommandHandler : IBaseRequestHandler<ToggleProductCategoryAttributeStatusCommand>
    {
        private readonly IProductCategoryAttributeRepository _repository;

        public ToggleProductCategoryAttributeStatusCommandHandler(IProductCategoryAttributeRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(ToggleProductCategoryAttributeStatusCommand request, CancellationToken cancellationToken)
        {
            var model = await _repository.GetTracking(request.Id);
            if (model == null)
                return OperationResult.NotFound();

            if (model.IsDelete)
                model.Recovery();
            else
                model.Delete();

            _repository.Update(model);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}