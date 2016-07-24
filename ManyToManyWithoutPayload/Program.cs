using System;
using System.Linq;

namespace ManyToManyWithoutPayload
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new DataContext())
            {
                // users
                var user1 = new User { Username = "foo-user" };
                var user2 = new User { Username = "bar-user" };

                // roles
                var role1 = new Role { RoleName = "Admin" };
                var role2 = new Role { RoleName = "Tester" };
                var role3 = new Role { RoleName = "Developer" };

                user1.Roles.Add(role1);
                user1.Roles.Add(role2);
                user2.Roles.Add(role3);

                context.Users.Add(user1);
                context.Users.Add(user2);
                context.SaveChanges();

                var queryable = context.Users.ToList();
            }
                Console.ReadKey();
        }
    }
}
