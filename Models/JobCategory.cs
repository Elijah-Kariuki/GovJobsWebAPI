using System.ComponentModel.DataAnnotations;
namespace GovJobsWebAPI.Models
{
    public class JobCategory
    {
        [Key]   
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
    }
}
