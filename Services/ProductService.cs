using System.Collections.Generic;
using AppMvc.Net.Models;

namespace AppMvc.Net.Service
{
    public class ProductService : List<ProductModel>
    {
        public ProductService()
        {
            this.AddRange(new ProductModel[] {
                new ProductModel() {Id = 1, Name = "Iphone X", Price = 1000},
                new ProductModel() {Id = 2, Name = "Samsung Abc", Price = 500},
                new ProductModel() {Id = 3, Name = "Sony XYZ", Price = 800},
                new ProductModel() {Id = 4, Name = "Nokia BCD", Price = 100}
            });
        }
    }
}