using ClientSeries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClientSeries.Services
{
    public interface IService
    {
        Task<List<Serie>> GetSeriesAsync();
        Task<Serie> GetSerieAsync(int id);
        Task<HttpResponseMessage> DeleteSerieAsync(int id);
        Task<HttpResponseMessage> PutSerieAsync(Serie serie, int id);
        Task<HttpResponseMessage> PostSerieAsync(Serie serie);
    }
}
