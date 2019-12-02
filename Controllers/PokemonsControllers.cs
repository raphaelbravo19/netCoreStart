
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace apirest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetString()
        {
            return new string[] { "Bulbasaur", "Charmander", "Squirtle", "Pikachu" };
        }
        [HttpPost]
        public ActionResult<IEnumerable<string>> PostString()
        {
            return new string[] { "Ivysaur", "Charmeleon", "Wartotle", "Raichu" };
        }
    }
}
