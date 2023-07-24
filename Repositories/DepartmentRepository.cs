using DataService;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class DepartmentRepository : IDepartment
    {
        private readonly DbSetContext _appContext;

        public DepartmentRepository(DbSetContext context)
        {
            _appContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await _appContext.Departments.ToListAsync();
        }

        public async Task<Department> GetDepartmentById(int Id)
        {
            return await _appContext.Departments.FindAsync(Id);
        }

        public async Task<Department> InsertDepartment(Department department)
        {
            _appContext.Departments.Add(department);
            await _appContext.SaveChangesAsync();
            return department;
        }

        public async Task<Department> UpdateDepartment(Department department)
        {
            _appContext.Entry(department).State = EntityState.Modified;
            await _appContext.SaveChangesAsync();
            return department;
        }

        public bool DeleteDepartment(int Id)
        {
            var Results = false;
            var objdepartment = _appContext.Departments.Find(Id);
            if (objdepartment != null)
            {
                _appContext.Entry(objdepartment).State = EntityState.Deleted;
                _appContext.SaveChanges();
                Results = true;
            }
            else
            {
                Results = false;
            }
            return Results;
        }
    }
}
