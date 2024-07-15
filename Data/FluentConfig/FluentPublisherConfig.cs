using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ef_core;

public class FluentPublisherConfig : IEntityTypeConfiguration<Fluent_Publisher>
{
    public void Configure(EntityTypeBuilder<Fluent_Publisher> modelBuilder)
    {
        // primary key
        modelBuilder.HasKey(p => p.Publisher_Id);

        // other validations
        modelBuilder.Property(p => p.Name).IsRequired();
    }
}
