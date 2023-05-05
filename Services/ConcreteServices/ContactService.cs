using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Models;
using Data.RepositoriesAbstractions;
using Services.ServicesAbstractions;
using Utils.Dtos.Contact;

namespace Services.ConcreteServices
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IUserRepository _userRepository;

        public ContactService(IContactRepository contactRepository, IUserRepository userRepository)
        {
            _contactRepository = contactRepository;
            _userRepository = userRepository;
        }

        public async Task Create(CreateContactRequestDto createContactDto)
        {
            var existingUser = _userRepository.GetById(createContactDto.UserId);

            if (existingUser != null)
            {
                var newContact = new Contact()
                {
                    Name = createContactDto.Name,
                    Phone = createContactDto.Phone,
                    UserId = createContactDto.UserId,
                    CreatedAt = DateTime.Now
                };

                _contactRepository.Create(newContact);

                await _contactRepository.SaveChangesAsync();
            }
        }

        public async Task<List<ContactResponseDto>> GetAll()
        {
            var contacts = await _contactRepository.GetAllAsync();

            var contactDtos = new List<ContactResponseDto>();

            foreach (var contact in contacts)
            {
                contactDtos.Add(
                    new ContactResponseDto()
                    {
                        Id = contact.Id,
                        Name = contact.Name,
                        Phone = contact.Phone,
                        UserId = contact.UserId
                    }
                );
            }

            return contactDtos;
        }

        public async Task Update(int contactId, CreateContactRequestDto contato)
        {
            var existingContact = _contactRepository.GetById(contactId);

            if (existingContact != null)
            {
                existingContact.Name = contato.Name;
                existingContact.Phone = contato.Phone; 
                existingContact.UpdatedAt = DateTime.Now;

                _contactRepository.Update(existingContact);

                await _contactRepository.SaveChangesAsync();
            }
        }

        public async Task Delete(int contactId)
        {
            var existingContact = _contactRepository.GetById(contactId);

            if (existingContact != null)
            {
                _contactRepository.Delete(existingContact);

                await _contactRepository.SaveChangesAsync();
            }
        }
    }
}