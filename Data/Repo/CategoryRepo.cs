using Policy.Data.Entities;

namespace Policy.Data.Repo
{
    public interface ICategoryRepo
    {
        void Add(Category category);
    }
    public class CategoryRepo : ICategoryRepo
    {
        private readonly Context _db;
        public CategoryRepo( Context context) 
        {
            _db = context;
        }

        public void Add(Category category)
        {
            _db.Categories.Add(category);
        }
    }
}
