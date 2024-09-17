using AutoMapper;
using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Infrastructure
{
    public class ProvinceRepository : IProvinceRepository
    {
        private readonly Context context;
        private readonly IMapper mapper;

        public ProvinceRepository(Context context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public List<ProvinceResponses> GetAllByCod(string provinceCode) { 
     
            var province = context.Province.Where(x => x.RegionCode.Equals(provinceCode));
 
            var lista = mapper.Map<List<ProvinceResponses>>(province);

            return lista;
        }
    }
}
