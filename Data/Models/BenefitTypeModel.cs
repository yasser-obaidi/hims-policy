namespace Policy.Data.Models
{
    public class BenefitTypeInputModel
    {
        public string Name { get; set; }
        public string? Description { get; set; }
    }
    public class BenefitTypeOutputModelSimple
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
    public class BenefitTypeOutputModelDetailed : BenefitOutputModelSimple
    {
        public List<BenefitOutputModelSimple>? Benefits { get; set; }
    }
}
