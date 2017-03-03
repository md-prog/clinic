namespace ClinicaCloudPlatform.Model.Models
{
    public interface ITypeSequenced
    {
        string Type { get; set; }
        int CurrentTypeSequenceNumber { get; set; }
    }
}
