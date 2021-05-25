using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Newsy.App.DataAccess
{
    class DailyNews
    {
        readonly HttpClient client = new HttpClient();

        public async Task<Model.DailyNews[]> LoadNews()
        {
            string json =
                await client.GetStringAsync(
                    "http://newsapi.org/v2/top-headlines?country=no&apiKey=ebba72b634e64465a4990fcdd39dfbb1");
            var news = JsonConvert.DeserializeObject<Model.DailyNews[]>(json);

            return news;
        }



    }
}
