using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Models;
using Data.RepositoriesAbstractions;
using Services.Dtos;
using Services.ServicesAbstractions;

namespace Services.ConcreteServices
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task Create(Contact contato)
        {
            await _contactRepository.CreateAsync(contato);
        }

        public async Task<List<ContactResponseDto>> GetAll()
        {
            var listaDeContatos = await _contactRepository.GetAllAsync();

            var listaDeDtosDeContatos = new List<ContactResponseDto>();

            foreach (var contato in listaDeContatos)
            {
                listaDeDtosDeContatos.Add(
                    new ContactResponseDto()
                    {
                        Id = contato.Id,
                        Nome = contato.Nome,
                        Idade = contato.Idade
                    }
                );
            }

            return listaDeDtosDeContatos;
        }

        public async Task Update(int id, Contact contato)
        {
           await _contactRepository.UpdateAsync(id, contato);
        }

        public async Task Delete(int id)
        {
            await _contactRepository.DeleteAsync(id);
        }
    }
}