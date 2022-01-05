using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ASG_ADAC_FE.DTO;
using ASG_ADAC_FE.Repository;
using ASG_ADAC_FE.CoreModels;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace ASG_ADAC_FE.Controllers
{
    [Route("api/[controller]")]
   // [Authorize]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IMapper mapper,
            IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        // GET: api/Employees
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<EmployeeDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IEnumerable<EmployeeDTO> GetEmployee()
        {
            var employeRawData =  _employeeRepository.GetAllEmployee();
            return _mapper.Map<IEnumerable<EmployeeDTO>>(employeRawData.Result);
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EmployeeDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]        
        public EmployeeDTO GetEmployee(int id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);
            return _mapper.Map<EmployeeDTO>(employee.Result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool PutEmployee(int id, EmployeeDTO employee)
        {
            if (id != employee.Id)
            {
                return false;
            }
            try
            {
                _employeeRepository.UpdateEmployee(_mapper.Map<Employee>(employee));
            }
            catch
            {
                if (!EmployeeExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            return true;
        }


         
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<String> PostEmployee(EmployeeDTO employee)
        {
            var val = await _employeeRepository.CreateEmployee(_mapper.Map<Employee>(employee));

            return "Employee has been created successfuly";
        }

        // DELETE: api/Employees/1
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public EmployeeDTO DeleteEmployee(int id)
        {
            var employee =  _employeeRepository.GetEmployeeById(id);
           
            var rslt =  _employeeRepository.DeleteEmployee(employee.Result);

            return _mapper.Map<EmployeeDTO>(employee.Result);
        }

        private bool EmployeeExists(int id)
        {
            return _employeeRepository.GetEmployeeById(id).Result == null ? false : true;
        }

    }
}
