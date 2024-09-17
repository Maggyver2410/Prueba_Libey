using AutoMapper;
using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using Microsoft.AspNetCore.Mvc.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Xml.Linq;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Infrastructure

{
    public class LibeyUserRepository : ILibeyUserRepository
    {
        private readonly Context _context;
        private readonly IMapper mapper;

        public LibeyUserRepository(Context context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

 
        public void Create(LibeyUser libeyUser)
        {
            _context.LibeyUsers.Add(libeyUser);
            _context.SaveChanges();
        }
        public LibeyUserResponse FindResponse(string documentNumber)
        {
            var libeySql = from libeyUser in _context.LibeyUsers.Where(x => x.DocumentNumber.Equals(documentNumber))
                    select new LibeyUserResponse()
                    {
                        DocumentNumber = libeyUser.DocumentNumber,
                        Active = libeyUser.Active,
                        Address = libeyUser.Address,
                        DocumentTypeId = libeyUser.DocumentTypeId,
                        Email = libeyUser.Email,
                        FathersLastName = libeyUser.FathersLastName,
                        MothersLastName = libeyUser.MothersLastName,
                        Name = libeyUser.Name,
                        Password = libeyUser.Password,
                        Phone = libeyUser.Phone,
                        UbigeoCode = libeyUser.UbigeoCode,
                        ProvinceCode = (from province in _context.Ubigeo
                                        where province.UbigeoCode == libeyUser.UbigeoCode
                                        select province.ProvinceCode).First().ToString(),
                        RegionCode = (from region in _context.Ubigeo
                                      where region.UbigeoCode == libeyUser.UbigeoCode
                                      select region.RegionCode).First().ToString()
                    };
            var list = libeySql.ToList();

            if (list.Any()) 
                return list.First();
            else 
                return new LibeyUserResponse();
        }
        public void Update(LibeyUser libeyUser)
        {
            var LibeyUserResponse = _context.LibeyUsers.Any(x => x.DocumentNumber.Equals(libeyUser.DocumentNumber));

            try
            {
                _context.LibeyUsers.Update(libeyUser);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("User not found");
            }           
        }
        public void Delete(string documentNumber)
        {
        
            var rowFound = _context.LibeyUsers.SingleOrDefault(x => x.DocumentNumber == documentNumber);
            //var rowFound2 = _context.LibeyUsers.FirstOrDefault(x => x.DocumentNumber == documentNumber);    

            try
            {      
                _context.Remove(rowFound);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("User not found");
            }
        }
        public List<LibeyUserResponse> GetAll()
        {
            var libeySql = from libeyUser in _context.LibeyUsers
                           select new LibeyUserResponse()
                           {
                               DocumentNumber = libeyUser.DocumentNumber,
                               Active = libeyUser.Active,
                               Address = libeyUser.Address,
                               DocumentTypeId = libeyUser.DocumentTypeId,
                               Email = libeyUser.Email,
                               FathersLastName = libeyUser.FathersLastName,
                               MothersLastName = libeyUser.MothersLastName,
                               Name = libeyUser.Name,
                               Password = libeyUser.Password,
                               Phone = libeyUser.Phone,
                               UbigeoCode = libeyUser.UbigeoCode,
                               ProvinceCode = (from province in _context.Ubigeo
                                               where province.UbigeoCode == libeyUser.UbigeoCode
                                               select province.ProvinceCode).First().ToString(),
                               RegionCode = (from region in _context.Ubigeo
                                             where region.UbigeoCode == libeyUser.UbigeoCode
                                             select region.RegionCode).First().ToString(),
                               DocumentTypeDescription = (from document in _context.DocumentType
                                                          where document.DocumentTypeId == libeyUser.DocumentTypeId
                                                          select document.DocumentTypeDescription).First().ToString(),
                           };


            return libeySql.ToList();
        }
        public  List<DocumentType> GetDocumentType()
        {
            return  _context.DocumentType.ToList();
        }

    }
}