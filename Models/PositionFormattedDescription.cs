using System.ComponentModel.DataAnnotations;
namespace GovJobsWebAPI.Models
{
    public class PositionFormattedDescription
    {
        [Key]
        public int Id { get; set; }
        public string? Label { get; set; }
        public string? LabelDescription { get; set; }
    }
}
