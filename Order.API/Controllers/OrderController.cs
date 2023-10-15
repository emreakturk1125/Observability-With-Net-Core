using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

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

        [HttpGet]
        public IActionResult Create1()
        {
            var a = 10;
            var b = 0;
            var c = a / b;
            return Ok();
        }
    }
}
