using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Models;
using Utils.Dtos;

namespace Data.RepositoriesAbstractions
{
    public interface IContactRepository
    {
        Task CreateAsync(ContactRequestDto contact);
        Task<IEnumerable<Contact>> GetAllAsync();
        Task<Contact> GetByIdAsync(int id);
        Task UpdateAsync(int id, ContactRequestDto contact);
        Task DeleteAsync(int id);
    }
}