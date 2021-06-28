using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Application.FileUtil
{
    public static class RenameDirectory
    {
        public static void Rename(string sourceDirName, string destDirName)
        {
            try
            {
                Directory.Move(sourceDirName, destDirName);
            }
            catch
            {
                //Igonord
            }
        }
    }
}
