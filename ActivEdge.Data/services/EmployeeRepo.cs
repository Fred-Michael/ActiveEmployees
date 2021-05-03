using ActivEdge.Data.services.interfaces;
using ActiveEdge.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ActivEdge.Data.services
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly AppDbContext _ctx;

        public EmployeeRepo(AppDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<bool> CreateEmployee(Employee employee)
        {
            _ctx.Employees.Add(employee);
            return await _ctx.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAnEmployee(Employee employee)
        {
            _ctx.Employees.Remove(employee);
            return await _ctx.SaveChangesAsync() > 0;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            var allEmployees = await _ctx.Employees.ToListAsync();
            return allEmployees;
        }

        public async Task<Employee> GetAnEmployee(string employeeId)
        {
            var employee = await _ctx.Employees.FirstOrDefaultAsync(emp => emp.EmployeeId == employeeId);
            return employee;
        }

        public async Task<bool> UpdateAnEmployee(Employee employee)
        {
            _ctx.Employees.Update(employee);
            return await _ctx.SaveChangesAsync() > 0;
        }
    }
}