using Microsoft.AspNetCore.Mvc;
using WebApp1.DBAcces;
using WebApp1.Extensions;
using WebApp1.Models;

namespace WebApp1.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class HomeController : ControllerBase
	{
		private readonly string movieKey = "__movieKey";
		protected Movie Movie
		{
			get
			{
				return HttpContext.Session.Get<Movie>(movieKey);
			}
			set
			{
				HttpContext.Session.Set(movieKey, value);
			}
		}

		private readonly IRepository repository;
		public HomeController(IRepository repository)
		{
			this.repository = repository;
		}

		[HttpGet("getMovieById/{id}")]
		public IActionResult Get(long id)
		{
			var x = Movie;

			var movie = this.repository.GetMovieById(id);
			if (movie == null)
				return NotFound();
			return Ok(movie);
		}

		[HttpPost("postMovie")]
		public IActionResult Post(MovieDto movie)
		{
			var entity = this.repository.InsertMovie(movie);
			Movie = entity;
			return Ok(entity);
		}
	}
}
