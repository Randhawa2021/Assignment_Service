namespace ASG_ADAC_FE.CoreModels
{
    //--- POCO CLASSES FOR NEWS TAGS ----//
    public class Address
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string  FullAddress { get; set; }
        public Employee CurrentEmployeeAddress { get; set; }
        
    }
}
