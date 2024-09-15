using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibeyTechnicalTestAPI.Controllers.LibeyUser
{
    [ApiController]
    [Route("[controller]")]
    public class UbigeoController : Controller
    {
        private readonly IUbigeoAggregate ubigeoAggregate;

        public UbigeoController(IUbigeoAggregate ubigeoAggregate)
        {
            this.ubigeoAggregate = ubigeoAggregate;
        }

        [HttpGet("{cod}")]
        public IActionResult GetAll(string cod)
        {
            var row = ubigeoAggregate.GetAllByCod(cod);
            return Ok(row);
        }
    }
}
