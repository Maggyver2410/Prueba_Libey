using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application
{
    public class UbigeoAggregate : IUbigeoAggregate
    {
        private readonly IUbigeoRepository ubigeoRepository;

        public UbigeoAggregate(IUbigeoRepository ubigeoRepository)
        {
            this.ubigeoRepository = ubigeoRepository;
        }

        public List<UbigeoResponses> GetAllByCod(string provinceCod)
        {
            var row = ubigeoRepository.GetAllByCod(provinceCod);
            return row;
        }
    }
}
