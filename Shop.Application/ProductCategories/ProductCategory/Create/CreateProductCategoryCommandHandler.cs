using System;
using System.Threading;
using System.Threading.Tasks;
using Common.Application;
using Common.Application.FileUtil;
using Common.Application.SecurityUtil;
using Shop.Application.Utilities;
using Shop.Domain.Categories;
using Shop.Domain.Categories.Rule;

namespace Shop.Application.ProductCategories.ProductCategory.Create
{
    public class CreateProductCategoryCommandHandler : IBaseRequestHandler<CreateProductCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICategorySlugUniquenessChecker _slugChecker;
        public CreateProductCategoryCommandHandler(ICategoryRepository categoryRepository, ICategorySlugUniquenessChecker slugChecker)
        {
            _categoryRepository = categoryRepository;
            _slugChecker = slugChecker;
        }

        public async Task<OperationResult> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var imageName = "default.png";
            if (request.ImageFile != null)
                if (request.ImageFile.IsImage())
                    imageName = await request.ImageFile.SaveFile(ShopDirectories.ProductCategories);

            if (request.ParentId is > 0)
            {
                var category = await _categoryRepository.Get((int)request.ParentId);
                if (category == null)
                    return OperationResult.NotFound();

                category.AddChild(request.Slug, request.Title, imageName, request.MetaValue, request.ShowInMenu, _slugChecker);
                await _categoryRepository.AddRange(category.SubCategories);
            }
            else
            {
                Category category =
                    new(request.Title, request.Slug, request.MetaValue, imageName, request.ShowInMenu, _slugChecker);
                await _categoryRepository.Create(category);
            }


            try
            {
                await _categoryRepository.Save();
            }
            catch (Exception e)
            {
                if (imageName != "default.png")
                    DeleteFileFromServer.DeleteFile(imageName, ShopDirectories.ProductCategories);

                throw new Exception(e.Message, e);
            }
            return OperationResult.Success();
        }
    }
}