using Homate.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Homate.Controllers
{
    [Route("api/shops")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly ILogger<ShopController> _ilogger;

        public ShopController(ILogger<ShopController> ilogger)
        {
            _ilogger = ilogger;
        }

        [HttpGet]
        public IActionResult GetAllShops()
        {
            var allShops = Shops.shops;

            if(allShops.Count== 0)
            {
                return NoContent();
            }
            return StatusCode(200, allShops);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetShopByID(int id)
        {
            var a = Shops.shops.Find(x => x.Id == id);
            var element = Shops.shops.Where(x => x.Id == id).FirstOrDefault();

            if (a is null)
            {
                return NotFound("Bulamadık la");
            }
            return StatusCode(200, a);
        }
    }
}
