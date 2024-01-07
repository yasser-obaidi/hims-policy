using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Policy.Data.Entities.Commen;

namespace Policy.Data.Entities
{
    public class BenefitType : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public ICollection<Benefit> Benefits { get; set; }
    }
    public class BenefitTypeConfigurations : IEntityTypeConfiguration<BenefitType>
    {
        public void Configure(EntityTypeBuilder<BenefitType> builder)
        {

            builder.HasKey(BenefitType => BenefitType.Id);

            builder.Property(BenefitType => BenefitType.Name)
                .IsRequired();
            
            builder.Property(BenefitType => BenefitType.Description);

            builder.HasMany(BenefitType => BenefitType.Benefits)
                .WithOne(benefit => benefit.BenefitType)
                .HasForeignKey(benefit => benefit.BenefitTypeId);
        }

    }
}
