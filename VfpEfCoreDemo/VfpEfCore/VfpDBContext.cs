using System.Data.Entity;
using VfpEntityFrameworkProvider;

namespace VfpEfCore
{
    [DbConfigurationType(typeof(VfpDbConfiguration))]
    public class VfpDBContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        /*protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            string path = System.Environment.CurrentDirectory.ToString();
            options.UseVfp($"Data Source={path}\\Sinca.dbc");
        }*/ 

        public VfpDBContext(string cs)
            : base(new VfpConnection(cs), true)
        {
        }
    }
}
