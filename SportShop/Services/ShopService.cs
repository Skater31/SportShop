using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SportShop.Models;
using Newtonsoft.Json;
using MaterialDesignThemes.Wpf;
using System.Windows;

namespace SportShop.Services
{
    public class ShopService : IShopService
    {
        private const string _uri = "https://localhost:7009/shop";

        private readonly HttpClient _httpClient;

        public ShopService()
        {
            _httpClient = new HttpClient();
        }
        
        public async Task<Shop> GetShop(string authentication)
        {
            if (IsCorrectAuthorization(ref authentication))
            {
                var authSerialize = JsonConvert.SerializeObject(authentication);

                var content = new StringContent(authSerialize, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(_uri, content);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    var shop = JsonConvert.DeserializeObject<Shop>(responseContent);

                    return shop;
                }
            }

            return null;
        }

        private bool IsCorrectAuthorization(ref string authentication)
        {
            var auth = authentication.Split('~');

            if (string.IsNullOrEmpty(auth[0]) || string.IsNullOrEmpty(auth[1]))
            {
                return false;
            }

            return true;
        }
    }
}
