using System.Collections.Generic;
using System.Threading.Tasks;
using Data.RepositoriesAbstractions;
using Services.ServicesAbstractions;
using Utils.Dtos;

namespace Services.ConcreteServices
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task Create(ContactRequestDto contato)
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

        public async Task Update(int id, ContactRequestDto contato)
        {
           await _contactRepository.UpdateAsync(id, contato);
        }

        public async Task Delete(int id)
        {
            await _contactRepository.DeleteAsync(id);
        }
    }
}