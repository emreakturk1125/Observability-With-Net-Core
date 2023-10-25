using Common.Shared.DTOs;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Order.API.StockServices
{
    public class StockService
    {
        private readonly HttpClient _client;
        public StockService(HttpClient client)
        {
            _client = client;
        }

        public async Task<(bool isSuccess, string? failMessage)> CheckStockAndPaymentStart(StockCheckAndPaymentProcessRequestDto request)
        {
            var response = await _client.PostAsJsonAsync<StockCheckAndPaymentProcessRequestDto>("api/Stock/CheckAndPaymentStart",request);
            var responseContent = await response.Content.ReadFromJsonAsync<ResponseDto<StockCheckAndPaymentProcessResponseDto>>();  
            return response.IsSuccessStatusCode ? (true,null) : (false, responseContent!.Errors!.First());
        }
    }
}
