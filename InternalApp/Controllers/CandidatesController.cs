using System.Threading.Tasks;
using BLL.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InternalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly ICandidateService _candidateService;
        private readonly ILogger<CandidatesController> _logger;

        public CandidatesController(ICandidateService candidateService, ILogger<CandidatesController> logger)
        {
            _candidateService = candidateService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery]string searchFilter = "", [FromQuery]int pageNumber = 1, [FromQuery]int pageSize = 20)
        {           
            var candidates = await _candidateService.GetAllAsync(searchFilter, pageNumber, pageSize);

            if (candidates.Data.Count == 0)
            {
                return NoContent();
            }

            return Ok(candidates);

        }
    }
}