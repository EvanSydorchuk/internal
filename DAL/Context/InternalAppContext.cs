using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Extensions;
using DAL.Entities;

namespace DAL.Context
{
    public class InternalAppContext : DbContext
    {
       public DbSet<Candidate> Candidates { get; set; }
        public InternalAppContext()
        {

        }
        public InternalAppContext(DbContextOptions<InternalAppContext> options) : base(options)
        {
            EntityFrameworkManager.ContextFactory = context => new InternalAppContext();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assemblyWithConfigurations = GetType().Assembly;

            modelBuilder.ApplyConfigurationsFromAssembly(assemblyWithConfigurations);

            base.OnModelCreating(modelBuilder);
        }
    }
}
