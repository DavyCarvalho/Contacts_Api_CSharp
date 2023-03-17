using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Services;
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
        public string Create([FromBody] Contact contact) 
        {
            var resultado = _contactService.Create(contact);

            return resultado;
        }

        [HttpGet("{senha}")]
        public List<ContactResponseDto> Get([FromRoute] string senha)
        {
            var resultado = _contactService.GetAll(senha);

            return resultado;
        }

        [HttpPut]
        public string Update([FromBody] Contact updatedContact) 
        {
            var resultado = _contactService.Update(updatedContact);

            return resultado;
        }

        [HttpDelete]
        public string Delete([FromBody] Contact contact)
        {
            var resultado = _contactService.Delete(contact);

            return resultado;
        }
    }
}
