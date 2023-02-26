using Homate.Data;
using Homate.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Xml.Linq;

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

            if (a is null)
            {
                return NotFound("Bulamadık la");
            }
            _ilogger.LogInformation("E bulduk aga");
            return StatusCode(200, a);
        }

        [HttpPost]
        public IActionResult SubmitShop([FromBody] Shop shop)
        {
            if (Shops.shops.Contains(shop) || Shops.shops.Any(x => x.Id == shop.Id))
            {
                return BadRequest("Bu Shop halihazırda var");
            }
            else
            {
                Shops.shops.Add(shop);
                return StatusCode(200, shop);

            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateShop(int id, [FromBody] Shop shop)
        {
            var element = Shops.shops.Find(x => x.Id == id);
            if (id != shop.Id)
            {
                return BadRequest("Headerdaki ID ile Body'deki ID uyuşmuyor");
            }
            else if(element is null)
            {
                return NotFound("Bulamadık la");
            }

            element.Id = shop.Id;
            element.Name = shop.Name;
            element.Description = shop.Description;

            return StatusCode(200, element);
        }

        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateShop([FromRoute] int id, [FromBody] JsonPatchDocument<Shop> document)
        {
            var element = Shops.shops.Find(x => x.Id == id);

            if(element is null)
            {
                return NotFound("Bulamadık la");
            }
            document.ApplyTo(element);
            return StatusCode(200);
        }


        [HttpDelete("{id:int}")]
        public IActionResult DeleteShopByID(int id)
        {
            var element = Shops.shops.Find(x => x.Id == id);
            if (element is null)
            {
                return NotFound("Bulamadık la");
            }
            else
            {
                Shops.shops.Remove(element);
            }
            return StatusCode(200, element);
        }
    }
}
