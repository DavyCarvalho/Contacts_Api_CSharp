using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Dtos;
using Services.ServicesAbstractions;

namespace ContactsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost]
        public async Task Create([FromBody] Contact contact) 
        {
            await _contactService.Create(contact);
        }

        [HttpGet]
        public async Task<List<ContactResponseDto>> Get()
        {
            return await _contactService.GetAll();
        }

        [HttpPut("{id}")]
        public async Task Update([FromRoute] int id, [FromBody] Contact updatedContact) 
        {
            await _contactService.Update(id, updatedContact);
        }

        [HttpDelete("{id}")]
        public async Task Delete([FromRoute] int id)
        {
            await _contactService.Delete(id);
        }
    }
}
