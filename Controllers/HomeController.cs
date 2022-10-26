using Microsoft.AspNetCore.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using WebApp1.DBAcces;
using WebApp1.Models;

namespace WebApp1.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class HomeController : ControllerBase
	{

		[HttpGet("getMovieById/{id}")]
		public IActionResult Get(long id)
		{
			var repository = new Repository();
			var movie = repository.GetMovieById(id);
			return Ok(movie);
		}

		[HttpPost("postMovie")]
		public IActionResult Post(MovieDto movie)
		{
			var repository = new Repository();
			repository.InsertMovie(movie);
			return Ok(movie);
		}
	}
}
