using ShopShareLibrary.Models;
using ShopShareLibrary.Reponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopShareLibrary.Contracts
{
    public interface IProduct
    {
        Task<ServiceRepose> AddProduct(Product model);
        Task<List<Product>> GetAllProduct(bool featuredProducts);
    }
}
