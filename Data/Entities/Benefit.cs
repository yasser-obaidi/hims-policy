using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Policy.Data.Entities.Commen;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Policy.Data.Entities
{
    public class Benefit : BaseEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int PlanId { get; set; }
        public Plan Plan {  get; set; }
        public string? Description { get; set; }
        public int BenefitTypeId {  get; set; }
        public BenefitType BenefitType { get; set; }
        public float MemberCoPaymentPercentage { get; set; }
        public int BenefitRuleId { get; set; }
        public BenefitRule BenefitRule { get; set; }



    }
    public class BenefitConfigurations : IEntityTypeConfiguration<Benefit>
    {
        public void Configure(EntityTypeBuilder<Benefit> builder)
        {

            builder.HasKey(Benefit => Benefit.Id);

            builder.HasOne(Benefit => Benefit.Plan)
                .WithMany(Plan=>Plan.Benefits)
                .HasForeignKey(Benefit=>Benefit.PlanId)
                .IsRequired();

            builder.HasOne(Benefit => Benefit.Category)
                .WithMany()
                .HasForeignKey(Benefit=>Benefit.CategoryId)
                .IsRequired();

            builder.Property(Benefit => Benefit.Description);

            builder.HasOne(Benefit => Benefit.BenefitType)
                .WithMany(BenefitType => BenefitType.Benefits)
                .HasForeignKey(Benefit => Benefit.BenefitTypeId)
                .IsRequired();

            builder.Property(Benefit => Benefit.MemberCoPaymentPercentage)
                .IsRequired()
                .HasColumnType("decimal(18,2)")
                .HasPrecision(18, 2)
                .HasDefaultValue(1)
                .HasAnnotation("Range", new[] { 0, 1 });

            builder.HasOne(benefit => benefit.BenefitRule)
                .WithMany(BenefitRule => BenefitRule.Benefits)
                .HasForeignKey(Benefit => Benefit.BenefitRuleId)
                .IsRequired();



        }

    }
}
