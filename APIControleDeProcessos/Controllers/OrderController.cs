using APIControleDeProcessos.Interface;
using APIControleDeProcessos.Models;
using APIControleDeProcessos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIControleDeProcessos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderInterface _orderInterface;

        public OrderController(IOrderInterface orderInterface)
        {
            _orderInterface = orderInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<OrderModel>>>> GetAllOrders()
        {
            var orders = await _orderInterface.GetAllOrders();
            return Ok(orders);
        }

        [HttpGet("ByNumber")]
        public async Task<ActionResult<ServiceResponse<OrderModel>>> GetOrderByNumber(int number)
        {
            var order = await _orderInterface.GetOrderByNumber(number);
            return Ok(order);
        }

        [HttpGet("ByProduct")]
        public async Task<ActionResult<ServiceResponse<OrderModel>>> GetOrderByProduct(string product)
        {
            var order = await _orderInterface.GetOrderByName(product);
            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<OrderModel>>>> CreateOrder(OrderModel newOrder)
        {
            var order = await _orderInterface.CreateOrder(newOrder);
            return Ok(order);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<OrderModel>>>> UpdateModel(OrderModel upOrder)
        {
            var order = await _orderInterface.UpdateOrder(upOrder);
            return Ok(order);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<OrderModel>>>> DeleteOrder(int id)
        {
            var order = await _orderInterface.DeleteOrder(id);
            return Ok(order);
        }
    }
}
