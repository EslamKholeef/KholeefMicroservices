using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public string ProductId { get; set; } = string.Empty; //Eslam: Links to ProductModel.Id from ProductService
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
