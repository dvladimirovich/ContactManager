using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContactManager.Domain.Configurations
{
    internal abstract class EntityTypeConfiguration<TEntity> 
        where TEntity : class
    {
        public abstract void Map(EntityTypeBuilder<TEntity> builder);
    }

    internal static class ModelBuilderExtensions
    {
        public static void AddConfiguration<TEntity>(this ModelBuilder modelBuilder, EntityTypeConfiguration<TEntity> configuration) 
            where TEntity : class
        {
            configuration.Map(modelBuilder.Entity<TEntity>());
        }
    }
}