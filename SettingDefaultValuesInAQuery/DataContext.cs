using System.Data.Entity;namespace SettingDefaultValuesInAQuery
{
    public class DataContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
    }
}
