namespace Zellis.HRSauce.Models
{
    public class EmployeeModel 
    {
        public string EmployeeIdentifier { get; set; }
        public string FullName { get; set; }
        public string Forename { get; set; }
        public string MiddleNames { get; set; }
        public string Surname { get; set; }
        public string ManagerFullName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public bool Leaver { get; set; }
        public string Division { get; set; }
        public string ParentEmployeeIdentifier { get; set; }
        public int NumberofDirectReports { get; set; }
    }
}