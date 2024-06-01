using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DTOLayer.AboutDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _aboutService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
            About about = new About()
            {
                Title = createAboutDto.Title,
                Description = createAboutDto.Description,
                ImageUrl = createAboutDto.ImageUrl
            };
            if (createAboutDto != null)
            {
                _aboutService.TAdd(new About(){
                    Title = createAboutDto.Title,
                    Description = createAboutDto.Description,
                    ImageUrl = createAboutDto.ImageUrl
                });
                return Ok("About added successfuly");
            }
            return NotFound("About not added successfuly");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var value = _aboutService.TGetById(id);
            if (value != null)
            {
                _aboutService.TDelete(value);
                return Ok("About deleted successfuly");
            }
            return NotFound("About not deleted successfuly");
        }

        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            _aboutService.TUpdate(new About()
            {
                AboutID = updateAboutDto.AboutID,
                Title = updateAboutDto.Title,
                Description = updateAboutDto.Description,
                ImageUrl = updateAboutDto.ImageUrl
            });
            return Ok("About updated successfuly");
        }

        [HttpGet("{id}")]
        public IActionResult GetAboutById(int id)
        {
            var value = _aboutService.TGetById(id);
            return Ok(value);
        }
    }
}

