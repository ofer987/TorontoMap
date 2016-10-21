using Microsoft.AspNetCore.Mvc;

using TorontoMap.Models;

namespace TorontoMap.Controllers
{
    [Route("api/[controller]")]
    public class PlayerController : Controller
    {
        [HttpPost]
        public int Create([FromBody] Models.Player player)
        {
            return 2;
        }
    }


}
