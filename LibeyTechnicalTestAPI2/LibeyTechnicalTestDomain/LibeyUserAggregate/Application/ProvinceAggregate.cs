using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application
{
    public class ProvinceAggregate : IProvinceAggregate
    {
        private readonly IProvinceRepository provinceRepository;

        public ProvinceAggregate(IProvinceRepository provinceRepository)
        {
            this.provinceRepository = provinceRepository;
        }

        public List<ProvinceResponses> GetAllByCod(string provinceCod)
        {
            var row = provinceRepository.GetAllByCod(provinceCod);
            return row;
        }
    }
}
