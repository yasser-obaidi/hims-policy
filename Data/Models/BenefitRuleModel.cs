using Policy.Data.Entities;
using Policy.Data.Enums;

namespace Policy.Data.Models
{
    public class BenefitRuleInputModel
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public LimitType LimitType { get; set; }
    }
    public class BenefitRuleOutputModelSimple
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public LimitType LimitType { get; set; }
    }
    public class BenefitRuleOutputModelDetailed  : BenefitOutputModelSimple
    {
        public ICollection<BenefitOutputModelSimple>? Benefits { get; set; }

    }
}
