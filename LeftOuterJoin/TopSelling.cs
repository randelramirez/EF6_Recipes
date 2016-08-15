using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeftOuterJoin
{
    public class TopSelling
    {
        public int Id { get; set; }

        public int? Rating { get; set; }

        public virtual Product Product { get; set; }
    }
}
