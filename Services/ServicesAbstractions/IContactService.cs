using System.Collections.Generic;
using System.Threading.Tasks;
using Utils.Dtos;

namespace Services.ServicesAbstractions
{
    public interface IContactService
    {
        public Task Create(ContactRequestDto contato);
        public Task<List<ContactResponseDto>> GetAll();
        public Task Update(int id, ContactRequestDto contato);
        public Task Delete(int id);
    }
}