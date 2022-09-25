using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    /// <summary>
    /// Work task planned or completed of an <see cref="Employee"/> for a <see cref="Client"/> in a given month.
    /// </summary>
    public class WorkTask
    {
        public Guid Id { get; set; }

        /// <summary>
        /// The employee carrying out the work task.
        /// </summary>
        public Employee Employee { get; set; }

        [Required]
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// The client/customer for which the work is aimed.
        /// </summary>
        public Client Client { get; set; }

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
        [Required]
        public DateTime Created { get; set; } = DateTime.Now;

        /// <summary>
        /// Default constructor
        /// </summary>
        public WorkTask() { }

        /// <summary>
        /// Construct a work task from a <see cref="AddWorkTask"/>
        /// </summary>
        /// <param name="workTask">The <see cref="AddWorkTask"/></param>
        public WorkTask(AddWorkTask workTask)
        {
            Id = Guid.NewGuid();
            EmployeeId = workTask.EmployeeId;
            ClientId = workTask.ClientId;
            WorkHours = workTask.WorkHours;
            TargetMonth = workTask.TargetMonth;
            TargetYear = workTask.TargetYear;
            TaskCategory = workTask.TaskCategory;
        }
    }
}
