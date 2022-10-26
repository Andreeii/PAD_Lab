using Microsoft.AspNetCore.Mvc;
using RestSharp;
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
            var x = repository.GetMovieById(1);
            return Ok(x);
        }

        [HttpPost("postMovie")]
        public IActionResult Post(Movie movie)
        {
            var repository = new Repository();

            return Ok(movie);
        }
    }
}
