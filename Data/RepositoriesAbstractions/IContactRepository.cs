using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Models;

namespace Data.RepositoriesAbstractions
{
    public interface IContactRepository
    {
        Task CreateAsync(Contact contact);
        Task<IEnumerable<Contact>> GetAllAsync();
        Task<Contact> GetByIdAsync(int id);
        Task UpdateAsync(int id, Contact contact);
        Task DeleteAsync(int id);
    }
}