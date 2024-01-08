namespace Policy.Data.Models
{
    public class PolicyOutputModelSimple
    {
        public int Id { get; set; }
        public string Number { get; set; }
    }
    public class PolicyOutputModelDetailed : PolicyOutputModelSimple
    {
        public List<PlanOutputModelSimple> Plans { get;}
    }
}
