using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LumiNYC.Models
{
    public class FakeProductRepository /* : IProductRepository */
    {
        public IQueryable<Product> Products => new List<Product>
        {
            new Product { Name = "Omar\'s Signature Sneakers", Price = 200},
            new Product { Name = "Nike Air Max 200", Price = 200},
            new Product { Name = "Nike React Element 55", Price = 130}
        }.AsQueryable<Product>();
    }
}
