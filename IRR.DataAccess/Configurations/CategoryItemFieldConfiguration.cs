using System.Collections.Generic;
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

            builder.OwnsOne(x => x.Type)
                .Property(x => x.Value)
                .HasColumnName("type")
                .IsRequired();

        }
    }
}
