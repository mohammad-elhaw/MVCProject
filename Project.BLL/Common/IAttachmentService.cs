using Microsoft.AspNetCore.Http;

namespace Project.BLL.Common
{
    public interface IAttachmentService
    {
        Task<string>? UploadFile(IFormFile file, string folderName);
        bool DeleteFile(string filePath);
    }
}
