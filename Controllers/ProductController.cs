using AutoMapper;
using E_CommerceStore.Models.DTOS;
using E_CommerceStore.Services.IServices;
using E_CommerceStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace E_CommerceStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProduct _productService;
        private readonly ResponseDTO _response;

        public ProductController(IMapper mapper, IProduct productService)
        {
            _mapper = mapper;   
            _productService = productService;
            _response = new ResponseDTO();
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDTO>> AddProduct(AddProductDTO product)
        {
            if (product == null || string.IsNullOrWhiteSpace(product.Name) || string.IsNullOrWhiteSpace(product.Description))
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Message = "Please fill in all the fields";
                _response.Response = "Product Creation Failed";
                return BadRequest(_response);
            }
            var newProduct = _mapper.Map<Product>(product);
            bool isSuccess = await _productService.CreateProduct(newProduct);
            if (isSuccess) 
            {
                _response.StatusCode = HttpStatusCode.Created;
                _response.Response = "Product Created Successfully :)";
                return Ok(_response);
            }
            _response.StatusCode = HttpStatusCode.InternalServerError;
            _response.Message = "Something Went Wrong. Try Again Later :(";
            return StatusCode(500, _response);

        }

        [HttpGet]
        public async Task<ActionResult<ResponseDTO>> GetAllProducts() {
            var products = await _productService.GetAllProducts();
            _response.Response = products;  
            return Ok(_response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDTO>> GetSingleProduct(Guid id) {
            var product = await _productService.GetProductById(id);
            if (product == null)
            { 
                _response.StatusCode=HttpStatusCode.NotFound;
                _response.Message = $"Product with id `{id}` does not exist";
                return NotFound(_response);
            }
            _response.Response = product;
            return Ok(_response);   
        
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<ResponseDTO>> UpdateProduct(Guid id, AddProductDTO product)
        {
            if (product == null || string.IsNullOrWhiteSpace(product.Name) || string.IsNullOrWhiteSpace(product.Description))
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Message = "Please fill in all the fields";
                _response.Response = "Product Update Failed";
                return BadRequest(_response);
            }
            bool isSuccess = await _productService.UpdateProduct(id, product);
            if (isSuccess) 
            {
                _response.Response = "Product Updated Successfully";
                return Ok(_response);
            }

            _response.StatusCode = HttpStatusCode.NotFound;
            _response.Message = $"Product with id `{id}` does not exist";
            return NotFound(_response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseDTO>> DeleteProduct(Guid id)
        {
            bool isSuccess = await _productService.DeleteProduct(id);
            if (isSuccess)
            {
                _response.Response = "Product Deleted Successfully";
                return Ok(_response);
            }

            _response.StatusCode = HttpStatusCode.NotFound;
            _response.Message = $"Product with id `{id}` does not exist";
            return NotFound(_response);
        }

        
    }
}
