using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DTOLayer.SliderDto;
using SignalR.EntityLayer.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : Controller
    {
        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;

        public SliderController(ISliderService sliderService, IMapper mapper)
        {
            _sliderService = sliderService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SliderList()
        {
            var values = _mapper.Map<List<ResultSliderDto>>(_sliderService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateSlider(CreateSliderDto createSliderDto)
        {
            if (createSliderDto != null)
            {
                _sliderService.TAdd(new Slider()
                {
                    Row = createSliderDto.Row,
                    Title = createSliderDto.Title,
                    Description = createSliderDto.Description,
                    Status = true
                });
                return Ok("Slider added successfuly");
            }
            return NotFound("Slider not added successfuly");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSlider(int id)
        {
            var value = _sliderService.TGetById(id);
            if (value != null)
            {
                _sliderService.TDelete(value);
                return Ok("Slider deleted successfuly");
            }
            return NotFound("Slider not deleted successfuly");
        }

        [HttpPut]
        public IActionResult UpdateSlider(UpdateSliderDto updateSliderDto)
        {
            _sliderService.TUpdate(new Slider()
            {
                SliderID = updateSliderDto.SliderID,
                Row = updateSliderDto.Row,
                Title = updateSliderDto.Title,
                Description = updateSliderDto.Description,
                Status = updateSliderDto.Status
            });
            return Ok("Slider updated successfuly");
        }

        [HttpGet("{id}")]
        public IActionResult GetSliderById(int id)
        {
            var value = _sliderService.TGetById(id);
            return Ok(value);
        }
    }
}

