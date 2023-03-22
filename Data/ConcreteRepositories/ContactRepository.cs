using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Data.Models;
using Data.RepositoriesAbstractions;
using Utils.Dtos;

namespace Data.ConcreteRepositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly IDbConnection _dbConnection;

        public ContactRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task CreateAsync(ContactRequestDto contact)
        {
            var query = @"
                INSERT INTO Contact (Nome, Idade, CreatedAt)
                VALUES (@Nome, @Idade, @CreatedAt)
            ";
            var parameters = new DynamicParameters();
            parameters.Add("@Nome", contact.Nome);
            parameters.Add("@Idade", contact.Idade);
            parameters.Add("@CreatedAt", DateTime.Now.ToString());
            await _dbConnection.ExecuteAsync(query, parameters);
        }

        public async Task<IEnumerable<Contact>> GetAllAsync()
        {
            var query = "SELECT * FROM Contact";
            
            return await _dbConnection.QueryAsync<Contact>(query);
        }

        public async Task<Contact> GetByIdAsync(int id)
        {
            var query = "SELECT * FROM Contact WHERE Id = @Id";

            var parameters = new DynamicParameters();

            parameters.Add("@Id", id);

            return await _dbConnection.QueryFirstOrDefaultAsync<Contact>(query, parameters);
        }

        public async Task UpdateAsync(int id, ContactRequestDto contact)
        {
            var query = @"
                UPDATE Contact
                SET Nome = @Nome, Idade = @Idade, UpdatedAt = @UpdatedAt
                WHERE Id = @Id
            ";

            var parameters = new DynamicParameters();

            parameters.Add("@Nome", contact.Nome);
            parameters.Add("@Idade", contact.Idade);
            parameters.Add("@UpdatedAt", DateTime.Now.ToString());
            parameters.Add("@Id", id);

            await _dbConnection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteAsync(int id)
        {
            var query = "DELETE FROM Contact WHERE Id = @Id";

            var parameters = new DynamicParameters();

            parameters.Add("@Id", id);

            await _dbConnection.ExecuteAsync(query, parameters);
        }
    }
}