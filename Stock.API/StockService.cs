using Common.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Threading.Tasks;

namespace Stock.API
{
    public class StockService
    {
        public Dictionary<int,int> GetProductStockList()
        {
            Dictionary<int, int> procductStockList = new();
            procductStockList.Add(1,10);
            procductStockList.Add(2,20);
            procductStockList.Add(3,30);

            return procductStockList;
        }

        public ResponseDto<StockCheckAndPaymentProcessResponseDto> CheckAndPaymentProcess(StockCheckAndPaymentProcessRequestDto request)
        {
            var productStockList = GetProductStockList();
            var stockStatus = new List<(int productId,bool hasStockExist)>();

            foreach (var orderItem in request.OrderItems)
            {
                var hasExitsStock = productStockList.Any(x => x.Key == orderItem.ProductId && x.Value == orderItem.Count); 
                stockStatus.Add((orderItem.ProductId, hasExitsStock)); 
            }

            if (stockStatus.Any(x => x.hasStockExist == false))
            {
                return ResponseDto<StockCheckAndPaymentProcessResponseDto>.Fail(HttpStatusCode.BadRequest.GetHashCode(),"stock yetersiz"); 
            }

            return ResponseDto<StockCheckAndPaymentProcessResponseDto>.Success(HttpStatusCode.OK.GetHashCode(), new StockCheckAndPaymentProcessResponseDto() { Description = "Stock ayrıldı"});
        }
    }
}
