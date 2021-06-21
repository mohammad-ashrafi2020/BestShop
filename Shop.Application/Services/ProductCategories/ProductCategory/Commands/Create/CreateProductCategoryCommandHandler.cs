using System.Threading;
using System.Threading.Tasks;
using Common.Application;
using Common.Application.FileUtil;
using Common.Application.SecurityUtil;
using Shop.Application.Utilities;
using Shop.Domain.ProductCategories.ProductCategory;
using Shop.Domain.ProductCategories.ProductCategory.Rule;

namespace Shop.Application.Services.ProductCategories.ProductCategory.Commands.Create
{
    public class CreateProductCategoryCommandHandler : IBaseRequestHandler<CreateProductCategoryCommand>
    {
        private readonly IProductCategoryRepository _categoryRepository;
        private readonly IProductCategorySlugUniquenessChecker _slugChecker;
        public CreateProductCategoryCommandHandler(IProductCategoryRepository categoryRepository, IProductCategorySlugUniquenessChecker slugChecker)
        {
            _categoryRepository = categoryRepository;
            _slugChecker = slugChecker;
        }

        public async Task<OperationResult> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var imageName = "default.png";
            if (request.imageFile != null)
                if (request.imageFile.IsImage())
                    imageName = await request.imageFile.SaveFile(ShopDirectories.ProductCategories);

            Domain.ProductCategories.ProductCategory.ProductCategory category = new(request.Title, request.Slug, request.MetaValue, imageName, request.ShowInMenu, _slugChecker);
            await _categoryRepository.Create(category);
            return OperationResult.Success();
        }
    }
}