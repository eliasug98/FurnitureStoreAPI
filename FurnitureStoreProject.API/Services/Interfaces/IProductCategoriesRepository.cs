using FurnitureStore.API.Entities;

namespace FurnitureStore.API.Services.Interfaces
{
    public interface IProductCategoriesRepository
    {
        public IEnumerable<ProductCategory> GetAllCategories();
        ProductCategory? GetCategoryById(int idCategory);
        bool SaveChanges();
        ProductCategory? GetCategoryByName(string categoryName);
        void Update(ProductCategory category);
        bool ProductCategoryExists(string categoryName);
        void AddProductCategory(ProductCategory productCategory);
    }
}
