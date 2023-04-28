using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.DatabaseConnection;
using Data.Models;
using Data.RepositoriesAbstractions;
using Microsoft.EntityFrameworkCore;

namespace Data.ConcreteRepositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ContactsDbContext _context;

        public UserRepository(ContactsDbContext context)
        {
            _context = context;
        }

        public void Create(User newUser)
        {
            _context.Users.Add(newUser);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.Include(u => u.Contacts).ToListAsync();
        }

        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(c => c.Id == id);
        }

        
        public User GetByEmailAndPassword(string email, string password)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }

        public void Update(User updatedUser)
        {
            _context.Users.Update(updatedUser);
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
        }

        public async Task SaveChangesAsync() 
        {
            await _context.SaveChangesAsync();
        }
    }
}