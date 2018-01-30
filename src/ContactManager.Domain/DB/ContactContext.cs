using ContactManager.Domain.Configurations;
using ContactManager.Domain.Entitites;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Domain.DB
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Person> People { get; set; }

        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new AddressConfiguration());
            modelBuilder.AddConfiguration(new PersonConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
