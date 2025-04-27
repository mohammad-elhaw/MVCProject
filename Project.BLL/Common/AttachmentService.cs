using Microsoft.AspNetCore.Http;

namespace Project.BLL.Common
{
    public class AttachmentService : IAttachmentService
    {
        List<string> allowedExtensions = [".jpg", ".png", ".jpeg"];
        const int maxSize = 2_097_152;

        public async Task<string>? UploadFile(IFormFile file, string folderName)
        {
            // check extensions
            var extension = Path.GetExtension(file.FileName);
            if (!allowedExtensions.Contains(extension)) return null;

            // check size
            if (file.Length is 0 or > maxSize) return null;

            // Get Located Folder path
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", folderName);

            // Make Attachment Name Unique => Guid
            var attachmentName = $"{Guid.NewGuid()}_{file.FileName}";

            // Get File Path
            var filePath = Path.Combine(folderPath, attachmentName);

            // Create File Stream to copy the file
            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            // Return the file Name
            return attachmentName;
        }

        public bool DeleteFile(string filePath)
        {
            if (!File.Exists(filePath)) return false;
            File.Delete(filePath);
            return true;
        }
    }

}
