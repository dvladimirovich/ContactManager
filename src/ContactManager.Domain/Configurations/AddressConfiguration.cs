using ContactManager.Domain.Entitites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Domain.Configurations
{
    class AddressConfiguration : EntityTypeConfiguration<Address>
    {
        public override void Map(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address").HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Country).IsRequired().HasMaxLength(255);
            builder.Property(p => p.Region).HasMaxLength(50);
            builder.Property(p => p.City).IsRequired().HasMaxLength(255);
            builder.Property(p => p.Street).IsRequired().HasMaxLength(255);
            builder.Property(p => p.Postal).HasMaxLength(10); // DataType.PostalCode is omitted here

            // Setting AddressId as foreign key and that's all
        }
    }
}
