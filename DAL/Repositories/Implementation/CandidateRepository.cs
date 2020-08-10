using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;
using DAL.Repositories.Abstract;

namespace DAL.Repositories.Implementation
{
    public class CandidateRepository : BaseRepository<Candidate>, ICandidateRepository
    {
        public CandidateRepository(DbContext context) : base(context) { }

        public override async Task<IndexViewModel<Candidate>> GetAllAsync(string searchFilter, int pageNumber = 1, int pageSize = 20)
        {
            IQueryable<Candidate> filteredItems;
            ICollection<Candidate> result;
            int amountOfEntities = _entities.Count();

            if (!string.IsNullOrWhiteSpace(searchFilter))
            {
                filteredItems = _entities.Include(x => x.Contacts)
                    .AsNoTracking()
                    .AsQueryable()
                    .Where(customer =>
                        customer.Name.Contains(searchFilter) ||
                        customer.Surname.Contains(searchFilter) ||
                        customer.Location.Contains(searchFilter) ||
                        customer.Competence.Contains(searchFilter) || 
                        customer.CompetenceLevel.Contains(searchFilter) || 
                        customer.Contacts.Any(contact => contact.Value.Contains(searchFilter)));

                result = await filteredItems.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
                amountOfEntities = filteredItems.Count();
            }
            else
            {
                result = await _entities.Include(x => x.Contacts).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            }
            
            var pageViewModel = new PageViewModel(amountOfEntities, pageNumber, pageSize);

            var viewModel = new IndexViewModel<Candidate>
            {
                PageViewModel = pageViewModel,
                Data = result
            };

            return viewModel;
        }
    }
}
