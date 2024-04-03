using Microsoft.AspNetCore.Mvc;

namespace VendasMedicamentos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public string Index()
        {
            return "Home da API";
        }
    }
}
