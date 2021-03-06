﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManyToManyWithPayload
{
    public class OrderItem
    {
        [Key]
        [ForeignKey("Order")]
        [Column(Order = 0)]
        public int OrderId { get; set; }

        [Key, ForeignKey("Item"), Column(Order = 1)]
        public int ItemId { get; set; }

        public int Count { get; set; }

        public virtual Order Order { get; set; }

        public virtual Item Item { get; set; }
    }
}
