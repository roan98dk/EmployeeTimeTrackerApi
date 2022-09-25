using DataAccess.Models;

namespace DataAccess.ViewModels
{
    public class DepartmentPerformanceViewModel
    {
        public DepartmentPerformanceViewModel(string department, int month, int year) 
        {
            Department = department;
            TargetMonth = month;
            TargetYear = year;
        }

        public DepartmentPerformanceViewModel(Employee employee, int month, int year)
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

            Department = employee.Department;
            TargetMonth = month;
            TargetYear = year;
        }

        public string Department { get; set; }
        public int TargetMonth { get; set; }
        public int TargetYear { get; set; }
        public int WorkHoursPlanned { get; set; }
        public int WorkHoursCompleted { get; set; }
        public int ExpectedIncome { get; set; }
        public int ActualIncome { get; set; }
    }
}
