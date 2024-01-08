using Policy.Data.Entities;

namespace Policy.Data.Models
{
    public class BenefitOutputModelSimple
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int PlanId { get; set; }
        public string? Description { get; set; }
        public int BenefitTypeId { get; set; }
        public float MemberCoPaymentPercentage { get; set; }
        public int BenefitRuleId { get; set; }
    }
    public class BenefitOutputModelDetailed  : BenefitOutputModelSimple
    {
        public Category Category { get; set; }
        public PlanOutputModelSimple Plan { get; set; }
        public BenefitType BenefitType { get; set; }
        public BenefitRule BenefitRule { get; set; }
    }
    public class BenefitUpdateModel
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string? Description { get; set; }
        public int BenefitTypeId { get; set; }
        public float MemberCoPaymentPercentage { get; set; }
        public int BenefitRuleId { get; set; }
    }
    public class BenefitInputModel
    {
        public int CategoryId { get; set; }
        public string? Description { get; set; }
        public int BenefitTypeId { get; set; }
        public float MemberCoPaymentPercentage { get; set; }
        public int BenefitRuleId { get; set; }
    }
}
