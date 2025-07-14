using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public List<OrderItemDto> Items { get; set; } = new List<OrderItemDto>();
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
