namespace Andreys.Services
{
    using Andreys.Models;
    using Andreys.ViewModels.Products;
    using Data;
    using Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductsService : IProductsService
    {
        private readonly AndreysDbContext db;

        public ProductsService(AndreysDbContext db)
        {
            this.db = db;
        }

        public void CreateProduct(string name, string description, string imageUrl, string category, string gender, decimal price)
        {
            var currentCategory = Enum.Parse<CategoryEnums>(category);
            var currentGender = Enum.Parse<GenderEnums>(gender);

            var product = new Product
            {
                Name = name,
                Description = description,
                ImageUrl = imageUrl,
                Category = currentCategory,
                Gender = currentGender,
                Price = price,
            };

            this.db.Products.Add(product);
            this.db.SaveChanges();
        }

        public IEnumerable<Product> GetAllProduct()
        {
            var products = this.db.Products.Select(x => new Product
            { 
                Id = x.Id,
                Name = x.Name,
                ImageUrl = x.ImageUrl,
                Price = x.Price,
            }).ToList();

            return products;
        }

        public Product GetProduct(int id)
        {
            var product = this.db.Products.FirstOrDefault(x => x.Id == id);

            return product;
        }
        
        public void DeleteProduct(int id)
        {
            var product = this.db.Products.FirstOrDefault(x => x.Id == id);

            this.db.Products.Remove(product);
            this.db.SaveChanges();
        }

    }
}
