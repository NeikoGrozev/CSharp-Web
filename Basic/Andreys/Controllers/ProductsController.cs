namespace Andreys.Controllers
{
    using Services;
    using SIS.HTTP;
    using SIS.MvcFramework;
    using ViewModels.Products;

    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public HttpResponse Add()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(CreateProductFormViewModel input)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            if (input.Name.Length < 4 || input.Name.Length > 20)
            {
                return this.Redirect("Add");
            }

            if(input.Description.Length > 10) 
            {
                return this.Redirect("Add");
            }

            if (input.Price < 0)
            {
                return this.Redirect("Add");
            }

            this.productsService.CreateProduct(input.Name, input.Description, input.ImageUrl, input.Category, input.Gender, input.Price);

            return this.Redirect("/");
        }

        public HttpResponse Details(int id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            var product = this.productsService.GetProduct(id);

            return this.View(product);
        }


        public HttpResponse Delete(int id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            this.productsService.DeleteProduct(id);

            return this.Redirect("/");
        }
    }
}
