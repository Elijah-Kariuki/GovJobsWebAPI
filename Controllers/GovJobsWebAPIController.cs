using GovJobsWebAPI.Models;
using GovJobsWebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using GovJobsWebAPI.Data;

namespace GovJobsWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly JobSearch _usaJobsSearchService;
        private readonly JobDbContext _context;
        private readonly ILogger<JobsController> _logger;

        public JobsController(JobSearch usaJobsSearchService, JobDbContext context, ILogger<JobsController> logger)
        {
            _usaJobsSearchService = usaJobsSearchService;
            _context = context;
            _logger = logger;
        }

        [HttpGet("search")]
        public async Task<ActionResult<List<JobViewModel>>> Search([FromQuery] string keyword, [FromQuery] string location)
        {
            _logger.LogInformation("Search called with keyword: {Keyword}, location: {Location}", keyword, location);
            var jobs = await _usaJobsSearchService.SearchJobsAsync(keyword, location);
            if (jobs == null || jobs.Count == 0)
            {
                _logger.LogWarning("No jobs found for keyword: {Keyword}, location: {Location}", keyword, location);
                return NotFound("No jobs found");
            }
            _logger.LogInformation("Returning {Count} jobs", jobs.Count);
            return Ok(jobs);
        }

        [HttpPost("save")] // Add a new endpoint for saving
        public async Task<IActionResult> SaveJob(JobViewModel job)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return validation errors
            }
            _context.Jobs.Add(job);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
