using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Entities
{
    public class OrderModel
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty; //Eslam: Links to AppUser.Id from IdentityService
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = "Pending"; //Eslam: e.g., Pending, Completed, Cancelled
    }

}
