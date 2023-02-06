using ClientSeries.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClientSeries.Services
{
    public class WSService : IService
    {
        private HttpClient client;

        public WSService(string app)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(app);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Serie>> GetSeriesAsync()
        {
            try
            {
                return await client.GetFromJsonAsync<List<Serie>>("/api/series");
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Serie> GetSerieAsync(int id)
        {
            return await client.GetFromJsonAsync<Serie>($"/api/series/{id}");
        }

        public async Task<HttpResponseMessage> DeleteSerieAsync(int id)
        {
            using var response = await client.DeleteAsync($"/api/series/{id}");

            if (response.IsSuccessStatusCode)
            {
                return response;
            }
            else
            {
                return null;
            }
        }

        public async Task<HttpResponseMessage> PostSerieAsync(Serie serie)
        {
            using var response = await client.PostAsJsonAsync("/api/series", serie);
            if (response.IsSuccessStatusCode)
            {
                return response;
            }
            else
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.NotModified);
            }
        }

        public async Task<HttpResponseMessage> PutSerieAsync(Serie serie, int id)
        {
            using var response = await client.PostAsJsonAsync($"/api/series/{id}", serie);
            if (response.IsSuccessStatusCode)
            {
                return response;
            }
            else
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.NotModified);
            }
        }
    }
}
