namespace Andreys.Services
{
    using Models;
    using System.Collections.Generic;

    public interface IProductsService
    {
        void CreateProduct(string name,
            string description,
            string imageUrl,
            string category,
            string gender,
            decimal price);

        IEnumerable<Product> GetAllProduct();

        Product GetProduct(int id);

        void DeleteProduct(int id);
    }
}
