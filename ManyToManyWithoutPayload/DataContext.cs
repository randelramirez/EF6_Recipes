using System.Data.Entity;

namespace ManyToManyWithoutPayload
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }
    }
}
