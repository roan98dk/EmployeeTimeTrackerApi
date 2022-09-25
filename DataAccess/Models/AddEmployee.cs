using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    /// <summary>
    /// Adds a new <see cref="Employee"/>
    /// </summary>
    public class AddEmployee
    {
        /// <summary>
        /// The name of the employee
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The email of the employee
        /// </summary>
        [Required]
        [EmailAddress]
        [MaxLength(255)]
        public string Email { get; set; } = string.Empty;

        // The Danish CPR number of the employee
        [Required]
        [MaxLength(11)]
        [RegularExpression("\\d{6}-\\d{4}", ErrorMessage = "The CPR number must match the format ######-####, where # is a number.")]
        public string CprNumber { get; set; } = string.Empty;

        /// <summary>
        /// The department in which the employee works
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Department { get; set; } = string.Empty;
    }
}
