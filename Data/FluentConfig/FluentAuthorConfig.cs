using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ef_core;

public class FluentAuthorConfig : IEntityTypeConfiguration<Fluent_Author>
{
    public void Configure(EntityTypeBuilder<Fluent_Author> modelBuilder)
    {
        // primary key
        modelBuilder.HasKey(p => p.Author_Id);

        // other validations
        modelBuilder.Property(p => p.FirstName).IsRequired();
        modelBuilder.Property(p => p.FirstName).HasMaxLength(50);
        modelBuilder.Property(p => p.LastName).IsRequired();

        // ignore
        modelBuilder.Ignore(p => p.FullName);
    }
}
