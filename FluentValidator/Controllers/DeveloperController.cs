using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using FluentValidator.Models;

namespace FluentValidator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeveloperController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(Developer developer)
        {
            return Ok();
        }
    }
}
