using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Models;
using Services.Dtos;

namespace Services.ServicesAbstractions
{
    public interface IContactService
    {
        public Task Create(Contact contato);
        public Task<List<ContactResponseDto>> GetAll();
        public Task Update(int id, Contact contato);
        public Task Delete(int id);
    }
}