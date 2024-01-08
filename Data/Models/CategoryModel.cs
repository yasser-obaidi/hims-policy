namespace Policy.Data.Models
{
    public class CategoryInputModel
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? MainCategoryId { get; set; }
    }
    public class CategoryOutputModelSimple
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? MainCategoryId { get; set; }
    }
    public class CategoryOutputModelDetailed : CategoryOutputModelSimple
    {
        public CategoryOutputModelSimple? MainCategory {  get; set; }
        public List<CategoryOutputModelSimple>? SubCategories { get; set; }
    }
}
