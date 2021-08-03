using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HttpClientSample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient client = new();

            Console.WriteLine("--- Kann ich Starten [KeyPress]---");
            Console.ReadKey();

            string url = "https://localhost:5001/api/Movie/GetAll";
            HttpRequestMessage httpRequestMessage = new(HttpMethod.Get, url);
            httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
            HttpResponseMessage response = await client.SendAsync(httpRequestMessage); //Get, POST, PUT, DELETE
            string xmlString = await response.Content.ReadAsStringAsync();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
            HttpResponseMessage response1  = await client.GetAsync(url);
            string resultString = await response1.Content.ReadAsStringAsync();

            //List<Movie> movieList = JsonConvert.DeserializeObject<List<Movie>>(jsonString);

            //foreach (Movie movie in movieList)
            //{
            //    Console.WriteLine($"{movie.Title}");
            //}

            Console.Write(xmlString);

            Console.ReadKey();
        }
    }

    //Bitte nicht nachmachen :-) 
    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Genre Genre { get; set; }

        public decimal Price { get; set; }
    }

    public enum Genre { Action = 1, Thriller, Comedy, Horror, Animations, Drama, Romance, Documentation }
}
