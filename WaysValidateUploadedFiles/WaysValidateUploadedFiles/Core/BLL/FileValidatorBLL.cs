
namespace WaysValidateUploadedFiles.Core.BLL
{
    public class FileValidatorBLL
    {
        public bool IsFileCorrect(IFormFile file)
        {
            bool isFileCorrect = true;

            if (file is null || file.Length == 0)
                isFileCorrect = false;

            return isFileCorrect;
        }

        public bool IsFileExtensionAllowed(IFormFile file, string[] allowedExtensions)
        {
            var extension = Path.GetExtension(file.FileName);

            var extensionIsAllowed = allowedExtensions.Contains(extension);

            return extensionIsAllowed;
        }

        public bool IsFileSizeWithinLimit(IFormFile file, long maxSizeInBytes)
        {
            var length = file.Length <= maxSizeInBytes;

            return length;
        }

        public bool IsFileWithSameName(IFormFile file)
        {
            var fileExist = false;
            var logicGetFileName = "CV_Carlos_Valera_mx";

            var currentFileName = Path.GetFileNameWithoutExtension(file.FileName);

            if (currentFileName == logicGetFileName)
                fileExist = true;

            return fileExist;
        }

        public async Task SaveDocument(IFormFile file)
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var saveTestPath = config.GetValue<string>("AppSettings:TempPath");

            var pathToSave = Path.Combine(saveTestPath, "Uploads");

            if (!Directory.Exists(pathToSave))
                Directory.CreateDirectory(pathToSave);

            var fullPath = Path.Combine(pathToSave, file.FileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
        }
    }
}
