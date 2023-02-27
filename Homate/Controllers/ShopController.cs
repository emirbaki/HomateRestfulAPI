using Homate.Data;
using Homate.Models;
using Homate.Repositories;
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

        private readonly HomateRepositoryContext _context;
        public ShopController(ILogger<ShopController> ilogger, HomateRepositoryContext context)
        {
            _ilogger = ilogger;
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllShops()
        {

            var allShops = _context.Shops;

            if(allShops.Count() == 0)
            {
                return NoContent();
            }
            return StatusCode(200, allShops);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetShopByID(int id)
        {
            var element = _context.Shops.Find(id);

            if (element is null)
            {
                return NotFound("Bulamadık la");
            }
            _ilogger.LogInformation("E bulduk aga");
            return StatusCode(200, element);
        }

        [HttpPost]
        public IActionResult SubmitShop([FromBody] Shop shop)
        {
            if (_context.Shops.Contains(shop) || _context.Shops.Any(x => x.Id == shop.Id))
            {
                return BadRequest("Bu Shop halihazırda var");
            }
            else
            {
                _context.Shops.Add(shop);
                _context.SaveChanges();
                return StatusCode(200, shop);

            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateShop(int id, [FromBody] Shop shop)
        {
            var element = _context.Shops.Find(id);
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
            _context.SaveChanges();

            return StatusCode(200, element);
        }

        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateShop([FromRoute] int id, [FromBody] JsonPatchDocument<Shop> document)
        {
            var element = _context.Shops.Find(id);

            if(element is null)
            {
                return NotFound("Bulamadık la");
            }
            document.ApplyTo(element);
            _context.SaveChanges();
            return StatusCode(200);
        }


        [HttpDelete("{id:int}")]
        public IActionResult DeleteShopByID(int id)
        {
            var element = _context.Shops.Find(id);
            if (element is null)
            {
                return NotFound("Bulamadık la");
            }
            else
            {
                _context.Shops.Remove(element);
                _context.SaveChanges();
            }
            return StatusCode(200, element);
        }
    }
}
