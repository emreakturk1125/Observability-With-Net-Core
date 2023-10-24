
using OpenTelemetry.Shared;
using Order.API.Models;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Order.API.OrderServices
{
    public class OrderService
    {
        private readonly AppDbContext _context;
        //private readonly StockService _stockService;
        //private readonly RedisService _redisService;
        //private readonly IPublishEndpoint _publishEndpoint;
        //private readonly ILogger<OrderService> _logger;
        public OrderService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<OrderCreateResponseDto> CreateAsync(OrderCreateRequestDto request)
        {
            Activity.Current?.SetTag("Asp.Net Core(instrumentation) Tag1", "Asp.Net Core(instrumentation) Tag1 Value");

            using (var redisActivity = ActivitySourceProvider.Source.StartActivity("RedisStringSetGet"))
            {
                redisActivity?.AddEvent(new("Sipariş süreci başladı"));

                var newOrder = new Order()
                {
                    Created = DateTime.Now,
                    OrderCode = Guid.NewGuid().ToString(),
                    Status = OrderStatus.Success,
                    UserId = request.UserId,
                    Items = request.Items.Select(x => new OrderItem()
                    {
                        Count = x.Count,
                        ProductId = x.ProductId,
                        UnitPrice = x.UnitPrice
                    }).ToList()
                };

                _context.Orders.Add(newOrder);
                await _context.SaveChangesAsync();

                redisActivity.SetTag("order user Id", request.UserId);

                redisActivity?.AddEvent(new("Sipariş süreci tamamlandı"));

                return new OrderCreateResponseDto() { Id = newOrder.Id };

            }



            //using (var redisActivity = ActivitySourceProvider.Source.StartActivity("RedisStringSetGet"))
            //{
            //    // redis için örnek kod
            //    await _redisService.GetDb(0).StringSetAsync("userId", request.UserId);

            //    redisActivity.SetTag("userId", request.UserId);

            //    var redisUserId = _redisService.GetDb(0).StringGetAsync("UserId");
            //}

            //    Activity.Current?.SetTag("Asp.Net Core(instrumentation) tag1", "Asp.Net Core(instrumentation) tag value");
            //    using var activity = ActivitySourceProvider.Source.StartActivity();
            //    activity?.AddEvent(new("Sipariş süreci başladı."));

            //    activity.SetBaggage("userId", request.UserId.ToString());



            //    };


            //    _logger.LogInformation("Sipariş veritabanına kaydedildi.{@userId}",request.UserId);


            //    StockCheckAndPaymentProcessRequestDto stockRequest = new();

            //    stockRequest.OrderCode = newOrder.OrderCode;
            //    stockRequest.OrderItems = request.Items;

            //    var (isSuccess, failMessage) = await _stockService.CheckStockAndPaymentStartAsync(stockRequest);


            //    if(!isSuccess)
            //    {
            //        return ResponseDto<OrderCreateResponseDto>.Fail(HttpStatusCode.InternalServerError.GetHashCode(), failMessage!);

            //    }

            //    activity?.AddEvent(new("Sipariş süreci tamamlandı."));

            //    return  ResponseDto<OrderCreateResponseDto>.Success(HttpStatusCode.OK.GetHashCode(), new OrderCreateResponseDto() { Id = newOrder.Id });

        }
    }
}
