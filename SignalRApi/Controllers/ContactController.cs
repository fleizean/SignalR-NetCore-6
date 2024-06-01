using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DTOLayer.ContactDto;
using SignalR.EntityLayer.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _mapper.Map<List<ResultContactDto>>(_contactService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            if (createContactDto != null)
            {
                _contactService.TAdd(new Contact()
                {
                    Location = createContactDto.Location,
                    Telephone = createContactDto.Telephone,
                    Mail = createContactDto.Mail,
                    Status = true
                });
                return Ok("Contact added successfuly");
            }
            return NotFound("Contact not added successfuly");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var value = _contactService.TGetById(id);
            if (value != null)
            {
                _contactService.TDelete(value);
                return Ok("Contact deleted successfuly");
            }
            return NotFound("Contact not deleted successfuly");
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            _contactService.TUpdate(new Contact()
            {
                ContactID = updateContactDto.ContactID,
                Location = updateContactDto.Location,
                Telephone = updateContactDto.Telephone,
                Mail = updateContactDto.Mail,
                Status = updateContactDto.Status
            });
            return Ok("Contact updated successfuly");
        }

        [HttpGet("{id}")]
        public IActionResult GetContactById(int id)
        {
            var value = _contactService.TGetById(id);
            return Ok(value);
        }
    }
   
}

