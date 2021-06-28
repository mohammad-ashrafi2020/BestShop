using System.Threading;
using System.Threading.Tasks;
using Common.Application;
using Shop.Domain.Brands;

namespace Shop.Application.Brands.ToggleStatus
{
    public class ToggleBrandStatusCommandHandler : IBaseRequestHandler<ToggleBrandStatusCommand>
    {
        private readonly IBrandRepository _repository;

        public ToggleBrandStatusCommandHandler(IBrandRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(ToggleBrandStatusCommand request, CancellationToken cancellationToken)
        {
            await _repository.ToggleStatus(request.Id);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}