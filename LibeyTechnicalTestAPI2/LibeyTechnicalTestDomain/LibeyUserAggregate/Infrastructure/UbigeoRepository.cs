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
    public class UbigeoRepository : IUbigeoRepository
    {
        private readonly Context context;
        private readonly IMapper mapper;

        public UbigeoRepository(Context context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public List<UbigeoResponses> GetAllByCod(string provinceCode)
        {

            var ubigeoSql = context.Ubigeo.Where(x => x.ProvinceCode.Equals(provinceCode));

            var lista = mapper.Map<List<UbigeoResponses>>(ubigeoSql);

            return lista;
        }
    }
}
