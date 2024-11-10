using System.Text.Json;
using Movie_App.Models.DTO;
using Microsoft.Extensions.Logging;

namespace Movie_App.Services
{
    public class MovieService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly ILogger<MovieService> _logger;

        public MovieService(HttpClient httpClient, IConfiguration configuration, ILogger<MovieService> logger)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://api.themoviedb.org/3/");
            _apiKey = configuration["TMDbApiKey"]; // Retrieve the API key from appsettings.json
            _logger = logger;
        }

        public async Task<List<MovieDto>> GetPopularMoviesAsync()
        {
            try
            {
                // Make the API call
                var response = await _httpClient.GetAsync($"movie/popular?api_key={_apiKey}&language=en-US&page=1");
                
                // Check if the response is successful
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError($"Failed to fetch movies. Status Code: {response.StatusCode}");
                    return new List<MovieDto>(); // Return an empty list if the request fails
                }

                // Get the raw JSON content
                var content = await response.Content.ReadAsStringAsync();
                _logger.LogInformation($"API Response Content: {content}"); // Log the JSON content to the console

                // Deserialize the JSON content into MovieApiResult
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true // Ensure properties match case-insensitive
                };
                var result = JsonSerializer.Deserialize<MovieApiResult>(content, options);
                
                // Check if the result contains any movies
                if (result?.Results == null || result.Results.Count == 0)
                {
                    _logger.LogWarning("No movies found in the API response.");
                    return new List<MovieDto>(); // Return an empty list if no movies found
                }

                // Return the list of movies or an empty list if none were found
                return result?.Results ?? new List<MovieDto>();
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while fetching movies: {ex.Message}");
                return new List<MovieDto>(); // Return an empty list in case of error
            }
        }
    }
}
