using DataAccess.Models;

namespace DataAccess.ViewModels
{
    public class EmployeeViewModel
    {
        /// <summary>
        /// A unique employee ID in case of overlapping names
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The name of the employee
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The email of the employee
        /// </summary>
        public string Email { get; set; } = string.Empty;

        // The Danish CPR number of the employee
        public string CprNumber { get; set; } = string.Empty;

        /// <summary>
        /// The department in which the employee works
        /// </summary>
        public string Department { get; set; } = string.Empty;

        /// <summary>
        /// Constucts a view model from an <see cref="Employee"/>
        /// </summary>
        /// <param name="employee">The <see cref="Employee"/></param>
        public EmployeeViewModel(Employee employee)
        {
            Id = employee.Id;
            Name = employee.Name;
            Email = employee.Email;
            CprNumber = employee.CprNumber;
            Department = employee.Department;
        }
    }
}
