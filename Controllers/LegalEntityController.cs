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
using api.DTOs.LegalEntity;
using api.DTOs.Client;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LegalEntityController : ControllerBase
    {
        private readonly ILegalEntityService _service;

        public LegalEntityController(ILegalEntityService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LegalEntity>>> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LegalEntity?>> GetById(long id)
        {
            var legalEntity = await _service.GetById(id);
            if (legalEntity == null)
            {
                return NotFound("Legal entity not found");
            }

            return Ok(legalEntity);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<LegalEntity>> Update(long id, UpdateLegalEntityDTO dto)
        {
            var legalEntity = await _service.Update(id, dto);
            if (legalEntity == null)
            {
                return NotFound("Legal entity not found");   
            }

            return Ok(legalEntity);
        }

        [HttpPost]
        public async Task<ActionResult<LegalEntity>> Create(CreateLegalEntityDTO dto)
        {
            var legalEntity = await _service.Create(dto);
            return CreatedAtAction(
                nameof(GetById),
                new { id = legalEntity.Id },
                legalEntity
            );
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleted = await _service.Delete(id);
            if (!deleted)
            {
                return NotFound("Legal entity not found");
            }

            return NoContent();
        }

        [HttpPost("{id}/phones")]
        public async Task<IActionResult> CreatePhone(long id, CreatePhoneDTO dto)
        {
            var legalEntity = await _service.AddPhone(id, dto);
            return Ok(legalEntity);
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
        public async Task<ActionResult<LegalEntity>> UpdatePhone(long id, long phoneId, UpdatePhoneDTO dto)
        {
            var legalEntity = await _service.UpdatePhone(id, phoneId, dto);
            if (legalEntity == null)
            {
                return NotFound("Legal entity or phone not found");
            }
            return Ok(legalEntity);
        }

        [HttpDelete("{id}/phones/{phoneId}")]
        public async Task<IActionResult> DeletePhone(long id, long phoneId)
        {
            var deleted = await _service.RemovePhone(id, phoneId);
            if (!deleted)
            {
                return NotFound("Legal entity or phone not found");
            }
            return NoContent();
        }

        [HttpPost("{id}/emails")]
        public async Task<IActionResult> CreateEmail(long id, CreateEmailDTO dto)
        {
            var legalEntity = await _service.AddEmail(id, dto);
            return Ok(legalEntity);
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
        public async Task<ActionResult<LegalEntity>> UpdateEmail(long id, long emailId, UpdateEmailDTO dto)
        {
            var legalEntity = await _service.UpdateEmail(id, emailId, dto);
            if (legalEntity == null)
            {
                return NotFound("Legal entity or email not found");
            }
            return Ok(legalEntity);
        }

        [HttpDelete("{id}/emails/{emailId}")]
        public async Task<IActionResult> DeleteEmail(long id, long emailId)
        {
            var deleted = await _service.RemoveEmail(id, emailId);
            if (!deleted)
            {
                return NotFound("Legal entity or email not found");
            }
            return NoContent();
        }

        [HttpPost("{id}/addresses")]
        public async Task<IActionResult> CreateAddress(long id, CreateAddressDTO dto)
        {
            var legalEntity = await _service.AddAddress(id, dto);
            return Ok(legalEntity);
        }

        [HttpGet("{id}/addresses")]
        public async Task<ActionResult<IEnumerable<Address>>> GetAllAddresses(long id)
        {
            return Ok(await _service.GetAllAddresses(id));
        }

        [HttpGet("{id}/addresses/{addressId}")]
        public async Task<ActionResult<Address>> GetAddressById(long id, long addressId)
        {
            var address = await _service.GetAddressById(id, addressId);
            if (address == null)
            {
                return NotFound("Address not found");
            }
            return Ok(address);
        }

        [HttpPut("{id}/addresses/{addressId}")]
        public async Task<ActionResult<LegalEntity>> UpdateAddress(long id, long addressId, UpdateAddressDTO dto)
        {
            var legalEntity = await _service.UpdateAddress(id, addressId, dto);
            if (legalEntity == null)
            {
                return NotFound("Legal entity or address not found");
            }
            return Ok(legalEntity);
        }

        [HttpDelete("{id}/addresses/{addressId}")]
        public async Task<IActionResult> DeleteAddress(long id, long addressId)
        {
            var deleted = await _service.RemoveAddress(id, addressId);
            if (!deleted)
            {
                return NotFound("Legal entity or address not found");
            }
            return NoContent();
        }

    }
}
