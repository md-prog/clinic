namespace ClinicaCloudPlatform.Model.ApiModels
{
    public class Facility : _ApiModelBaseClass
    {
        public string Name { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}
