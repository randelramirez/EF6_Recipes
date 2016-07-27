using System.Collections.Generic;

namespace ManyToManyWithPayloadFluentApi
{
    public class Item
    {

        public int Id { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
