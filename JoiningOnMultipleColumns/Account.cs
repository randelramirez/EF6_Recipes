using System.Collections.Generic;

namespace JoiningOnMultipleColumns
{
    public class Account
    {
        public Account()
        {
            Orders = new HashSet<Order>();
        }
        public int Id { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
