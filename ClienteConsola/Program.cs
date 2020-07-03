using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ClienteConsola
{
    class Program
    {
        static async void GetAsync()
        {
        HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:44349/");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = httpClient.GetAsync("api/fiestas").Result;
            string result = await response.Content.ReadAsStringAsync();
            Console.WriteLine(result);
        }

        static async void PutAsync()
        {

            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:44349/");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpContent content = new StringContent("" +
                 "{ 'Id': 2," +
                 "   'Nombre': 'Fiesta Creada y editada',"+
                 "  'Fecha': '2020-06-25T00:00:00',"+
                 " 'Ubicacion': 'Nuevo',"+
                 "'PrecioEntrada': '100'" +
                 "}");

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = httpClient.PutAsync("api/fiestas",content).Result;
            string result = await response.Content.ReadAsStringAsync();
            Console.WriteLine(result);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Aprete Enter Para ver tu GET");
            Console.ReadLine();
            PutAsync();
            Console.WriteLine("Mostrando todos");

            GetAsync();
            Console.ReadKey();
        }
    }
}
