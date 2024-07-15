using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ef_core;

public class FluentBookAuthorMap : IEntityTypeConfiguration<Fluent_BookAuthorMap>
{
    public void Configure(EntityTypeBuilder<Fluent_BookAuthorMap> modelBuilder)
    {
        // primary key
        modelBuilder.HasKey(p => new { p.Author_Id, p.Book_Id });

        // relations
        modelBuilder
            .HasOne(p => p.Book)
            .WithMany(p => p.BookAuthorMap)
            .HasForeignKey(p => p.Book_Id);

        modelBuilder
            .HasOne(p => p.Author)
            .WithMany(p => p.BookAuthorMap)
            .HasForeignKey(p => p.Author_Id);
    }
}
