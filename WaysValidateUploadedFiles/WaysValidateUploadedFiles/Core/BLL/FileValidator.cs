namespace WaysValidateUploadedFiles.Core.BLL
{
    public static class FileValidator
    {
        public static bool IsFileCorrect(IFormFile file)
        {
            bool isFileCorrect = true;

            if (file is null || file.Length == 0)
                isFileCorrect = false;

            return isFileCorrect;
        }

        public static bool IsFileExtensionAllowed(IFormFile file, string[] allowedExtensions)
        {
            var extension = Path.GetExtension(file.FileName);

            var extensionIsAllowed = allowedExtensions.Contains(extension);

            return extensionIsAllowed;
        }

        public static bool IsFileSizeWithinLimit(IFormFile file, long maxSizeInBytes)
        {
            var length = file.Length <= maxSizeInBytes;

            return length;
        }

        public static bool IsFileWithSameName(IFormFile file)
        {
            var fileExist = false;
            var logicGetFileName = "CV_Carlos_Valera_mx";

            var currentFileName = Path.GetFileNameWithoutExtension(file.FileName);

            if (currentFileName == logicGetFileName)
                fileExist = true;

            return fileExist;
        }
    }
}
