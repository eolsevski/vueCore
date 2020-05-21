using Core.Domain.FileService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bundeled.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private IFileService _fileService;

        public FileController(ILogger<UserController> logger, IFileService fileService)
        {

            _logger = logger;
            _fileService = fileService;
        }
        [Authorize]
        [HttpPost("upload")]
        public async Task<IActionResult> OnPostUploadAsync(List<IFormFile> files)
        {
            try
            {
                long size = files.Sum(f => f.Length);
                int i = 0;
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        var filePath = @$"c:/temp/mycatalog/{file.FileName}";
                        Console.WriteLine(filePath);
                        var str = file.OpenReadStream();
                        _fileService.SaveFiles(str);
                        await using var stream = System.IO.File.Create(filePath);
                        await file.CopyToAsync(stream);
                        i++;
                    }
                }

                // Process uploaded files
                // Don't rely on or trust the FileName property without validation.

                return Ok(new { count = files.Count, size });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

    }
}
