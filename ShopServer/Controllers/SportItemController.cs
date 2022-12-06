using Microsoft.AspNetCore.Mvc;
using ShopServer.Models;
using ShopServer.Services;

namespace ShopServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SportItemController : Controller
    {
        private readonly SportItemService _sportItemService;

        public SportItemController(SportItemService sportItemService)
        {
            _sportItemService = sportItemService;
        }

        [HttpPost]
        [Route("find")]
        public IEnumerable<SportItem> Find([FromBody] string value)
        {
            try
            {
                return _sportItemService.Find(value);
            }
            catch
            {
                return Enumerable.Empty<SportItem>();
            }
        }

        [HttpPost]
        [Route("getCatalog")]
        public IEnumerable<SportItem> GetCatalog(ShopId shopId)
        {
            try
            {
                return  _sportItemService.GetCatalog(shopId.Id);
            }
            catch
            {
                return Enumerable.Empty<SportItem>();
            }
        }

        [HttpPost]
        [Route("add")]
        public void Add(SportItem sportItem)
        {
            _sportItemService.Add(sportItem);
        }

        [HttpPost]
        [Route("edit")]
        public void Edit(SportItem sportItem)
        {
            _sportItemService.Edit(sportItem);
        }
    }
}
