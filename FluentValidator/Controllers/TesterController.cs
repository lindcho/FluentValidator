using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using FluentValidator.Models;
using FluentValidator.Models.FluentValidators;
using FluentValidator.Models.Models;

namespace FluentValidator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TesterController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(Tester tester)
        {
            var validator = new TesterValidator();
            //var tester = new Tester
            //{
            //    FirstName = "",
            //    Email = "bla!"
            //};
            var validationResult = validator.Validate(tester);
            var response = new ResponseModel();
            if (validationResult.IsValid) return Ok(response);
            response.IsValid = false;
            var validationMessages = validationResult.Errors.Select(failure => failure.ErrorMessage).ToList();
            response.ValidationMessages = validationMessages;
            return Ok(response);
        }
    }
}
