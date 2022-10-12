using Microsoft.AspNetCore.Mvc;
using RestSharp;
using WebApp1.Models;

namespace WebApp1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {

        [HttpGet("getAllMovies")]
        public IActionResult Get()
        {
            var client = new RestClient();
            var request = new RestRequest("http://localhost:8080/home/movies", Method.Get);
            var response = client.Execute(request);
            return Ok(response.Content);
        }

        [HttpPost("postMovie")]
        public IActionResult Post(Movie movie)
        {
            var client = new RestClient();
            var request = new RestRequest("http://localhost:8080/home/addMovie", Method.Post);
            request.AddJsonBody(movie);
            var response = client.Execute(request);
            return Ok(response.StatusCode);
        }
    }
}
