using AutoMapper;
using E_CommerceStore.Models;
using E_CommerceStore.Models.DTOS;
using E_CommerceStore.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace E_CommerceStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOrder _orderService;
        private readonly ResponseDTO _response;

        public OrderController(IMapper mapper, IOrder orderService)
        {
            _mapper = mapper;
            _orderService = orderService;
            _response = new ResponseDTO();
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDTO>> CreateOrder(AddOrderDTO order)
        {
            var newOrder = _mapper.Map<Order>(order);
            var isSuccess = await _orderService.CreateOrder(newOrder);
            if (isSuccess) 
            {
                _response.StatusCode = HttpStatusCode.Created;
                _response.Response = "Order Created Successfully :)";
                return Ok(_response);
            }
            _response.StatusCode = HttpStatusCode.InternalServerError;
            _response.Message = "Something Went Wrong. Try Again Later :(";
            return StatusCode(500, _response);
        }

        [HttpGet]
        public async Task<ActionResult<ResponseDTO>> GetAllOrders() {
            var products = await _orderService.GetAllOrders();
            _response.Response = products;
            return Ok(_response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDTO>> GetSingleOrder(Guid id)
        {
            var order = await _orderService.GetSingleOrder(id);
            if (order == null)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.Message = $"Product with id `{id}` could not be found";
                return NotFound(_response);
            }
            _response.Response = order;
            return Ok(_response);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<ResponseDTO>> UpdateOrder(Guid id, AddOrderDTO order)
        { 
            bool isSuccess = await _orderService.UpdateOrder(id, order);
            if (isSuccess)
            {
                _response.Response = "Order Updated Successfully :)";
                return Ok(_response);
            }
            _response.StatusCode = HttpStatusCode.NotFound;
            _response.Message = $"Product with id `{id}` could not be found";
            return NotFound(_response);


        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseDTO>> DeleteOrder(Guid id)
        {
            bool isSuccess = await _orderService.DeleteOrder(id);
            if (isSuccess)
            {
                _response.Response = "Order Deleted Successfully :)";
                return Ok(_response);
            }
            _response.StatusCode = HttpStatusCode.NotFound;
            _response.Message = "Order to Delete Could not Be Found";
            return NotFound(_response);
        }
    }
}
