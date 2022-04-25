using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using Presentation.Services.Interfaces;
using Presentation.Models;
using System.Net.Http;
using System.Text;

namespace Presentation.Services
{
    public class Book_Api : IBook_Api
    {
        private static string _baseURL;

        public Book_Api()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appSettings.json").Build();
            _baseURL = builder.GetSection("ApiSettings:baseURL").Value;
        }
       
        public async Task<List<Book>> GetBooks()
        {
            List<Book> bookList = new List<Book>();
            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseURL);
            var response = await client.GetAsync("/Books");
            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Book>>(json_respuesta);
                bookList = resultado;
            }

            return bookList;
        }

        public async Task<bool> CreateBook(Book book)
        {
            bool IsCorrect = false;
            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseURL);

            var content = new StringContent(JsonConvert.SerializeObject(book), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/Books",content);
            if (response.IsSuccessStatusCode)
            {
                IsCorrect = true;
            }

            return IsCorrect;
        }
    }
}
