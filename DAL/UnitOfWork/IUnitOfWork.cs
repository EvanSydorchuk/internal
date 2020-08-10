using System;
using System.Threading.Tasks;
using DAL.Repositories.Abstract;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ICandidateRepository CandidateRepository { get; }

        Task<int> Complete();
    }
}