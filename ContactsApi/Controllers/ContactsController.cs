using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace ContactsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactsController : ControllerBase
    {
        [HttpPost]
        public void Create([FromBody] Contact contact) 
        {

        }

        [HttpGet]
        public List<Contact> Get()
        {
            return new List<Contact>();
        }

        [HttpPut("{id}")]
        public void Update([FromBody] Contact updatedContact) 
        {

        }

        [HttpDelete("{id}")]
        public void Delete([FromRoute] int id)
        {

        }
    }
}
