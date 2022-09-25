using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    /// <summary>
    /// Employee details
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// A unique employee ID in case of overlapping names
        /// </summary>
        public Guid Id { get; set; }

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
        [RegularExpression("\\d{6}-\\d{4}", ErrorMessage = "The CPR number must match the format ######-####, where # is a number.")]
        [MaxLength(11)]
        public string CprNumber { get; set; } = string.Empty;

        /// <summary>
        /// The department in which the employee works
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Department { get; set; } = string.Empty;

        /// <summary>
        /// Work tasks related to the employee, both planned and completed.
        /// </summary>
        public ICollection<WorkTask> WorkTasks { get; set; } = new List<WorkTask>();

        /// <summary>
        /// Default constructor
        /// </summary>
        public Employee() { }

        /// <summary>
        /// Constructor for a new employee.
        /// </summary>
        /// <param name="addEmployee">New employee information</param>
        public Employee(AddEmployee addEmployee)
        {
            Id = Guid.NewGuid();
            Name = addEmployee.Name;
            Email = addEmployee.Email;
            CprNumber = addEmployee.CprNumber;
            Department = addEmployee.Department;
        }
    }
}
