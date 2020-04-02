using System.IO;

namespace Core.Domain.FileService
{
    public class FileService : IFileService
    {
        public FileService() { }
        public void SaveFiles(Stream files)
        {

        }
    }

    public interface IFileService
    {
        void SaveFiles(Stream files);
    }
}
