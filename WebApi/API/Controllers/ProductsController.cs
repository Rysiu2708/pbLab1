using BLL.DTOModels;
using BLL.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<ProductResponseDTO> Get(string? sortBy = "",
            string? filterByName = null,
            string? filterByGroupName = null,
            int? filterByGroupId = null,
            bool includeInactive = false)
        {
            return _productService.GetProducts(sortBy, filterByName, filterByGroupName, filterByGroupId, includeInactive);

        }



        // POST api/<ValuesController>
        [HttpPost]
        [Route("AddProduct")]
        public void Post([FromBody] ProductRequestDTO input)
        {
            _productService.AddProduct(input);
            return;

        }

        [HttpPatch]
        [Route("DeactivateProduct")]
        public void DeactivateProduct(int productid)
        {
            _productService.DeactivateProduct(productid);

            return ;
        }

        [HttpDelete]
        [Route("DeleteProduct")]
        public void Delete(int id)
        {
            _productService.DeleteProduct(id);
            return;
        }

        [HttpPatch]
        [Route("ActivateProduct")]
        public void ActivateProduct(int productid)
        {
            _productService.ActivateProduct(productid);

            return;
        }


    }
}
