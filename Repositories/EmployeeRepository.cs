using DataService;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DbSetContext _appContext;

        public EmployeeRepository(DbSetContext DaContext)
        {
            _appContext = DaContext ?? throw new ArgumentNullException(nameof(DaContext));
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _appContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeById(int Id)
        {
            return await _appContext.Employees.FindAsync(Id);
        }

        public async Task<Employee> InsertEmployee(Employee employee)
        {
            _appContext.Employees.Add(employee);
            await _appContext.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            _appContext.Entry(employee).State = EntityState.Modified;
            await _appContext.SaveChangesAsync();
            return employee;
        }

        public bool DeleteEmployee(int Id)
        {
            bool result = false;
            var objemployee = _appContext.Employees.Find(Id);
            if (objemployee != null)
            {
                _appContext.Entry(objemployee).State = EntityState.Deleted;
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }
    }
}
