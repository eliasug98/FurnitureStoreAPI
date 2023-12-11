using FurnitureStore.API.Entities;

namespace FurnitureStore.API.Services.Interfaces
{
    public interface IProductsRepository
    {
        public IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetProductsByCategoryId(int categoryId);
        void DeleteProduct(Product productToDelete);
        void Update(Product product);
        Product? GetProductById(int idProduct);
        void AddProduct(Product product);
        bool SaveChanges();
        bool ProductExists(string productName);
    }
}
