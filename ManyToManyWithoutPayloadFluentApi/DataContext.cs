using System.Data.Entity;

namespace ManyToManyWithoutPayloadFluentApi
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
               .HasMany<Role>(user => user.Roles)
               .WithMany(role => role.Users)
               .Map(userRole =>
               {
                   userRole.MapLeftKey("UserId");
                   userRole.MapRightKey("RoleId");
                   userRole.ToTable("UserRoles");
               });

            // anotherway
            //modelBuilder.Entity<Role>()
            //    .HasMany(role => role.Users)
            //    .WithMany(user => user.Roles)
            //    .Map(roleUser =>
            //    {
            //        roleUser.MapLeftKey("RoleId");
            //        roleUser.MapRightKey("UserId");
            //        roleUser.ToTable("RoleUsers");
            //    });
        }
    }
}
