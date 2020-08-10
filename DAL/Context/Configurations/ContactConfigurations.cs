using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DAL.Entities;

namespace DAL.Context.Configurations
{
    public class ContactConfigurations : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(e => e.ContactType)
             .HasMaxLength(50)
             .HasConversion(
                 v => v.ToString(),
                 v => (ContactType)Enum.Parse(typeof(ContactType), v))
                 .IsUnicode(false)
             .HasDefaultValue(ContactType.Unknown);

            builder.Property(c => c.Value)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
