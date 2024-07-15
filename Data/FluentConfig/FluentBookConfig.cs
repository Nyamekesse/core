using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ef_core;

public class FluentBookConfig : IEntityTypeConfiguration<Fluent_Book>
{
    public void Configure(EntityTypeBuilder<Fluent_Book> modelBuilder)
    {
        // primary key
        modelBuilder.HasKey(b => b.Book_Id);

        // other validations
        modelBuilder.Property(b => b.ISBN).IsRequired();
        modelBuilder.Property(b => b.ISBN).HasMaxLength(50);

        // ignore
        modelBuilder.Ignore(b => b.PriceRange);

        // relations
        modelBuilder
            .HasOne(b => b.Publisher)
            .WithMany(b => b.Books)
            .HasForeignKey(b => b.Publisher_Id);
    }
}
