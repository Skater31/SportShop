using Microsoft.AspNetCore.Mvc;
using ShopServer.Models;
using ShopServer.Services;

namespace ShopServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShopController : Controller
    {
        private readonly ShopService _shopService;

        public ShopController(ShopService shopService)
        {
            _shopService = shopService;
        }

        [HttpPost]
        public async Task<Shop> GetShop([FromBody] string authentication)
        {
            try
            {
                var auth = authentication.Split('~');

                return _shopService.GetShop(auth[0], auth[1]);
            }
            catch
            {
                return new Shop();
            }
        }
    }
}
