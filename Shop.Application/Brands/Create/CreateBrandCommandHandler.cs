using System.Threading;
using System.Threading.Tasks;
using Common.Application;
using Common.Application.FileUtil;
using Common.Application.SecurityUtil;
using Common.Core.Utilities;
using Shop.Application.Utilities;
using Shop.Domain.Brands;

namespace Shop.Application.Brands.Create
{
    public class CreateBrandCommandHandler : IBaseRequestHandler<CreateBrandCommand>
    {
        private readonly IBrandRepository _repository;

        public CreateBrandCommandHandler(IBrandRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            string logo = null;
            string image = null;
            if (request.LogoFile != null)
                if (request.LogoFile.IsImage())
                    logo = await request.LogoFile.SaveFile(ShopDirectories.Brands(request.Name.ToSlug()));

            if (request.ImageFile != null)
                if (request.ImageFile.IsImage())
                    image = await request.ImageFile.SaveFile(ShopDirectories.Brands(request.Name.ToSlug()));

            var model = new Brand(request.Name, logo, image);
            await _repository.Create(model);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}