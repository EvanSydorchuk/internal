using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Common.Models;
using BLL.Services.Abstract;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InternalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CSVFilesController : ControllerBase
    {
        private readonly IFileService _fileServise;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly ILogger<CSVFilesController> _logger;

        public CSVFilesController(IFileService fileService, IHostingEnvironment hostingEnvironment, ILogger<CSVFilesController> logger)
        {
            _fileServise = fileService;
            _hostingEnvironment = hostingEnvironment;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromForm]IFormFile file)
        {
            if (file.Length == 0)
            {
                return BadRequest();
            }

            await _fileServise.UplodFileAsync(file);

            return Ok();
        }
    }
}