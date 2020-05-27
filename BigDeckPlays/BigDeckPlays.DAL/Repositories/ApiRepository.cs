using System;
using System.Net.Http;
using Newtonsoft.Json;

namespace BigDeckPlays.DAL.Repositories
{
    public interface IApiRepository
    {
        T Get<T>(string url);
    }
    
    public class ApiRepository : IApiRepository
    {
        public T Get<T>(string url)
        {
            var rawdata = "";
            try
            {
                var client = new HttpClient();
                var res = client.GetAsync(url).Result;
                var content = res.Content;

                rawdata = content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<T>(rawdata);

                return data;
            }
            catch(Exception e)
            {
                Console.WriteLine(rawdata);
                throw e;
            }
        }
    }
}
