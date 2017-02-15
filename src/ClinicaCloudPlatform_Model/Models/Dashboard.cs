namespace ClinicaCloudPlatform.Model.Models
{
    /// <summary>
    /// Expectation is of specific fixed dashboards available to users
    /// Dashboards will default and be user-customizable
    /// Dashboard will have three sections, each containing one or more components
    /// Empty sections do not appear
    /// </summary>
    public class Dashboard : _LimsBaseClass
    {
        public string DashboardName { get; set; }
        public bool DefaultDashboard { get; set; }
        public DashboardTypes DashboardType { get; set; }
        public DashboardSection HeaderSection { get; set; }
        public DashboardSection LeftSection { get; set; }
        public DashboardSection RightSection { get; set; }
    }
    
    public enum DashboardTypes
    {
        TrackingDashboard,
        LabDashboard
    }
}
