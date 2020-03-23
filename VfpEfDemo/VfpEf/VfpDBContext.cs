using System.Data.Entity;
using VfpEntityFrameworkProvider;

namespace VfpEf
{
    [DbConfigurationType(typeof(VfpDbConfiguration))]
    public class VfpDBContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        
        public VfpDBContext(string cs)
            : base(new VfpConnection(cs), true)
        {
        }
    }
}
