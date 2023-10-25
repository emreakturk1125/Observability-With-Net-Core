using Common.Shared.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Stock.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class StockController : ControllerBase
    {
        private readonly StockService _stockService;

        public StockController(StockService stockService)
        {
            _stockService = stockService;
        }

        [HttpPost]
        public IActionResult CheckAndPaymentStart(StockCheckAndPaymentProcessRequestDto request)
        {
            var result =  _stockService.CheckAndPaymentProcess(request);

            return new ObjectResult(result) { StatusCode = result.StatusCode };
        }
    }
}
