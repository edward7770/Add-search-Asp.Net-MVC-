namespace Zellis.HRSauce.Models
{
    public class CalculateModel
    {
        /// <summary>Gets or sets a count of all employees included in the calculation.</summary>
        public int EmployeeCount { get; set; }

        /// <summary>Gets or sets the Total computed monthly salary for the hierarchy.</summary>
        public decimal Total { get; set; }

        public decimal Str { get; set; }
        public string EmployeeIdentifier { get; set; }
        public decimal HourlyRate { get; set; }
        public decimal HoursWeekly { get; set; }

        /// <summary>Gets or sets the full name of the employee being calculated.</summary>
        public string EmployeeFullName { get; set; }

        /// <summary>Gets or sets the identifier of the employee being calculated.</summary>
        public string LastSearch { get; set; }
    }
}