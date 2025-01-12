using System.ComponentModel.DataAnnotations;
namespace GovJobsWebAPI.Models
{
    public class PositionLocation
    {
        [Key]
        public int Id { get; set; }
        public string? LocationName { get; set; }
        public string? CountryCode { get; set; }
        public string? CountrySubDivisionCode { get; set; }
        public string? CityName { get; set; }
        public string? AddressLine { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
    }
}
