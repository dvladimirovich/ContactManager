using ContactManager.Domain.Entitites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ContactManager.Domain.Configurations
{
    class PersonConfiguration : EntityTypeConfiguration<Person>
    {
        public override void Map(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("People").HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(255);
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(255);
            builder.Property(p => p.Birth).IsRequired();                                       // DataType.Date is omitted
            builder.Property(p => p.Gender).IsRequired().HasDefaultValue(Gender.NotMentioned); // EnumDataType(typeof(Gender)) is omitted
            builder.Property(p => p.PersonNumber).IsRequired().HasMaxLength(13);               // StringLength is omitted
            builder.Property(p => p.Email).IsRequired().HasMaxLength(255);                     // DataType.EmailAddress is omitted
            builder.Property(p => p.Phone).HasMaxLength(100);                                  // DataType.PhoneNumber and RegularExpression is omitted

            // Setting AddressId as foreign key
            builder.HasOne(p => p.Address)
                   .WithMany(p => p.People)
                   .HasForeignKey(p => p.AddressId)
                   .HasConstraintName("FK_Address_People")
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
