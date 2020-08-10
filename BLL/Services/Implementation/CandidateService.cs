using System.Threading.Tasks;
using BLL.Services.Abstract;
using DAL.Entities;
using DAL.Repositories;
using DAL.UnitOfWork;

namespace BLL.Services.Implementation
{
    public class CandidateService : BaseService, ICandidateService
    {
        public CandidateService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<IndexViewModel<Candidate>> GetAllAsync(string searchFilter, int pageNumber = 1, int pageSize = 20)
        {
            var candidates = await _unitOfWork.CandidateRepository.GetAllAsync(searchFilter, pageNumber, pageSize);

            return candidates;
        }
    }
}
