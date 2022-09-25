using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    /// <summary>
    /// Adds <see cref="WorkTask"/> of an <see cref="Employee"/> for a <see cref="Client"/> in a given month.
    /// </summary>
    public class AddWorkTask
    {
        /// <summary>
        /// The employee carrying out the work task.
        /// </summary>
        [Required]
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// The client/customer for which the work is planned.
        /// </summary>
        [Required]
        public Guid ClientId { get; set; }

        /// <summary>
        /// Number of working hours planned or completed in the given target month.
        /// </summary>
        [Required]
        [Range(1, 1000)]
        public int WorkHours { get; set; }

        /// <summary>
        /// The target month in which the working hours is planned or was completed.
        /// </summary>
        [Required]
        [Range(1, 12)]
        public int TargetMonth { get; set; } = DateTime.Now.Month;

        /// <summary>
        /// The target year in which the working hours is planned or was completed.
        /// </summary>
        [Required]
        [Range(2022, 2050)]
        public int TargetYear { get; set; } = DateTime.Now.Year;

        /// <summary>
        /// The category of the work task (planned or completed).
        /// </summary>
        [Required]
        public WorkTaskCategory TaskCategory { get; set; } = WorkTaskCategory.Planned;

        /// <summary>
        /// The date that the work task was planned or completed.
        /// </summary>
        public DateTime Created { get; set; } = DateTime.Now;
    }

    /// <summary>
    /// The category of the work task (planned or completed).
    /// </summary>
    public enum WorkTaskCategory
    {
        Planned,
        Completed
    }
}
