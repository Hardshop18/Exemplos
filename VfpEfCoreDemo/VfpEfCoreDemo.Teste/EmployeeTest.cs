using System;
using System.Linq;
using VfpEfCore;
using Xunit;

namespace VfpEfCoreDemo.Teste
{
    public class EmployeeTest
    {
        VfpDBContext db;
        public EmployeeTest()
        {
            string path = System.Environment.CurrentDirectory.ToString();
            db = new VfpDBContext($"{path}\\Sinca.dbc");
            //db = new VfpDBContext();
        }

        private void CreateEmployee(string Name)
        {
            // Create
            db.Employees.Add(new Employee { FirstName = Name, LastName = "Doe", Age = 55 });
            db.SaveChanges();
        }

        private Employee GetEmployee()
        {
            try
            {
                return db.Employees
                    .OrderBy(b => b.Id)
                    .First();
            }
            catch
            {
                return null;
            }
        }

        private void DeleteEmployee(Employee employee)
        {
            db.Employees.Remove(employee);
            db.SaveChanges();
        }

        [Fact]
        public void Create()
        {
            string Name = "John";
            CreateEmployee(Name);

            // Read
            var employee = GetEmployee();

            Assert.Equal(employee.FirstName, Name);

            DeleteEmployee(employee);
        }

        [Fact]
        public void Update()
        {
            string Name = "Louis";
            CreateEmployee("John");

            // Read
            var employee = GetEmployee();

            // Update
            employee.FirstName = Name;
            employee.Age = 90;
            db.SaveChanges();

            // Read
            employee = GetEmployee();

            Assert.Equal(employee.FirstName, Name);

            // Delete
            DeleteEmployee(employee);
        }

        [Fact]
        public void Delete()
        {
            // Create
            CreateEmployee("John");
            // Read
            var employee = GetEmployee();
            // Delete
            DeleteEmployee(employee);

            employee = GetEmployee();
            Assert.Null(employee);
        }
    }
}
