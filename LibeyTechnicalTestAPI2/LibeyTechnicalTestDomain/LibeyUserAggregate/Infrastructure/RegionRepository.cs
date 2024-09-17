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
    public class RegionRepository : IRegionRepository
    {
        private readonly Context context;
        private readonly IMapper mapper;

        public RegionRepository(Context context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public List<RegionResponses> GetAll()
        {
            var regionSql = context.Region.ToList();
            var lista = mapper.Map<List<RegionResponses>>(regionSql);

            return lista;
        }
    }
}
