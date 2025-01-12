using System.ComponentModel.DataAnnotations;
namespace GovJobsWebAPI.Models
{
    public class WhoMayApply
    {
        [Key]
        public int WhoMayApplyId { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
    }
}
