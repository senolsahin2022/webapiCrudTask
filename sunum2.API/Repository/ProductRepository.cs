using Microsoft.EntityFrameworkCore;
using sunum2.API.Models;
using sunum2.API.Repository.Interfaces;

namespace sunum2.API.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly SunumdbContext _sunumdbContext;

        public ProductRepository(SunumdbContext sunumdbContext)
        {
            _sunumdbContext = sunumdbContext;
        }

        public async Task<Product> CreateProduct(Product product)
        {
            _sunumdbContext.Products.Add(product);
            await _sunumdbContext.SaveChangesAsync();
            return product;
        }

        public bool DeleteProduct(int ID)
        {
            bool result = false;
            var product = _sunumdbContext.Products.Find(ID);
            if (product != null)
            {
                _sunumdbContext.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _sunumdbContext.SaveChanges();
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        public async Task<Product> GetProductByID(int ID)
        {
            return await _sunumdbContext.Products.FindAsync(ID);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _sunumdbContext.Products.ToListAsync();
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            _sunumdbContext.Entry(product).State = EntityState.Modified; 
            await _sunumdbContext.SaveChangesAsync();
            return product;
        }
    }
}
