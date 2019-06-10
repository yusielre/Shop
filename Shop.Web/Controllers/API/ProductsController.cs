namespace Shop.Web.Controllers.API
{
    using Microsoft.AspNetCore.Mvc;
    using Shop.Web.Data;

    [Route("api/[Controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductRepository productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult GetProduct()
        {
            return Ok(this.productRepository.GetAllWithUsers());
        }
    }
}
