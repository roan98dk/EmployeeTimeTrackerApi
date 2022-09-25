namespace WorkTracker.Apis
{
    public static class Api
    {
        public static void MapApis(this WebApplication app)
        {
            app.MapEmployeeApi();
            app.MapClientApi();
            app.MapWorkTaskApi();
            app.MapEmployeePerformanceApi();
            app.MapDepartmentPerformanceApi();
        }
    }
}
