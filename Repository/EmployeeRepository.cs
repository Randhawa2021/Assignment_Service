using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASG_ADAC_FE.ContextADAC;
using ASG_ADAC_FE.CoreModels;
using ASG_ADAC_FE.DTO;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ASG_ADAC_FE.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private DbContextADAC _dbContextADAC;

        public EmployeeRepository(DbContextADAC dbContextADAC
            )
        {
            _dbContextADAC = dbContextADAC;
        }

        public async Task<Employee> CreateEmployee(Employee _employee)
        {
            var obj = await _dbContextADAC.Employees.AddAsync(_employee);
            _dbContextADAC.SaveChanges();
            return obj.Entity;
        }

        public async Task<bool> UpdateEmployee(Employee _employee)
        {
            _dbContextADAC.Employees.Update(_employee);
            _dbContextADAC.SaveChanges();
            return true;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployee()
        {
            try
            {
                return await _dbContextADAC.Employees.ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Employee> GetEmployeeById(int Id)
        {
            return await _dbContextADAC.Employees.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<bool> DeleteEmployee(Employee _employee)
        {
            _dbContextADAC.Remove(_employee);
            _dbContextADAC.SaveChanges();
            return true;
        }



    }
}



