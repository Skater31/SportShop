using SportShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net;

namespace SportShop.Services
{
    public class SportItemService : ISportItemService
    {
        private const string _uri = "https://localhost:7009/sportItem";

        private readonly HttpClient _httpClient;

        public SportItemService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<IEnumerable<SportItem>> Find(string value)
        {
            var valueSerialize = JsonConvert.SerializeObject(value);

            var content = new StringContent(valueSerialize, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_uri + "/find", content);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var sportItems = JsonConvert.DeserializeObject<IEnumerable<SportItem>>(responseContent);

                return sportItems;
            }

            return Enumerable.Empty<SportItem>();
        }

        public async Task<IEnumerable<SportItem>> GetCatalog(int shopId)
        {
            var shopIdSerialize = JsonConvert.SerializeObject(new ShopId { Id = shopId});

            var content = new StringContent(shopIdSerialize, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_uri + "/getCatalog", content);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var sportItems = JsonConvert.DeserializeObject<IEnumerable<SportItem>>(responseContent);

                return sportItems;
            }

            return Enumerable.Empty<SportItem>();
        }

        public async void Add(SportItem sportItem)
        {
            var sportItemSerialize = JsonConvert.SerializeObject(sportItem);

            var content = new StringContent(sportItemSerialize, Encoding.UTF8, "application/json");

            await _httpClient.PostAsync(_uri + "/add", content);
        }

        public async void Edit(SportItem sportItem)
        {
            var sportItemSerialize = JsonConvert.SerializeObject(sportItem);

            var content = new StringContent(sportItemSerialize, Encoding.UTF8, "application/json");

            await _httpClient.PostAsync(_uri + "/edit", content);
        }
    }
}
