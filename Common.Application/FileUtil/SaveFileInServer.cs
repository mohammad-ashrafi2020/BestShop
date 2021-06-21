using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Common.Application.FileUtil
{
    public static class SaveFileInServer
    {
        public static async Task<string> SaveFile(this IFormFile inputTarget, string savePath, bool isGenerateGuid = true)
        {
            if (inputTarget == null) return "File Not Found";
            var fileName = inputTarget.FileName;
            if (isGenerateGuid)
            {
                fileName = Guid.NewGuid() + DateTime.Now.TimeOfDay.ToString()
                                              .Replace(":", "")
                                              .Replace(".", "") + Path.GetExtension(fileName);
            }

            var folderName = Path.Combine(Directory.GetCurrentDirectory(), savePath.Replace("/", "\\"));
            if (!Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName);
            }
            var path = Path.Combine(folderName, fileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await inputTarget.CopyToAsync(stream);
            }
            return fileName;
        }
    }
}