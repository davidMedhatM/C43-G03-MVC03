using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Helper
{
    public class DocumentSetting
    {
        public static string UploadFile(IFormFile file, string folderName)
        {
            // 1. Get Folder Path
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", folderName);

            // 2. Get File Name
            var fileName = $"{Guid.NewGuid()}-{file.FileName}";

            // 3. Combine Folder Path + FilePath
            var filePath = Path.Combine(folderPath, fileName);

            // 4. Save File
            using var fileStream = new FileStream(filePath, FileMode.Create);
            file.CopyTo(fileStream);

            return fileName;
        }
    }
}
