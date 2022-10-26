using System.Data.SqlClient;
using WebApp1.Models;

namespace WebApp1.DBAcces
{
	public class Repository : IRepository
	{
		private readonly MoviesContext context;
		public Repository(MoviesContext context)
		{
			this.context = context;
		}


		public Movie GetMovieById(long movieId)
		{
			return context.Movies.FirstOrDefault(x => x.Id == movieId);
		}

		public Movie InsertMovie(MovieDto movieDto)
		{
			var entity = context.Add(new Movie()
			{
				Title = movieDto.Title,
				Director = movieDto.Director,
				Year = Convert.ToString(movieDto.Year),
				Stars = movieDto.Stars
			}).Entity;
			context.SaveChanges();
			return entity;
		}
	}
}
