using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Common.Application;
using Common.Application.FileUtil;
using Common.Application.SecurityUtil;
using Shop.Application.Utilities;
using Shop.Domain.Brands;

namespace Shop.Application.Brands.Edit
{
    public class EditBrandCommandHandler : IBaseRequestHandler<EditBrandCommand>
    {
        private readonly IBrandRepository _repository;

        public EditBrandCommandHandler(IBrandRepository brand)
        {
            _repository = brand;
        }

        public async Task<OperationResult> Handle(EditBrandCommand request, CancellationToken cancellationToken)
        {
            var model = await _repository.GetTracking(request.Id);
            if (model == null)
                return OperationResult.NotFound();

            var oldLogo = model.Logo;
            var oldImage = model.MainImage;
            var oldName = model.Name;
            string logo = null;
            string image = null;


            if (request.LogoFile != null)
                if (request.LogoFile.IsImage())
                    logo = await request.LogoFile.SaveFile(ShopDirectories.Brands(request.Name));

            if (request.ImageFile != null)
                if (request.ImageFile.IsImage())
                    image = await request.ImageFile.SaveFile(ShopDirectories.Brands(request.Name));

           

            model.Edit(request.Name, image, logo);
            _repository.Update(model);
            await _repository.Save();

            if (request.Name != oldName)
            {
                RenameDirectory.Rename(ShopDirectories.Brands(oldName), ShopDirectories.Brands(request.Name));
            }
            if (request.LogoFile != null)
                if (request.LogoFile.IsImage())
                    DeleteFileFromServer.DeleteFile(oldLogo, ShopDirectories.Brands(request.Name));

            if (request.ImageFile != null)
                if (request.ImageFile.IsImage())
                    DeleteFileFromServer.DeleteFile(oldImage, ShopDirectories.Brands(request.Name));

            return OperationResult.Success();
        }
    }
}