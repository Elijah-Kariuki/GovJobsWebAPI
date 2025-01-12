using System.ComponentModel.DataAnnotations;
namespace GovJobsWebAPI.Models
{
    public class PositionRemuneration
    {
        [Key]
        public int Id { get; set; }
        public string? MinimumRange { get; set; }
        public string? MaximumRange { get; set; }
        public string? RateIntervalCode { get; set; }
        public string? Description { get; set; }
    }
}
