using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DAL.Entities;

namespace DAL.Context.Configurations
{
    public class CandidateConfigurations : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(c => c.Surname)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasMany(c => c.Contacts)
                .WithOne(co => co.Candidate)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
