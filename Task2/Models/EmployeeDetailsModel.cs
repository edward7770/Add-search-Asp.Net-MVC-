namespace Zellis.HRSauce.Models
{
    public class EmployeeDetailsModel
    {
        /// <summary>Gets or sets a list of all employees to show details for.</summary>
        public List<EmployeeModel> Employees { get; set; } = new List<EmployeeModel>();

        /// <summary>Gets or sets the last search value.</summary>
        public string LastSearch { get; set; }
    }
}