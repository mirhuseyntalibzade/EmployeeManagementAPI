using BusinessLayer.Services.Abstractions;
using CoreLayer.Models;
using DataLayer.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        readonly IEmployeeRepository _repository;
        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }
        public async Task AddEmployeeAsync(Employee employee)
        {
            if (employee is null)
            {
                throw new Exception("Employee cannot be null");
            }
            await _repository.Create(employee);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(Employee employee)
        {
            Employee deletedEmployee = await _repository.FindOneAsync(d => d.Id == employee.Id);
            if (employee is null)
            {
                throw new Exception("Employee cannot be null");
            }
            _repository.Delete(employee);
            await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            var employee = await _repository.FindByIdAsync(id);
            if (employee == null)
            {
                throw new Exception($"Employee with id {id} not found.");
            }
            return employee;
        }

        public async Task UpdateEmployeeAsync(Employee updatedEmployee)
        {
            Employee employee = await _repository.FindOneAsync(d => d.Id == updatedEmployee.Id);
            if (employee is null)
            {
                throw new Exception("Cannot find employee");
            }
            _repository.Update(updatedEmployee);
            await _repository.SaveChangesAsync();
        }
    }
}
