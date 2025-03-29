using Microsoft.EntityFrameworkCore;
using ShopServer.Data;
using ShopShareLibrary.Contracts;
using ShopShareLibrary.Models;
using ShopShareLibrary.Reponses;

namespace ShopServer.Repositories
{
    public class ProductRepository : IProduct
    {
        private readonly AppDBContext _context;
        public ProductRepository(AppDBContext context)
        {
            _context = context;
        }
        public async Task<ServiceRepose> AddProduct(Product model)
        {
            if (model is null)
            {
                return new ServiceRepose("Dữ liệu đang bị rỗng", false);
            }
            var (message, flag) = await CheckName(model.Name!);
            if (flag)
            {
                _context.Add(model);
                await Commit();
                return new ServiceRepose("Thêm sản phẩm thành công", true);
            }
            return new ServiceRepose(message, false);
        }

        public async Task<ServiceRepose> CheckName(string name)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Name.ToLower()!.Equals(name.ToLower()));
            return product is null ? new ServiceRepose(null!, true) : new ServiceRepose("Tên sản phẩm đã tồn tại", false);
        }

        public async Task<List<Product>> GetAllProduct(bool featuredProducts)
        {
            if (featuredProducts)
            {
                return await _context.Products.Where(x => x.Featured).ToListAsync();
            }
            else
            {
                return await _context.Products.ToListAsync();
            }
        }

        private async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}
