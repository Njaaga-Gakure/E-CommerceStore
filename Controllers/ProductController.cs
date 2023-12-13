using AutoMapper;
using E_CommerceStore.Models.DTOS;
using E_CommerceStore.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public async Task<ActionResult<ResponseDTO>> GetAllProducts() {
            var products = await _productService.GetAllProducts();
            _response.Response = products;  
            return Ok(_response);
        }
        
    }
}
