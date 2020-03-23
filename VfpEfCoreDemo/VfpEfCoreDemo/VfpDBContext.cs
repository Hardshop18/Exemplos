using System.Data.Entity;
using VfpEntityFrameworkProvider;

namespace VfpEfCoreDemo
{
    [DbConfigurationType(typeof(VfpDbConfiguration))]
    public class VfpDBContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        /*protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            string path = System.Environment.CurrentDirectory.ToString() + "\\..\\..\\..\\";
            options.UseSqlite($"Data Source={path}sqlitedemo.db");
        } */
        public VfpDBContext()
            : base(new VfpConnection(@"D:\GitHub\dados\SincaTeste.dbc"), true)
        {
        }

        public VfpDBContext(string cs)
            : base(new VfpConnection(cs), true)
        {
        }
    }
}
