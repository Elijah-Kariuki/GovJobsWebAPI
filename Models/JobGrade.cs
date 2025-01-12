using System.ComponentModel.DataAnnotations;
namespace GovJobsWebAPI.Models
{
    public class JobGrade
    {
        [Key]
        public int Id { get; set; }
        public string? Code { get; set; }
    }
}
