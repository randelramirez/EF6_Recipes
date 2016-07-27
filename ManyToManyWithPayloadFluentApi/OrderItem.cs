using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManyToManyWithPayloadFluentApi
{
    public class OrderItem
    {

        public int OrderId { get; set; }

        public int ItemId { get; set; }

        public int Count { get; set; }

        public virtual Order Order { get; set; }

        public virtual Item Item { get; set; }
    }
}
