namespace ClinicaCloudPlatform.Model.Models
{
    /// <summary>
    /// Direct relationship to an Angular2 component
    /// Component should exist as typescript and might have a default static HTML which is overriden at runtime
    /// CSS is also applied
    /// Component will assume necessary data is provided (view model will work drom dynamics to deliver)
    /// </summary>
    public class DashboardComponent : _LimsBaseClass
    {
        public string DashboardComponentName { get; set; }
        /// <summary>
        /// Reference/route/path for Angular2 component in app
        /// </summary>
        public string ComponentAngular2Path { get; set; }
        /// <summary>
        /// The HTML template for an Angular 2 component
        /// </summary>
        public string ComponentAngular2HTMLTemplate { get; set; }
        /// <summary>
        /// CSS for Angular 2 component
        /// </summary>
        public string ComponentAngular2CSS { get; set; }

        /*
         *JSON represents data available to component 
         */
    }
}
