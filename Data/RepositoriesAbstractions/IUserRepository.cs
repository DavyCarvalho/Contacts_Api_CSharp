using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Models;

namespace Data.RepositoriesAbstractions
{
    public interface IUserRepository
    {
        void Create(User newUser);
        Task<IEnumerable<User>> GetAllAsync();
        User GetById(int id);
        void Update(User updatedUser);
        void Delete(User user);
        Task SaveChangesAsync();
    }
}