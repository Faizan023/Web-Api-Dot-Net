using DataService;

namespace Repositories{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployeeById(int Id);
        Task<Employee> InsertEmployee(Employee employee);
        Task<Employee> UpdateEmployee(Employee employee);
        bool DeleteEmployee(int Id);
    }
}