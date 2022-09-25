using DataAccess.Models;

namespace DataAccess.ViewModels
{
    public class EmployeePerformanceViewModel
    {
        public EmployeePerformanceViewModel(Employee employee, int month, int year)
        {
            var workTasks = employee.WorkTasks.Where(t => t.TargetMonth == month && t.TargetYear == year);
            foreach (var task in workTasks)
            {
                if (task.TaskCategory == WorkTaskCategory.Planned)
                {
                    WorkHoursPlanned += task.WorkHours;
                    ExpectedIncome += task.WorkHours * task.Client.HourRate;
                }
                else
                {
                    WorkHoursCompleted += task.WorkHours;
                    ActualIncome += task.WorkHours * task.Client.HourRate;
                }
            }

            TargetMonth = month;
            TargetYear = year;
            Employee = new EmployeeViewModel(employee);
        }

        public EmployeeViewModel Employee { get; }
        public int TargetMonth { get; }
        public int TargetYear { get; }
        public int WorkHoursPlanned { get; }
        public int WorkHoursCompleted { get; }
        public int ExpectedIncome { get; }
        public int ActualIncome { get; }
    }
}
