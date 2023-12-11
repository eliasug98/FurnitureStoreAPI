using FurnitureStore.API.DBContext;
using FurnitureStore.API.Entities;
using FurnitureStore.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace FurnitureStore.API.Services.Implementations
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly FurnitureStoreContext _context;

        public ProductsRepository(FurnitureStoreContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetProducts() // todos los productos
        {
            return _context.Products;
        }

        public Product? GetProductById(int idProduct) // un producto especifico por id
        {
            return _context.Products.Where(p => p.Id == idProduct).FirstOrDefault();
        }

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
        }

        public void DeleteProduct(Product productToDelete)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == productToDelete.Id);
            if (product != null)
            {
                _context.Products.Remove(productToDelete);
            }

        }

        public bool ProductExists(string productName)
        {
            return _context.Products.Where(o => o.Name == productName).Any();
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
        {
            return _context.Products.Where(p => p.CategoryId == categoryId);
        }
    }
}
