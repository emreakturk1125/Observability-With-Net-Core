using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.API.OrderServices;
using System;
using System.Threading.Tasks;

namespace Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// Exception örneği
        /// </summary>
        /// <returns></returns>
        [HttpGet]  
        public IActionResult Create()
        {
            var a = 10;
            var b = 0;
            var c = a / b;
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create1(OrderCreateRequestDto request)
        {
            var result = await _orderService.CreateAsync(request);

            return new ObjectResult(result) { StatusCode = result.StatusCode }; 
        }
    }
}
