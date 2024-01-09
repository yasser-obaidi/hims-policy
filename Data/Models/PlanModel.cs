using Policy.Data.Entities;

namespace Policy.Data.Models
{
    public class PlanOutputModelSimple
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal CoverageLimit { get; set; }
        public string? CoverageRegion { get; set; }
        public string CurrencyCode { get; set; }
        public string AlternativeName { get; set; }
        public bool IsActive { get; set; }
        public int? PolicyId { get; set; }

    }
    public class PlanOutputModelDetailed : PlanOutputModelSimple
    {
        public IQueryable<BenefitOutputModelSimple>? Benefits { get; set; }
        public PolicyOutputModelSimple? Policy { get; set; }
    }
    public class PlanInputModel
    {
        public string? Name { get; set; }
        public decimal CoverageLimit { get; set; }
        public string? CoverageRegion { get; set; }
        public string CurrencyCode { get; set; }
        public string AlternativeName { get; set; }
        public bool IsActive { get; set; }
        public int? PolicyId { get; set; }
        public IList<BenefitInputModel>? Benefits { get; set; }
    }
    public class PlanUpdateModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal? CoverageLimit { get; set; }
        public string? CoverageRegion { get; set; }
        public string? CurrencyCode { get; set; }
        public string? AlternativeName { get; set; }
        public bool? IsActive { get; set; }
    }
    public class PlanCopyExistModel
    {
        public int ExistingPlanId { get; set; }
        public string? Name { get; set; }
        public string AlternativeName { get; set; }

    }
    public class InsertBenefitToPlanModel
    {
        public int PlanId { get; set;}
        public List<BenefitInputModel> Benefits { get; set; }
    }
}
