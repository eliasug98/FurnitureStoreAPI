using FurnitureStore.API.DBContext;
using FurnitureStore.API.Entities;
using FurnitureStore.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace FurnitureStore.API.Services.Implementations
{
    public class ProductCategoriesRepository : IProductCategoriesRepository
    {
        private readonly FurnitureStoreContext _context;
        public ProductCategoriesRepository(FurnitureStoreContext context)
        {
            _context = context;
        }
        public IEnumerable<ProductCategory> GetAllCategories()
        {
            return _context.ProductCategories;
        }

        public ProductCategory? GetCategoryById(int idCategory)
        {
            return _context.ProductCategories.Where(pc => pc.Id == idCategory).FirstOrDefault();
        }

        public ProductCategory? GetCategoryByName(string categoryName)
        {
            return _context.ProductCategories.Where(pc => pc.Name == categoryName).FirstOrDefault();
        }

        public void Update(ProductCategory category)
        {
            _context.ProductCategories.Update(category);
        }
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public bool ProductCategoryExists(string categoryName)
        {
            return _context.ProductCategories.Where(o => o.Name == categoryName).Any();
        }

        public void AddProductCategory(ProductCategory productCategory)
        {
            _context.ProductCategories.Add(productCategory);
        }
    }
}
