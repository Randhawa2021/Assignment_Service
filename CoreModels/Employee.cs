using System.Collections.Generic;

namespace ASG_ADAC_FE.CoreModels
{
    //--- POCO CLASSES FOR NEWS ----//
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public ICollection<Address> EmployeeAddress { get; set; }
    }
}
