using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.ServicesAbstractions;
using Utils.Api;
using Utils.Dtos;

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
        public async Task<IActionResult> Create([FromBody] ContactRequestDto contact) 
        {
            try
            {
                await _contactService.Create(contact);

                return Ok(new ApiResponse());
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(ex.Message));
            } 
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result =  await _contactService.GetAll();

                return Ok(new ApiResponse<List<ContactResponseDto>>(result));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(ex.Message));
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ContactRequestDto updatedContact)
        {
            try
            {
                await _contactService.Update(id, updatedContact);

                return Ok(new ApiResponse());
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(ex.Message));
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                await _contactService.Delete(id);

                return Ok(new ApiResponse());
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(ex.Message));
            }
        }
    }
}
