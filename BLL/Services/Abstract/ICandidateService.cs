using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Abstract
{
    public interface ICandidateService
    {
        Task<IndexViewModel<Candidate>> GetAllAsync(string searchFilter, int pageNumber = 1, int pageSize = 20);
    }
}
