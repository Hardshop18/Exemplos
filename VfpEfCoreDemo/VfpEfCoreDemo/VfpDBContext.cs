
using Microsoft.EntityFrameworkCore;

namespace VfpEfCoreDemo
{
    public class VfpDBContext : DbContext
    {
        private readonly string _connectionString;
        public DbSet<Employee> Employees { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseVfp(_connectionString); 
        }

        public VfpDBContext(string connectionString)
            : base()
        {
            _connectionString = connectionString;
        }
    }
}
