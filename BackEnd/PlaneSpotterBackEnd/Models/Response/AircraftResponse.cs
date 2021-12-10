
namespace PlaneSpotterBackEnd.Models.Response
{
    /*
    Aircraft Response Model
    */
    public class AircraftResponse
    {
        public string RegistrationId { get; set; }
        public AircraftTypeResponse AircraftType { get; set; }
    }
}
