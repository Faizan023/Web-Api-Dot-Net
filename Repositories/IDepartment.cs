using DataService;

namespace Repositories{
    public interface IDepartment
    {
        Task<IEnumerable<Department>> GetDepartments();
        Task<Department> GetDepartmentById(int Id);
        Task<Department> InsertDepartment(Department department);
        Task<Department> UpdateDepartment(Department department);
        bool DeleteDepartment(int Id);
    }
}