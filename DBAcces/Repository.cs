using System.Data.SqlClient;
using WebApp1.Models;

namespace WebApp1.DBAcces
{
    public class Repository
    {
        public string ConnectionString { get; set; } = "";

        public Movie GetMovieById(long movieId)
        {
            Movie movie = null;
            try
            {
                string query = @$"select *
                                   from movies.movie
                                   where id={movieId}";

                var parameters = new List<SqlParameter>();
                using var connection = new SqlConnection(ConnectionString);
                connection.Open();
                using var sqlCommand = new SqlCommand(query, connection);

                var datareader = sqlCommand.ExecuteReader();

                while (datareader.Read())
                {
                    movie = new Movie();
                    movie.Id = Convert.ToInt64(datareader["id"]);
                    movie.Title = Convert.ToString(datareader["title"]);
                    movie.Director = Convert.ToString(datareader["director"]);
                    movie.Stars = Convert.ToInt32(datareader["stars"]);

                }
            }
            catch (Exception ex)
            {

            }

            return movie;
        }

        public bool InsertPaymentAttempt(Movie movie)
        {
            bool value = false;

            var query = @$"insert into Movie
                          title, director, stars, year values (
                         {movie.Title},{movie.Director},{movie.Stars}, {movie.Year})";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        value = command.ExecuteNonQuery() > 0;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                connection.Close();
            }

            return value;
        }
    }
}
