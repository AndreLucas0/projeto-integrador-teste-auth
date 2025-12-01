using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Models;
using api.Interfaces.Services;
using api.DTOs.NaturalPerson;
using api.DTOs.Client;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NaturalPersonController : ControllerBase
    {
        private readonly INaturalPersonService _service;

        public NaturalPersonController(INaturalPersonService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NaturalPerson>>> GetAll()
        {
            return Ok(await _service.GetAll());
        }
    
        [HttpGet("{id}")]
        public async Task<ActionResult<NaturalPerson>> GetById(long id)
        {
            var naturalPerson = await _service.GetById(id);
            if (naturalPerson == null)
            {
                return NotFound("Natural person not found");
            }

            return Ok(naturalPerson);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, UpdateNaturalPersonDTO dto)
        {
            var naturalPerson = await _service.Update(id, dto);
            if (naturalPerson == null)
            {
                return NotFound("Natural person not found");
            }

            return Ok(naturalPerson);
        }

        [HttpPost]
        public async Task<ActionResult<NaturalPerson>> Create(CreateNaturalPersonDTO dto)
        {
            var naturalPerson = await _service.Create(dto);
            
            return CreatedAtAction(
                nameof(GetById),
                new { id = naturalPerson.Id },
                naturalPerson
            );
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNaturalPerson(long id)
        {
            var naturalPerson = await _service.Delete(id);
            if (!naturalPerson)
            {
                return NotFound("Natural person not found");
            }

            return NoContent();
        }

        [HttpPost("{id}/phones")]
        public async Task<IActionResult> CreatePhone(long id, CreatePhoneDTO dto)
        {
            var naturalPerson = await _service.AddPhone(id, dto);
            return Ok(naturalPerson);
        }

        [HttpGet("{id}/phones")]
        public async Task<ActionResult<IEnumerable<Phone>>> GetAllPhones(long id)
        {
            return Ok(await _service.GetAllPhones(id));
        }

        [HttpGet("{id}/phones/{phoneId}")]
        public async Task<ActionResult<Phone>> GetPhoneById(long id, long phoneId)
        {
            var phone = await _service.GetPhoneById(id, phoneId);
            if (phone == null)
            {
                return NotFound("Phone not found");
            }
            return Ok(phone);
        }

        [HttpPut("{id}/phones/{phoneId}")]
        public async Task<ActionResult<NaturalPerson>> UpdatePhone(long id, long phoneId, UpdatePhoneDTO dto)
        {
            var naturalPerson = await _service.UpdatePhone(id, phoneId, dto);
            if (naturalPerson == null)
            {
                return NotFound("Natural person or phone not found");
            }
            return Ok(naturalPerson);
        }

        [HttpDelete("{id}/phones/{phoneId}")]
        public async Task<IActionResult> DeletePhone(long id, long phoneId)
        {
            var deleted = await _service.RemovePhone(id, phoneId);
            if (!deleted)
            {
                return NotFound("Natural person or phone not found");
            }
            return NoContent();
        }

        [HttpPost("{id}/emails")]
        public async Task<IActionResult> CreateEmail(long id, CreateEmailDTO dto)
        {
            var naturalPerson = await _service.AddEmail(id, dto);
            return Ok(naturalPerson);
        }

        [HttpGet("{id}/emails")]
        public async Task<ActionResult<IEnumerable<Email>>> GetAllEmails(long id)
        {
            return Ok(await _service.GetAllEmails(id));
        }

        [HttpGet("{id}/emails/{emailId}")]
        public async Task<ActionResult<Email>> GetEmailById(long id, long emailId)
        {
            var email = await _service.GetEmailById(id, emailId);
            if (email == null)
            {
                return NotFound("Email not found");
            }
            return Ok(email);
        }

        [HttpPut("{id}/emails/{emailId}")]
        public async Task<ActionResult<NaturalPerson>> UpdateEmail(long id, long emailId, UpdateEmailDTO dto)
        {
            var naturalPerson = await _service.UpdateEmail(id, emailId, dto);
            if (naturalPerson == null)
            {
                return NotFound("Natural person or email not found");
            }
            return Ok(naturalPerson);
        }

        [HttpDelete("{id}/emails/{emailId}")]
        public async Task<IActionResult> DeleteEmail(long id, long emailId)
        {
            var deleted = await _service.RemoveEmail(id, emailId);
            if (!deleted)
            {
                return NotFound("Natural person or email not found");
            }
            return NoContent();
        }

        // [HttpPost("{id}/addresses")]
        // public async Task<IActionResult> CreateAddress(long id, CreateAddressDTO dto)
        // {
        //     var naturalPerson = await _service.AddAddress(id, dto);
        //     return Ok(naturalPerson);
        // }

        // [HttpGet("{id}/addresses")]
        // public async Task<ActionResult<IEnumerable<Address>>> GetAllAddresses(long id)
        // {
        //     return Ok(await _service.GetAllAddresses(id));
        // }

        // [HttpGet("{id}/addresses/{addressId}")]
        // public async Task<ActionResult<Address>> GetAddressById(long id, long addressId)
        // {
        //     var address = await _service.GetAddressById(id, addressId);
        //     if (address == null)
        //     {
        //         return NotFound("Address not found");
        //     }
        //     return Ok(address);
        // }

        // [HttpPut("{id}/addresses/{addressId}")]
        // public async Task<ActionResult<NaturalPerson>> UpdateAddress(long id, long addressId, UpdateAddressDTO dto)
        // {
        //     var naturalPerson = await _service.UpdateAddress(id, addressId, dto);
        //     if (naturalPerson == null)
        //     {
        //         return NotFound("Natural person or address not found");
        //     }
        //     return Ok(naturalPerson);
        // }

        // [HttpDelete("{id}/addresses/{addressId}")]
        // public async Task<IActionResult> DeleteAddress(long id, long addressId)
        // {
        //     var deleted = await _service.RemoveAddress(id, addressId);
        //     if (!deleted)
        //     {
        //         return NotFound("Natural person or address not found");
        //     }
        //     return NoContent();
        // }

    }
}
