using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;

namespace LibeyTechnicalTestDomain.Utilidades
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles() {

            CreateMap<LibeyUser, UserUpdateorCreateCommand>();
            CreateMap<UserUpdateorCreateCommand, LibeyUser>();


            CreateMap<LibeyUser, LibeyUserResponse>();
            CreateMap<Region, RegionResponses>();
            CreateMap<Province, ProvinceResponses>();
            CreateMap<Ubigeo, UbigeoResponses>();
        }
    }
    
}
