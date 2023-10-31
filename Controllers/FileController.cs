using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace CityInfo.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/files")]
    public class FileController : ControllerBase
    {
        private readonly FileExtensionContentTypeProvider _fileExtensionContentTypeProvider;

        public FileController(FileExtensionContentTypeProvider fileExtProvider)
        {
            _fileExtensionContentTypeProvider = fileExtProvider ?? throw new System.ArgumentNullException(nameof(fileExtProvider));
        }

        
        [HttpGet("{fileId}")]
        public ActionResult GetFile(string fileId)
        {
            string pathToFile = "";
            if (!System.IO.File.Exists(pathToFile))
            {
                return NotFound();
            }

            if (!_fileExtensionContentTypeProvider.TryGetContentType(pathToFile, out var contentType))
            {
                contentType = "application/octect-stream";
            }

            byte[] bytes = System.IO.File.ReadAllBytes(pathToFile);
            return File(bytes, contentType, Path.GetFileName(pathToFile));
        }
    }
}

