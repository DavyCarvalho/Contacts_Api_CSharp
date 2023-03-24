using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.DatabaseConnection;
using Data.Models;
using Data.RepositoriesAbstractions;
using Microsoft.EntityFrameworkCore;

namespace Data.ConcreteRepositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactsDbContext _context;

        public ContactRepository(ContactsDbContext context)
        {
            _context = context;
        }

        public void Create(Contact newContact)
        {
            _context.Contacts.Add(newContact);
        }

        public async Task<IEnumerable<Contact>> GetAllAsync()
        {
            return await _context.Contacts.ToListAsync();
        }

        public Contact GetById(int id)
        {
            return _context.Contacts.FirstOrDefault(c => c.Id == id);
        }

        public void Update(Contact updatedContact)
        {
            _context.Contacts.Update(updatedContact);
        }

        public void Delete(Contact contact)
        {
            _context.Contacts.Remove(contact);
        }

        public async Task SaveChangesAsync() 
        {
            await _context.SaveChangesAsync();
        }
    }
}