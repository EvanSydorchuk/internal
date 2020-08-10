using System.IO;
using System.Threading.Tasks;
using BLL.Common.Models;

namespace BLL.Common
{
    public static class DirectoryManager
    {
        public static async Task<string> SaveFileInFolder(string rootPath, FileModel fileModel)
        {
            var file = fileModel.File;
            var newPath = Path.Combine(rootPath, fileModel.Path);

            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }

            var fullPath = Path.Combine(newPath, fileModel.Name);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return fullPath;
        }

        public static void RemoveFileFromFolder(string path)
        {
            var file = new FileInfo(path);

            if (file.Exists)
            {
                file.Delete();
            }
        }

        public static void RemoveFolder(string path)
        {
            var directory = new DirectoryInfo(path);

            if (directory.Exists)
            {
                directory.Delete(true);
            }
        }
    }
}
