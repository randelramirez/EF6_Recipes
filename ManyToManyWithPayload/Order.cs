using System;
using System.Collections.Generic;

namespace ManyToManyWithPayload
{
    public class Order
    {
        public Order()
        {
            this.OrderDate = DateTime.UtcNow;
        }

        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
