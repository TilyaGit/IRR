using IRR.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IRR.DataAccess.Configurations
{
    public class CategoryItemFieldConfiguration : IEntityTypeConfiguration<CategoryField>
    {
        public void Configure(EntityTypeBuilder<CategoryField> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .HasOne(t => t.Type)
                .WithMany();
        }
    }

    public class CategoryFieldTypeConfiguration : IEntityTypeConfiguration<CategoryFieldType>
    {
        public void Configure(EntityTypeBuilder<CategoryFieldType> builder)
        {
            builder.HasKey(s=>s.Value);
            builder
                .ToTable("FieldTypes");

            builder
                .Property(x => x.Name);

            builder
                .HasIndex(u => u.Value)
                .IsUnique();

        }
    }
}
