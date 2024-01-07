using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Policy.Data.Entities.Commen;
using Policy.Data.Enums;

namespace Policy.Data.Entities
{
    public class BenefitRule : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public LimitType LimitType { get; set; }
        public ICollection<Benefit> Benefits { get; set; }

    }
    public class BenefitRuleConfigurations : IEntityTypeConfiguration<BenefitRule>
    {
        public void Configure(EntityTypeBuilder<BenefitRule> builder)
        {

            builder.HasKey(BenefitRule => BenefitRule.Id);

            builder.Property(BenefitRule => BenefitRule.Name)
                .IsRequired();

            builder.Property(BenefitRule => BenefitRule.Description);

            builder.Property(BenefitRule => BenefitRule.LimitType)
                .IsRequired();

            builder.HasMany(BenefitRule => BenefitRule.Benefits)
                .WithOne(benefit => benefit.BenefitRule)
                .HasForeignKey(benefit => benefit.BenefitRuleId);



        }

    }
}
