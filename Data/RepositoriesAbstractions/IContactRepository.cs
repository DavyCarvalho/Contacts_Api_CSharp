using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Models;

namespace Data.RepositoriesAbstractions
{
    public interface IContactRepository
    {
        void Create(Contact newContact);
        Task<IEnumerable<Contact>> GetAllAsync();
        Contact GetById(int id);
        void Update(Contact updatedContact);
        void Delete(Contact contact);
        Task SaveChangesAsync();
    }
}