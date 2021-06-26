using System.Threading;
using System.Threading.Tasks;
using Common.Application;
using Common.Application.FileUtil;
using Common.Application.SecurityUtil;
using Shop.Application.Utilities;
using Shop.Domain.ProductCategories.ProductCategory;
using Shop.Domain.ProductCategories.ProductCategory.Rule;

namespace Shop.Application.ProductCategories.ProductCategory.Commands.Edit
{
    public class EditProductCategoryCommandHandler : IBaseRequestHandler<EditProductCategoryCommand>
    {
        private readonly IProductCategoryRepository _repository;
        private readonly IProductCategorySlugUniquenessChecker _slugChecker;
        public EditProductCategoryCommandHandler(IProductCategoryRepository repository, IProductCategorySlugUniquenessChecker slugChecker)
        {
            _repository = repository;
            _slugChecker = slugChecker;
        }

        public async Task<OperationResult> Handle(EditProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repository.Get(request.Id);

            if (category == null)
                return OperationResult.NotFound();

            var oldImage = category.ImageName;
            var imageName = category.ImageName;

            //Save New Image
            if (request.ImageFile != null)
                if (request.ImageFile.IsImage())
                    imageName = await request.ImageFile.SaveFile(ShopDirectories.ProductCategories);

            category.Edit(request.Title, request.Slug, imageName, request.MetaValue, _slugChecker);
            _repository.Update(category);
            await _repository.Save();

            //Delete Old Image
            if (oldImage != imageName)
                DeleteFileFromServer.DeleteFile(oldImage, ShopDirectories.ProductCategories);

            return OperationResult.Success();
        }
    }
}