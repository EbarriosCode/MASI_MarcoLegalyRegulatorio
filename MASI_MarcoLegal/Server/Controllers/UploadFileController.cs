using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MASI_MarcoLegal.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadFileController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;

        public UploadFileController(IWebHostEnvironment environment)
        {
            this._environment = environment;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] IFormFile image)
        {
            if (image == null || image.Length == 0)
                return BadRequest("Upload a file");

            string fileName = image.FileName;
            string extension = Path.GetExtension(fileName);

            string[] allowedExtensions = { ".jpg", ".png", ".bmp", ".pdf", ".jpeg" };

            if (!allowedExtensions.Contains(extension))
                return BadRequest("Archivo inválido");

            string newFileName = $"{Guid.NewGuid()}{extension}";
            string filePath = Path.Combine(_environment.ContentRootPath, "UploadFiles", newFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                await image.CopyToAsync(fileStream);
            }

            return Ok($"UploadFiles/{newFileName}");
        }

        [HttpPost("Upload")]      
        public async Task<string> Upload()
        {
            string pathFile = string.Empty;

            if (HttpContext.Request.Form.Files.Any())
            {
                foreach (var file in HttpContext.Request.Form.Files)
                {
                    var path = Path.Combine(this._environment.ContentRootPath, "UploadFiles", file.FileName);
                    pathFile = Path.Combine("UploadFiles", file.FileName);

                    using(var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
            }
            return pathFile;
        }
    }
}
