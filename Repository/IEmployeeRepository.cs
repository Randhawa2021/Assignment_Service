using System.Collections.Generic;
using System.Threading.Tasks;
using ASG_ADAC_FE.CoreModels;
using ASG_ADAC_FE.DTO;

namespace ASG_ADAC_FE.Repository
{
    public interface IEmployeeRepository
    {
        public Task<Employee> CreateEmployee(Employee _employee);

        public Task<bool> UpdateEmployee(Employee _employee);

        public Task<IEnumerable<Employee>> GetAllEmployee();

        public Task<Employee> GetEmployeeById(int Id);

        public Task<bool> DeleteEmployee(Employee _employee);


    }
}
