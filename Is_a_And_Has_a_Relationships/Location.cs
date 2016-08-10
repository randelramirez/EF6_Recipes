using System.Collections.Generic;

namespace Is_a_And_Has_a_Relationships
{
    public class Location
    {
        public Location()
        {
            this.Parks = new HashSet<Park>();
        }

        public int Id { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZIPCode { get; set; }

        public virtual ICollection<Park> Parks { get; set; }

    }
}
