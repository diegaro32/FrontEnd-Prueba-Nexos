using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Presentation.Models;
using Presentation.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Services
{
    public class Autor_Api : IAutor_Api
    {
        private static string _baseURL;

        public Autor_Api()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appSettings.json").Build();
            _baseURL = builder.GetSection("ApiSettings:baseURL").Value;
        }

        public async Task<List<Autor>> GetAutors()
        {
            List<Autor> autorList = new List<Autor>();
            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseURL);
            var response = await client.GetAsync("/Autors");
            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Autor>>(json_respuesta);
                autorList = resultado;
            }

            return autorList;
        }

        public async Task<bool> CreateAutor(Autor autor)
        {
            bool IsCorrect = false;
            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseURL);

            var content = new StringContent(JsonConvert.SerializeObject(autor), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/Autors", content);
            if (response.IsSuccessStatusCode)
            {
                IsCorrect = true;
            }

            return IsCorrect;
        }
    }
}
