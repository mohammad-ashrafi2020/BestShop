using System.Threading;
using System.Threading.Tasks;
using Common.Application;
using Common.Application.FileUtil;
using Common.Application.SecurityUtil;
using Shop.Application.Utilities;
using Shop.Domain.Categories;
using Shop.Domain.Categories.Rule;

namespace Shop.Application.ProductCategories.ProductCategory.Edit
{
    public class EditProductCategoryCommandHandler : IBaseRequestHandler<EditProductCategoryCommand>
    {
        private readonly ICategoryRepository _repository;
        private readonly ICategorySlugUniquenessChecker _slugChecker;
        public EditProductCategoryCommandHandler(ICategoryRepository repository, ICategorySlugUniquenessChecker slugChecker)
        {
            _repository = repository;
            _slugChecker = slugChecker;
        }

        public async Task<OperationResult> Handle(EditProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetTracking(request.Id);

            if (category == null)
                return OperationResult.NotFound();

            var oldImage = category.ImageName;
            var imageName = category.ImageName;

            //Save New Image
            if (request.ImageFile != null)
                if (request.ImageFile.IsImage())
                    imageName = await request.ImageFile.SaveFile(ShopDirectories.ProductCategories);

            category.Edit(request.Title, request.Slug, imageName, request.MetaValue,request.ShowInMenu, _slugChecker);
            _repository.Update(category);
            await _repository.Save();

            //Delete Old Image
            if (oldImage != imageName)
                DeleteFileFromServer.DeleteFile(oldImage, ShopDirectories.ProductCategories);

            return OperationResult.Success();
        }
    }
}