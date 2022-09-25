using DataAccess.Models;

namespace DataAccess.ViewModels
{
    public class WorkTaskViewModel
    {
        public Guid Id { get; set; }

        /// <summary>
        /// The employee carrying out the work task.
        /// </summary>
        public Guid EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        /// <summary>
        /// The client/customer for which the work task is aimed.
        /// </summary>
        public Guid ClientId { get; set; }
        public string ClientName { get; set; }

        /// <summary>
        /// Number of working hours planned or completed in the given target month.
        /// </summary>
        public int WorkHours { get; set; }

        /// <summary>
        /// The target month in which the working hours is planned or was completed.
        /// </summary>
        public int TargetMonth { get; set; }

        /// <summary>
        /// The target year in which the working hours is planned or was completed.
        /// </summary>
        public int TargetYear { get; set; }

        /// <summary>
        /// The category of the work task (planned or completed).
        /// </summary>
        public WorkTaskCategory TaskCategory { get; set; }

        /// <summary>
        /// The date that the work task was planned or completed.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Contructor the view model from a <see cref="WorkTask"/>
        /// </summary>
        /// <param name="workTask">The <see cref="WorkTask"/></param>
        public WorkTaskViewModel(WorkTask workTask)
        {
            Id = workTask.Id;
            EmployeeId = workTask.EmployeeId;
            EmployeeName = workTask.Employee.Name;
            ClientId = workTask.ClientId;
            ClientName = workTask.Client.Name;
            WorkHours = workTask.WorkHours;
            TargetMonth = workTask.TargetMonth;
            TargetYear = workTask.TargetYear;
            TaskCategory = workTask.TaskCategory;
            Created = workTask.Created;
        }
    }
}
