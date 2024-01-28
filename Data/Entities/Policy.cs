using Policy.Data.Entities.Commen;

namespace Policy.Data.Entities
{
    public class Policy : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public ICollection<Plan> Plans { get; set; }
    }
}
