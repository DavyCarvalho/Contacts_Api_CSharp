using Data.DatabaseConnection.EntityMapping;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.DatabaseConnection
{
    public class ContactsDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        public ContactsDbContext(DbContextOptions<ContactsDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ContactConfiguration());
        }
    }
}