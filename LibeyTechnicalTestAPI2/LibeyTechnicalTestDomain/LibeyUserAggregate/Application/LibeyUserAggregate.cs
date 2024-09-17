using AutoMapper;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application
{
    public class LibeyUserAggregate : ILibeyUserAggregate
    {
        private readonly ILibeyUserRepository _repository;
        private readonly IMapper mapper;

        public LibeyUserAggregate(ILibeyUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            this.mapper = mapper;
        }
        public void Create(UserUpdateorCreateCommand command)
        {
            var map = mapper.Map<LibeyTechnicalTestDomain.LibeyUserAggregate.Domain.LibeyUser>(command);
            _repository.Create(map);
            //_repository.Create(command);
        }
        public LibeyUserResponse FindResponse(string documentNumber)
        {
            var row = _repository.FindResponse(documentNumber);
            return row;
        }

        public void Update(UserUpdateorCreateCommand command)
        {
            var map = mapper.Map<LibeyTechnicalTestDomain.LibeyUserAggregate.Domain.LibeyUser>(command);
            _repository.Update(map);
            //_repository.Create(command);
        }

        public void Delete(string documentNumber)
        {
            _repository.Delete(documentNumber);           
        }

        public List<LibeyUserResponse> GetAll()
        {
            var row = _repository.GetAll();
            return row;
        }

        public List<DocumentType> GetDocumentType()
        {
            var row = _repository.GetDocumentType();
            return row;
        }
    }
}