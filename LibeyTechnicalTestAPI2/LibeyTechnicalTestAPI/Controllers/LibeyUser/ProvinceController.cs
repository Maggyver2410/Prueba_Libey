using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibeyTechnicalTestAPI.Controllers.LibeyUser
{
    [ApiController]
    [Route("[controller]")]
    public class ProvinceController : Controller
    {
        private readonly IProvinceAggregate provinceAggregate;

        public ProvinceController(IProvinceAggregate provinceAggregate)
        {
            this.provinceAggregate = provinceAggregate;
        }

        [HttpGet("{cod}")]
        public IActionResult GetAll(string cod)
        {
            var row = provinceAggregate.GetAllByCod(cod);
            return Ok(row);
        }

    }
}
