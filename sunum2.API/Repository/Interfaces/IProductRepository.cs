using sunum2.API.Models;
using System.Collections;

namespace sunum2.API.Repository.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductByID(int ID);
        Task<Product> CreateProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        bool DeleteProduct(int ID);
    }
}
