using Microsoft.AspNetCore.Mvc;
using WaysValidateUploadedFiles.Core.BLL;

namespace WaysValidateUploadedFiles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        [HttpPost("byExtension")]
        public async Task<IActionResult> UploadFileExtension(IFormFile file)
        {
            var validateClass = new FileValidatorBLL();

            if (!validateClass.IsFileCorrect(file))
                return BadRequest("El archivo es incorrecto.");

            string[] allowedExtensions = [".pdf", ".doc", ".docx"];

            if (!validateClass.IsFileExtensionAllowed(file, allowedExtensions))
                return BadRequest("La extension del archivo es incorrecto");

            return Ok();
        }

        [HttpPost("bySize")]
        [RequestSizeLimit(1_000_000)] // Checking for 1 MB
        public async Task<IActionResult> UploadFileBySize(IFormFile file)
        {
            var validateClass = new FileValidatorBLL();

            if (!validateClass.IsFileCorrect(file))
                return BadRequest("El archivo es incorrecto.");

            var size = 1024 * 1024;

            if (!validateClass.IsFileSizeWithinLimit(file, size))
                return BadRequest("El tamaño del archivo excede el tamaño permitido (1 MB)");

            return Ok();
        }

        [HttpPost("byName")]
        public async Task<IActionResult> UploadFileName(IFormFile file)
        {
            var validateClass = new FileValidatorBLL();

            if (!validateClass.IsFileCorrect(file))
                return BadRequest("El archivo es incorrecto.");

            if (validateClass.IsFileWithSameName(file))
                return BadRequest("Documento con mismo nombre, Por favor cargue un documento con diferente nombre.");

            return Ok();
        }

        [HttpPost]
        [FileValidationFilter([".pdf", ".doc", ".docx"], 1024 * 1024)]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            var fileValidator = new FileValidatorBLL();

            await fileValidator.SaveDocument(file);

            return Ok();
        }

    }

}
