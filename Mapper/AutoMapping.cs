using ASG_ADAC_FE.CoreModels;
using ASG_ADAC_FE.DTO;
using AutoMapper;

namespace ASG_ADAC_FE.Mapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
           // ----Mapping Model to Dto vice versa------//
            CreateMap<Employee, EmployeeDTO>();
            CreateMap<EmployeeDTO, Employee>();
        }
    }
}
