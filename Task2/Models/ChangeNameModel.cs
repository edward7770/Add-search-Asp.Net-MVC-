namespace Zellis.HRSauce.Models
{
    public class ChangeNameModel
    {
        /// <summary>Gets or sets a value that indicates whether the name change operation was successful.</summary>
        public bool Success { get; set; }

        /// <summary>Gets or sets the identifier of the employee that was changed.</summary>
        public string LastSearch { get; set; }       
    }
}