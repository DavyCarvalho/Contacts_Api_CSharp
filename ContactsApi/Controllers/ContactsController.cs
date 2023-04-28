using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.ServicesAbstractions;
using Utils.Api;
using Utils.Dtos.Contact;

namespace ContactsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IAuthService _authService;

        public ContactsController(IContactService contactService, IAuthService authService)
        {
            _contactService = contactService;
            _authService = authService;
        }

        [Authorize(Policy = "Consumer")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateContactRequestDto contact)
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

        [Authorize(Policy = "Consumer")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _contactService.GetAll();

                return Ok(new ApiResponse<List<ContactResponseDto>>(result));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(ex.Message));
            }
        }

        [Authorize(Policy = "Consumer")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CreateContactRequestDto updatedContact)
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

        [Authorize(Policy = "Consumer")]
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
