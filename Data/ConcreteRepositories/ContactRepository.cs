using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Data.Models;
using Data.RepositoriesAbstractions;

namespace Data.ConcreteRepositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly IDbConnection _dbConnection;

        public ContactRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task CreateAsync(Contact contact)
        {
            
        }

        public async Task<IEnumerable<Contact>> GetAllAsync()
        {
           
        }

        public async Task<Contact> GetByIdAsync(int id) 
        {
            
        }

        public async Task UpdateAsync(int id, Contact contact) 
        {

        }

        public async Task DeleteAsync(int id) 
        {

        }
    }
    
}