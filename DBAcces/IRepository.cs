using WebApp1.Models;

namespace WebApp1.DBAcces
{
	public interface IRepository
	{
		Movie GetMovieById(long movieId);
		Movie InsertMovie(MovieDto movieDto);
	}
}
