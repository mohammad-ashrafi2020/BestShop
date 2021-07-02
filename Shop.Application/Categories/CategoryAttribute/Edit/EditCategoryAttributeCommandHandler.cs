using System.Threading;
using System.Threading.Tasks;
using Common.Application;
using Shop.Domain.Categories.CategoryAttributes;

namespace Shop.Application.Categories.CategoryAttribute.Edit
{
    public class EditCategoryAttributeCommandHandler : IBaseRequestHandler<EditCategoryAttributeCommand>
    {
        private readonly ICategoryAttributeRepository _repository;

        public EditCategoryAttributeCommandHandler(ICategoryAttributeRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(EditCategoryAttributeCommand request, CancellationToken cancellationToken)
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