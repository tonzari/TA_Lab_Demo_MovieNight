using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;


namespace TA_LAB_MovieAPI.Models
{
    public class MovieDAL
    {
        public string key = "4a45a52c";

        // let's pass in all of our search terms. Somewhere else in our program, we can collect those search terms,
        // store them in a List (of strings) and then pass them in to this method below as a parameter.
        public List<MovieModel> GetMovieList(List<string> searchTerms)
        {
            List<MovieModel> movieList = new List<MovieModel>();  // let's init a list of movies now, and then add to it in our loop

            foreach (string searchTerm in searchTerms)
            {
                // make web request to api
                string url = $@"http://www.omdbapi.com/?apikey={key}&t={searchTerm}";
                HttpWebRequest request = WebRequest.CreateHttp(url);

                // store response
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                // convert response into a string of raw JSON
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string JSON = reader.ReadToEnd();

                // convert string into an object
                MovieModel movie = JsonConvert.DeserializeObject<MovieModel>(JSON);

                // add the object to the list
                movieList.Add(movie);
            }

            return movieList;
        }
    }
}
