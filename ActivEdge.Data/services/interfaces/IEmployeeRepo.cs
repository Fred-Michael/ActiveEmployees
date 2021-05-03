using ActiveEdge.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ActivEdge.Data.services.interfaces
{
    public interface IEmployeeRepo
    {
        Task<bool> CreateEmployee(Employee employee);
        Task<List<Employee>> GetAllEmployees();
        Task<Employee> GetAnEmployee(string employeeId);
        Task<bool> UpdateAnEmployee(Employee employee);
        Task<bool> DeleteAnEmployee(Employee employee);
    }
}