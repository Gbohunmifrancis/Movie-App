namespace Movie_App.Models.DTO;

// MovieDto.cs
public class MovieDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Overview { get; set; }
    public string PosterPath { get; set; }
    public string FullPosterPath => $"https://image.tmdb.org/t/p/w500{PosterPath}";
    public string ReleaseDate { get; set; }
    public double VoteAverage { get; set; }
    public List<string> Genres { get; set; }

    // This method will help map the genres properly from the API response
    public static MovieDto FromApiResponse(MovieApiResponse apiResponse)
    {
        return new MovieDto
        {
            Id = apiResponse.Id,
            Title = apiResponse.Title,
            Overview = apiResponse.Overview,
            PosterPath = apiResponse.PosterPath,
            ReleaseDate = apiResponse.ReleaseDate,
            VoteAverage = apiResponse.VoteAverage,
            Genres = apiResponse.Genres.Select(genre => genre.Name).ToList()
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
    public string ReleaseDate { get; set; }
    public double VoteAverage { get; set; }
    public List<Genre> Genres { get; set; }
}

public class Genre
{
    public int Id { get; set; }
    public string Name { get; set; }
}
