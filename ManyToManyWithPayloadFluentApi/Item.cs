using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManyToManyWithPayloadFluentApi
{
    public class Item
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }
    }
}
