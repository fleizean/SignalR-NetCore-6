using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DTOLayer.SocialMediaDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var values = _mapper.Map<List<ResultSocialMediaDto>>(_socialMediaService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            if (createSocialMediaDto != null)
            {
                _socialMediaService.TAdd(new SocialMedia()
                {
                    Title = createSocialMediaDto.Title,
                    Icon = createSocialMediaDto.Icon,
                    Url = createSocialMediaDto.Url,
                    Status = true
                });
                return Ok("Social media added successfuly");
            }
            return NotFound("Social media not added successfuly");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSocialMedia(int id)
        {
            var value = _socialMediaService.TGetById(id);
            if (value != null)
            {
                _socialMediaService.TDelete(value);
                return Ok("Social media deleted successfuly");
            }
            return NotFound("Social media not deleted successfuly");
        }

        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            _socialMediaService.TUpdate(new SocialMedia()
            {
                SocialMediaID = updateSocialMediaDto.SocialMediaID,
                Title = updateSocialMediaDto.Title,
                Icon = updateSocialMediaDto.Icon,
                Url = updateSocialMediaDto.Url,
                Status = updateSocialMediaDto.Status
            });
            return Ok("Social media updated successfuly");
        }

        [HttpGet("{id}")]
        public IActionResult GetSocialMediaById(int id)
        {
            var value = _socialMediaService.TGetById(id);
            return Ok(value);
        }
    }
}

