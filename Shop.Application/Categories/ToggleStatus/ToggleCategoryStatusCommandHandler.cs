using System.Threading;
using System.Threading.Tasks;
using Common.Application;
using Shop.Domain.Categories;

namespace Shop.Application.Categories.ToggleStatus
{
    public class ToggleCategoryStatusCommandHandler : IBaseRequestHandler<ToggleCategoryStatusCommand>
    {
        private readonly ICategoryRepository _repository;

        public ToggleCategoryStatusCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<OperationResult> Handle(ToggleCategoryStatusCommand request, CancellationToken cancellationToken)
        {
            await _repository.ToggleStatus(request.Id);
            await _repository.Save();

            return OperationResult.Success();
        }
    }
}