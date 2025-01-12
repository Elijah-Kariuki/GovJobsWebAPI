using GovJobsWebAPI.Models;
using GovJobsWebAPI.Data;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace GovJobsWebAPI.Services
{
    public class JobSearch
    {
        private readonly HttpClient _client;
        private readonly JobDbContext _context;
        private readonly ILogger<JobSearch> _logger;
        private readonly UsaJobsApiConfig _usaJobsApiConfig;
        private const string BaseUrl = "https://data.usajobs.gov/api/search";

        public JobSearch(HttpClient client, JobDbContext context, ILogger<JobSearch> logger, IOptions<UsaJobsApiConfig> usaJobsApiConfig)
        {
            _client = client;
            _context = context;
            _logger = logger;
            _usaJobsApiConfig = usaJobsApiConfig.Value;

            _client.DefaultRequestHeaders.UserAgent.ParseAdd(_usaJobsApiConfig.UserAgent);
            _client.DefaultRequestHeaders.Add("Authorization-Key", _usaJobsApiConfig.AuthorizationKey);
        }

        public async Task<List<JobViewModel>> SearchJobsAsync(string keyword, string location)
        {
            var url = $"{BaseUrl}?Keyword={keyword}&LocationName={location}";

            try
            {
                var response = await _client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();

                // Log the raw JSON response
                _logger.LogInformation("Received JSON response: {ResponseBody}", responseBody);

                var apiResponse = JsonConvert.DeserializeObject<UsaJobsApiResponse>(responseBody);

                // Log the deserialized response
                _logger.LogInformation("Deserialized response: {@ApiResponse}", apiResponse);

                if (apiResponse?.SearchResult == null)
                {
                    _logger.LogWarning("SearchResult is null");
                }

                if (apiResponse?.SearchResult?.SearchResultItems == null)
                {
                    _logger.LogWarning("SearchResultItems is null");
                }

                var jobs = apiResponse?.SearchResult?.SearchResultItems
                    ?.Select(item =>
                    {
                        if (item.MatchedObjectDescriptor == null)
                        {
                            _logger.LogWarning("MatchedObjectDescriptor is null for item: {@Item}", item);
                            return null;
                        }

                        var job = new JobViewModel(item.MatchedObjectDescriptor, location);
                        if (job.PositionLocationDisplay == "Multiple Locations")
                        {
                            // filter jobs with multiple locations based on the PositionLocation.LocationName
                            var locations = job.PositionLocations.Where(pl => pl.LocationName.Contains(location)).Select(pl => new PositionLocation
                            {
                                LocationName = pl.LocationName,
                                CountryCode = pl.CountryCode,
                                CountrySubDivisionCode = pl.CountrySubDivisionCode,
                                CityName = pl.CityName,
                                AddressLine = pl.AddressLine,
                                Longitude = pl.Longitude,
                                Latitude = pl.Latitude
                            }).ToList();
                            job.PositionLocations = locations;
                        }
                        var details = item.MatchedObjectDescriptor.UserArea?.Details;
                        if (details != null)
                        {
                            job.SetDetails(details);
                        }
                        
                        return job;
                    })
                    .Where(job => job != null)
                    .ToList() ?? new List<JobViewModel>();

                if (jobs.Count == 0)
                {
                    _logger.LogWarning("No jobs found for keyword: {Keyword}, location: {Location}", keyword, location);
                }

                foreach (var job in jobs)
                {
                    if (!_context.Jobs.Any(j => j.PositionID == job.PositionID))
                    {
                        
                        _context.Jobs.Add(job);
                    }
                }

                await _context.SaveChangesAsync();

                return jobs;
            }
            catch (HttpRequestException e)
            {
                _logger.LogError(e, "Error searching jobs for {Keyword} in {Location}", keyword, location);
                throw; // Or rethrow a custom exception
            }
        }
    }
}
