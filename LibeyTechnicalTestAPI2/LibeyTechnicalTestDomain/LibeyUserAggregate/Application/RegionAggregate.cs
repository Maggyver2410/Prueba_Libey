using AutoMapper;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application
{
    public class RegionAggregate : IRegionAggregate
    {
        private readonly IRegionRepository regionRepository;   

        public RegionAggregate(IRegionRepository regionRepository) {
            this.regionRepository = regionRepository;    
        }

        public List<RegionResponses> GetAll()
        {
            var row = regionRepository.GetAll();
            return row;
        }
    }
}
