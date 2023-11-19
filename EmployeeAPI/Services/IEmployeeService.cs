using EmployeeAPI.DTOs;
using EmployeeAPI.Models;

namespace EmployeeAPI.Services
{
    public interface IEmployeeService
    {
        public ValueTask<bool> CreateEmployeeAsync(EmployeeDto employeeDto);
        public ValueTask<List<Employee>> GetAllEmployeeAsync();
        public ValueTask<Employee> GetByIdAsync(int id);
        public ValueTask<string> DeleteByIdAsync(int id);
        public ValueTask<string> UpdateEmployeeAsync(int id, EmployeeDto employee);
    }
}
