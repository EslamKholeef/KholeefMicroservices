using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Events
{
    public class OrderPlacedEvent
    {
        public int OrderId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public List<OrderItemEvent> Items { get; set; } = new List<OrderItemEvent>();
    }

    public class OrderItemEvent
    {
        public string ProductId { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }
}
