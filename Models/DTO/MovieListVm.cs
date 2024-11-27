using Movie_App.Models.Domain;

namespace Movie_App.Models.DTO;

public class MovieListVm
{
    public IQueryable<Movie> MovieList { get; set; }
    public int PageSize { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public string? Term { get; set; }
}
