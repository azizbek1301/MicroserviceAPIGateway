using EmployeeAPI.DataAcsess;
using EmployeeAPI.DTOs;
using EmployeeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _appDbContext;
        public EmployeeService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            
        }

        public async ValueTask<bool> CreateEmployeeAsync(EmployeeDto employeeDto)
        {
            try
            {

                var res = new Employee()
                {
                    Name = employeeDto.Name,
                    Price = employeeDto.Price,
                };
                await _appDbContext.Employees.AddAsync(res);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async ValueTask<string> DeleteByIdAsync(int id)
        {
            try
            {
                var res = await _appDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
                if(res!=null)
                {
                    _appDbContext.Employees.Remove(res);
                    await _appDbContext.SaveChangesAsync();
                    return "o'chirildi";

                }
                else
                {
                    return "Not found";
                }

            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }        

        public async ValueTask<List<Employee>> GetAllEmployeeAsync()
        {
            try
            {
                var res = await _appDbContext.Employees.AsNoTracking().ToListAsync();
                return res;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async ValueTask<Employee> GetByIdAsync(int id)
        {
            try
            {
                var res=await _appDbContext.Employees.FirstOrDefaultAsync(x=>x.Id == id);
                return res;

            }
            catch(Exception ex)
            {
                return null;
            }
            
        }

        public async ValueTask<string> UpdateEmployeeAsync(int id, EmployeeDto employee)
        {
            try
            {
                var res = await _appDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
                if (res != null)
                {
                    res.Name = employee.Name;
                    res.Price = employee.Price;
                    await _appDbContext.SaveChangesAsync();
                    return "Yangilandi";
                }
                else
                {
                    return "Topilmadi";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
