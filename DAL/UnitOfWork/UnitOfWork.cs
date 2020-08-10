using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DAL.Context;
using DAL.Repositories.Abstract;
using DAL.Repositories.Implementation;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Fields

        private readonly DbContext _context;
        private bool _disposed = false;

         private ICandidateRepository _candidateRepository;

        #endregion

        #region Properties

        public ICandidateRepository CandidateRepository
        {
            get
            {
                if (_candidateRepository == null)
                    _candidateRepository = new CandidateRepository(_context);

                return _candidateRepository;
            }
        }

        #endregion Properties

        #region Constructor

        public UnitOfWork(InternalAppContext context)
        {
            _context = context;
        }

        #endregion Constructor

        #region Public Methods

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion Public Methods

        #region Protected Methods

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        #endregion
    }
}

