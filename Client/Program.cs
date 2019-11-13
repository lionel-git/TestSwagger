using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Common;
using Newtonsoft.Json;

namespace Client
{
    class Program
    {

        static async Task<MyData> GetMyData(int id, string name, HttpClient client)
        {
            var response = await client.GetAsync($"MyData/{id}/{name}");            
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content;               
                var s= await content.ReadAsStringAsync();
                
                var myDatas2 = JsonConvert.DeserializeObject<List<MyData>>(s);

                Console.WriteLine($"{s} => {myDatas2[0].Id}");               
            }
            return null;
        }


        static void Main(string[] args)
        {
            try
            {
                var client = new HttpClient();

                client.BaseAddress = new Uri("https://localhost:44399");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var t = GetMyData(127, "titi", client);
                t.Wait();
                Console.WriteLine(t.Result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}

