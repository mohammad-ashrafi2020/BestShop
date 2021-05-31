using System.IO;

namespace framework.FileUtil
{
    public static class DeleteFileFromServer
    {
        public static void DeleteFile(string fileName, string path)
        {
            try
            {
                var pathDelete = Path.Combine(Directory.GetCurrentDirectory(), path,
                    fileName);
                if (File.Exists(pathDelete))
                {
                    File.Delete(pathDelete);
                }
            }
            catch
            {
                //Ignore
            }

        }
        public static void DeleteFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
            catch
            {
                //Ignore
            }

        }
    }
}