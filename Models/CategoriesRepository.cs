namespace firstaspapp.Models
{
    public class CategoriesRepository
    {
        private static List<Category> _categories = new List<Category>()
        {
            new Category { Id = 1, Name = "Beverage", Description = "Beverage"},
            new Category { Id = 2, Name = "Bakery", Description = "Bakery"},
            new Category { Id = 3, Name = "Meat", Description = "Meat"},
        };

        public static void AddCategory(Category category)
        {
            var maxId = _categories.Max(c => c.Id);
            category.Id = maxId + 1;
            _categories.Add(category);
        }

        public static List<Category> GetCategories() => _categories;

        public static Category? GetCategoryById(int Id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == Id);

            if (category != null)
            {
                return new Category
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description,
                };
            }
            return null;
        }

        public static void UpdateCategory(int Id, Category category)
        {
            if (Id != category.Id) return;

            var CategoryToUpdate = _categories.FirstOrDefault(c => c.Id == Id);

            if (CategoryToUpdate != null)
            { 
                CategoryToUpdate.Name = category.Name;
                CategoryToUpdate.Description = category.Description;
            }
        }

        public static void DeleteCategory(int Id)
        {
            var CategoryToDelete = _categories.FirstOrDefault(c => c.Id == Id);
            if (CategoryToDelete != null)
            {
                _categories.Remove(CategoryToDelete);
            }
        }
    }
}
