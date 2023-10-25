using Common.Shared.DTOs;
using System.Collections.Generic;

namespace Order.API.OrderServices
{
    public record OrderCreateRequestDto
    {
        public int UserId { get; set; }
        public List<OrderItemDto> Items { get; set; } = null!;
    }

   
}
