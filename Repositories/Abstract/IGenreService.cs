using Movie_App.Models.Domain;

namespace Movie_App.Repositories.Abstract;

public interface IGenreService
{
    bool Add(Genre model);
    bool Update(Genre model);
    Genre GetById(int id);
    bool Delete(int id);
    IQueryable<Genre> List();

}