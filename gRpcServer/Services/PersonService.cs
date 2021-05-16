using System;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MongoDB.Bson;
using NoSql.DataAccess;
using Person;

namespace gRpcServer.Services
{
    public class PersonService : global::Person.PersonService.PersonServiceBase
    {
        private readonly IMongoBaseRepository<NoSql.Core.Domain.Person> _personRepository;

        public PersonService(IMongoBaseRepository<NoSql.Core.Domain.Person> personRepository)
        {
            _personRepository = personRepository;
        }

        public override async Task<AddPersonResponse> AddPerson(AddPersonRequest request, ServerCallContext context)
        {
            await _personRepository.InsertOneAsync(new NoSql.Core.Domain.Person(request.Firstname, request.Lastname, request.Dob == null
                ? default(DateTime) : request.Dob.ToDateTime()){});

            return await Task.FromResult(new AddPersonResponse() {Success = true});
        }

        public override async Task<GetPersonsResponse> GetPersons(Empty request, ServerCallContext context)
        {
            var people = await _personRepository.FilterByAsync(_ => true
              , p => new PersonsDto
                {
                    DateOfBirth = p.BirthDate.ToTimestamp(),
                    Firstname = p.FirstName, 
                    Lastname = p.LastName
                });

            var response = new GetPersonsResponse();
            response.People.AddRange(people);

            return await Task.FromResult(response);
        }
    }
}