using AutoMapper;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;

namespace LibeyTechnicalTestAPI.Controllers.LibeyUser
{
    [ApiController]
    [Route("[controller]")]
    public class LibeyUserController : Controller
    {
        private readonly ILibeyUserAggregate _aggregate;
        private readonly IMapper mapper;

        public LibeyUserController(ILibeyUserAggregate aggregate, IMapper mapper)
        {
            _aggregate = aggregate;
            this.mapper = mapper;
        }

        [HttpGet]        
        public IActionResult GetAll()
        {
            var row = _aggregate.GetAll();
            return Ok(row);
        }


        [HttpGet]
        [Route("{documentNumber}")]
        public IActionResult FindResponse(string documentNumber)
        {
            var row = _aggregate.FindResponse(documentNumber);
            return Ok(row);

        }

        [HttpPost] 
        public IActionResult Create(UserUpdateorCreateCommand command)
        {            
            // _aggregate.Create(command);       
            _aggregate.Create(command);
            return Ok(true);
        }

        [HttpPut]
        public IActionResult Update(UserUpdateorCreateCommand command)
        {       
            _aggregate.Update(command);
            return Ok(true);
        }

        [HttpDelete("{documentNumber}")]
        public IActionResult Delete(string documentNumber)
        {
            _aggregate.Delete(documentNumber);
            return Ok(true);
        }

        [HttpGet("documentType")]
        public IActionResult GetDocumentType()
        {
            var row = _aggregate.GetDocumentType();
            return Ok(row);
        }

    }
}