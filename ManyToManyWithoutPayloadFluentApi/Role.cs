using System.Collections.Generic;

namespace ManyToManyWithoutPayloadFluentApi
{
    public class Role
    {
        public Role()
        {
            this.Users = new HashSet<User>();
        }

        public int Id { get; set; }

        public string RoleName { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
