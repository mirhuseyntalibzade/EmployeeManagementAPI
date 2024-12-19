using BusinessLayer.Services.Abstractions;
using CoreLayer.Models;
using DataLayer.Repositories.Abstractions;
using DataLayer.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        readonly IDepartmentRepository _repository;
        public DepartmentService(IDepartmentRepository repository)
        {
            _repository = repository;
        }
        public async Task AddDepartmentAsync(Department department)
        {
            if (department is null)
            {
                throw new Exception("Department cannot be null");
            }
            await _repository.Create(department);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteDepartmentAsync(Department department)
        {
            Department deletedDepartment = await _repository.FindOneAsync(d => d.Id == department.Id);
            if (department is null)
            {
                throw new Exception("Department cannot be null");
            }
            _repository.Delete(department);
            await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Department> GetDepartmentByIdAsync(int id)
        {
            var department = await _repository.FindByIdAsync(id);
            if (department == null)
            {
                throw new Exception($"Employee with id {id} not found.");
            }
            return department;
        }

        public async Task UpdateDepartmentAsync(Department updatedDepartment)
        {
            Department department = await _repository.FindOneAsync(d => d.Id == updatedDepartment.Id);
            if (department is null)
            {
                throw new Exception("Cannot find department");
            }
            _repository.Update(updatedDepartment);
            await _repository.SaveChangesAsync();
        }
    }
}
