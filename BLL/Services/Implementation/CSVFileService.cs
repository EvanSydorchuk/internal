using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
using BLL.Common;
using BLL.Common.Models;
using BLL.Services.Abstract;
using BLL.Helpers.Abstract;
using BLL.Helpers;
using DAL.Entities;
using DAL.UnitOfWork;

namespace BLL.Services.Implementation
{
    public class CSVFileService : BaseService, IFileService
    {
        private readonly IOptions<BasicSettings> _basicSettings;
        private readonly IHostingEnvironment _hostingEnvironment;
        private IFileHelperEngine<Candidate> _fileHelperEngine;

        public CSVFileService(IOptions<BasicSettings> basicSettings, IUnitOfWork unitOfWork, IHostingEnvironment hostingEnvironment) 
            : base(unitOfWork)
        {
            _basicSettings = basicSettings;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task UplodFileAsync(IFormFile file)
        {
            var fileModel = new FileModel
            {
                File = file,
                Name = $"Data-{DateTime.Now.ToShortDateString()}-{Guid.NewGuid()}.csv",
                Path = $"{_basicSettings.Value.DefaultFileFolder}"
            };

            var pathToNewFile = await DirectoryManager.SaveFileInFolder(_hostingEnvironment.WebRootPath, fileModel);

            _fileHelperEngine = new CandidatesCSVFileHelperEngine(Path.Combine(pathToNewFile));

            var data = _fileHelperEngine.LoadData();

            await _unitOfWork.CandidateRepository.AddRangeAsync(data);

            await _unitOfWork.Complete();
        }
    }
}
