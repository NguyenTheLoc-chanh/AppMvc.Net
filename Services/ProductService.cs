using System.Collections.Generic;
using AppMvc.Net.Models;

namespace  AppMvc.Services
{
    public class ProductService : List<ProductModel>
    {
        public ProductService()
        {
            this.AddRange(new ProductModel[] { 
                new ProductModel { Id = 1, Name = "Product 1", Price = 100 },
                new ProductModel { Id = 2, Name = "Product 2", Price = 200 },
                new ProductModel { Id = 3, Name = "Product 3", Price = 300 }
            });
        }
    }
}