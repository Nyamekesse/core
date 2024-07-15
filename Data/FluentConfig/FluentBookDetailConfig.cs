using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ef_core;

public class FluentBookDetailConfig : IEntityTypeConfiguration<Fluent_BookDetail>
{
    public void Configure(EntityTypeBuilder<Fluent_BookDetail> modelBuilder)
    {
        // name of table
        modelBuilder.ToTable("Fluent_BookDetails");

        // name of columns
        modelBuilder.Property(p => p.NumberOfChapters).HasColumnName("NoOfChapters");

        // primary key
        modelBuilder.HasKey(p => p.BookDetail_Id);

        // other validations
        modelBuilder.Property(p => p.NumberOfChapters).IsRequired();

        // relations
        modelBuilder
            .HasOne(b => b.Book)
            .WithOne(b => b.BookDetail)
            .HasForeignKey<Fluent_BookDetail>(b => b.Book_Id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
