using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Policy.Data.Entities.Commen;

namespace Policy.Data.Entities
{
    public class Category : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? MainCategoryId { get; set; }
        public Category? MainCategory { get; set; }
        public IQueryable<Category>? SubCategories { get; set; }

    }
    public class CategoryConfigurations : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {

            builder.HasKey(Category => Category.Id);

            builder.Property(Category => Category.Name)
                .IsRequired();

            builder.Property(Category => Category.Description);

            builder.HasOne(Category => Category.MainCategory)
                .WithMany(SubCategory => SubCategory.SubCategories)
                .HasForeignKey(SubCategory=>SubCategory.MainCategoryId);

            builder.HasMany(Category => Category.SubCategories)
                .WithOne(MainCategory=>MainCategory.MainCategory)
                .HasForeignKey(Category=>Category.MainCategoryId);

            
             
        }

    }
}
