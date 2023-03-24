using System.Collections.Generic;
using System.Threading.Tasks;
using Utils.Dtos;
using Utils.Dtos.Contact;

namespace Services.ServicesAbstractions
{
    public interface IContactService
    {
        public Task Create(CreateContactRequestDto contato);
        public Task<List<ContactResponseDto>> GetAll();
        public Task Update(int id, CreateContactRequestDto contato);
        public Task Delete(int id);
    }
}