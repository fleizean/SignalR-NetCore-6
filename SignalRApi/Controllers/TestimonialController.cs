using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DTOLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _mapper.Map<List<ResultTestimonialDto>>(_testimonialService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            if (createTestimonialDto != null)
            {
                _testimonialService.TAdd(new Testimonial()
                {
                    Name = createTestimonialDto.Name,
                    Title = createTestimonialDto.Title,
                    Comment = createTestimonialDto.Comment,
                    Rating = createTestimonialDto.Rating,
                    ImageUrl = createTestimonialDto.ImageUrl,
                    Status = true
                });
                return Ok("Testimonial added successfuly");
            }
            return NotFound("Testimonial not added successfuly");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _testimonialService.TGetById(id);
            if (value != null)
            {
                _testimonialService.TDelete(value);
                return Ok("Testimonial deleted successfuly");
            }
            return NotFound("Testimonial not deleted successfuly");
        }

        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            _testimonialService.TUpdate(new Testimonial()
            {
                TestimonialID = updateTestimonialDto.TestimonialID,
                Name = updateTestimonialDto.Name,
                Title = updateTestimonialDto.Title,
                Comment = updateTestimonialDto.Comment,
                Rating = updateTestimonialDto.Rating,
                ImageUrl = updateTestimonialDto.ImageUrl,
                Status = updateTestimonialDto.Status
            });
            return Ok("Testimonial updated successfuly");
        }

        [HttpGet("{id}")]
        public IActionResult GetTestimonialById(int id)
        {
            var value = _testimonialService.TGetById(id);
            return Ok(value);
        }
    }
}

