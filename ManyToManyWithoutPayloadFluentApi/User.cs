using System.Collections.Generic;

namespace ManyToManyWithoutPayloadFluentApi
{
    public class User
    {
        public User()
        {
            this.Roles = new HashSet<Role>();
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}