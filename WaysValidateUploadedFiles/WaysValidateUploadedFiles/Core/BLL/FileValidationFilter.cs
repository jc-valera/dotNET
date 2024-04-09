using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WaysValidateUploadedFiles.Core.BLL
{
    public class FileValidationFilter(string[] allowedExtensions, long maxSize) : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var param = context.ActionArguments.SingleOrDefault(p => p.Value is IFormFile);

            if (param.Value is not IFormFile file || file.Length == 0)
            {
                context.Result = new BadRequestObjectResult("El archivo cargado es incorrecto.");

                return;
            }

            if (!FileValidator.IsFileExtensionAllowed(file, allowedExtensions))
            {
                var allowedExtensionsMessage = string.Join(", ", allowedExtensions).Replace(".", "").ToUpper();

                context.Result = new BadRequestObjectResult($"Tipo de archivo invalido. Archivos validos solo con extencion {allowedExtensionsMessage}");

                return;
            }

            if (!FileValidator.IsFileSizeWithinLimit(file, maxSize))
            {
                var mbSize = maxSize / 1024 / 1024;

                context.Result = new BadRequestObjectResult($"El archivo excede el limite de tamaño que es de ({maxSize} mb).");
            }

            if (FileValidator.IsFileWithSameName(file))
            {
                context.Result = new BadRequestObjectResult($"Ya se ha encontrado un documento con el mismo nombre.");

                return;
            }

        }
    }
}
