using CoreLayer.Models;
using DataLayer.DAL;
using DataLayer.Repositories.Abstractions;
using DataLayer.Repositories.Iplementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.Implementations
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AppDBContext context) : base(context)
        {
        }
    }
}
