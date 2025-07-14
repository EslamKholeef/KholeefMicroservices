using MediatR;
using Order.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Commands.CreateCommand
{
    public class CreateOrderCommand:IRequest<OrderDto>
    {
        public string UserId { get; set; } = string.Empty;
        public List<OrderItemRequest> Items { get; set; } = new List<OrderItemRequest>();
    }

    public class OrderItemRequest
    {
        public string ProductId { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
