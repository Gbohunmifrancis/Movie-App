namespace Movie_App.Models.DTO
{
    // MovieDto.cs
    public class MovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public string PosterPath { get; set; }
        public string FullPosterPath => $"https://image.tmdb.org/t/p/w500{PosterPath}";
        public string BackdropPath { get; set; }
        public string FullBackdropPath => $"https://image.tmdb.org/t/p/w500{BackdropPath}";
        public string ReleaseDate { get; set; }
        
        public double VoteAverage { get; set; }
        public List<string> Genres { get; set; } = new List<string>();

        // This dictionary maps genre IDs to genre names
        private static readonly Dictionary<int, string> GenreMap = new Dictionary<int, string>
        {
            { 28, "Action" },
            { 12, "Adventure" },
            { 16, "Animation" },
            { 35, "Comedy" },
            { 80, "Crime" },
            { 99, "Documentary" },
            { 18, "Drama" },
            { 10751, "Family" },
            { 14, "Fantasy" },
            { 36, "History" },
            { 27, "Horror" },
            { 10402, "Music" },
            { 9648, "Mystery" },
            { 10749, "Romance" },
            { 878, "Science Fiction" },
            { 10770, "TV Movie" },
            { 53, "Thriller" },
            { 10752, "War" },
            { 37, "Western" }
        };

        // This method maps the API response to the MovieDto
        public static MovieDto FromApiResponse(MovieApiResponse apiResponse)
        {
            return new MovieDto
            {
                Id = apiResponse.Id,
                Title = apiResponse.Title,
                Overview = apiResponse.Overview,
                PosterPath = apiResponse.PosterPath,
                BackdropPath = apiResponse.BackdropPath,
                ReleaseDate = apiResponse.ReleaseDate,
                VoteAverage = apiResponse.VoteAverage,
                Genres = apiResponse.GenreIds?.Select(id => GenreMap.ContainsKey(id) ? GenreMap[id] : "Unknown").ToList() ?? new List<string>()
            };
        }
    }
    public class MovieApiResult
    {
        public List<MovieDto> Results { get; set; }
    }
    public class MovieApiResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public string PosterPath { get; set; }
        public string BackdropPath { get; set; }
        public string ReleaseDate { get; set; }
        public double VoteAverage { get; set; }
        public List<int> GenreIds { get; set; } // Genre IDs instead of full Genre objects
    }
}
