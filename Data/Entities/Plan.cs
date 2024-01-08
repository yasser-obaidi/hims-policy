using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Policy.Data.Entities.Commen;

namespace Policy.Data.Entities
{
    public class Plan : BaseEntity
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public decimal CoverageLimit { get; set; }
        public string? CoverageRegion { get; set; }
        public ICollection<Benefit>? Benefits { get; set; }
        public int? PolicyId { get; set; }
        public Policy? Policy { get; set; }
        public string CurrencyCode  { get; set; }
        public string AlternativeName { get; set; }
        public bool IsActive { get; set; }
    }
    public class PlanConfigurations : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            builder.HasKey(Plan => Plan.Id);

            builder.Property(Plan => Plan.Name)
                .IsRequired();

            builder.Property(Plan => Plan.CoverageLimit)
                .IsRequired()
                .HasDefaultValue(-1);

            builder.Property(Plan => Plan.CoverageRegion);

            builder.HasMany(plan => plan.Benefits)
                .WithOne(Benefit => Benefit.Plan)
                .HasForeignKey(Benefit => Benefit.PlanId);

            builder.HasOne(plan => plan.Policy)
                .WithMany(policy => policy.Plans)
                .HasForeignKey(Plan=>Plan.PolicyId);
        }
    }
}
