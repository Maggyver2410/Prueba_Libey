using AutoMapper;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibeyTechnicalTestAPI.Controllers.LibeyUser
{

    [ApiController]
    [Route("[controller]")]
    public class RegionController : Controller
    {
        private readonly IRegionAggregate _aggregate;    

        public RegionController(IRegionAggregate aggregate)
        {    
            this._aggregate = aggregate;
        
        }

        // GET: RegionController
        [HttpGet]
        public IActionResult GetAll()
        {
            var row = _aggregate.GetAll();
            return Ok(row);
        }

    }
}
