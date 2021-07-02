using System.Threading;
using System.Threading.Tasks;
using Common.Application;
using Shop.Domain.Categories.CategoryAttributes;

namespace Shop.Application.Categories.CategoryAttribute.ToggleStatus
{
    public class ToggleCategoryAttributeStatusCommandHandler : IBaseRequestHandler<ToggleCategoryAttributeStatusCommand>
    {
        private readonly ICategoryAttributeRepository _repository;

        public ToggleCategoryAttributeStatusCommandHandler(ICategoryAttributeRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(ToggleCategoryAttributeStatusCommand request, CancellationToken cancellationToken)
        {
            await _repository.ToggleStatus(request.Id);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}