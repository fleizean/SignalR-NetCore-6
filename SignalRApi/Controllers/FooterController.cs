using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DTOLayer.FooterDto;
using SignalR.EntityLayer.Entities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterController : Controller
    {
        private readonly IFooterService _footerService;
        private readonly IMapper _mapper;

        public FooterController(IFooterService footerService, IMapper mapper)
        {
            _footerService = footerService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult FooterList()
        {
            var values = _mapper.Map<List<ResultFooterDto>>(_footerService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateFooter(CreateFooterDto createFooterDto)
        {
            if (createFooterDto != null)
            {
                _footerService.TAdd(new Footer()
                {
                    Title = createFooterDto.Title,
                    Description = createFooterDto.Description,
                    OpeningDays = createFooterDto.OpeningDays,
                    OpeningTimes = createFooterDto.OpeningTimes,
                    Status = createFooterDto.Status
                });
                return Ok("Footer added successfuly");
            }
            return NotFound("Footer not added successfuly");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFooter(int id)
        {
            var value = _footerService.TGetById(id);
            if (value != null)
            {
                _footerService.TDelete(value);
                return Ok("Footer deleted successfuly");
            }
            return NotFound("Footer not deleted successfuly");
        }

        [HttpPut]
        public IActionResult UpdateFooter(UpdateFooterDto updateFooterDto)
        {
            _footerService.TUpdate(new Footer()
            {
                FooterID = updateFooterDto.FooterID,
                Title = updateFooterDto.Title,
                Description = updateFooterDto.Description,
                OpeningDays = updateFooterDto.OpeningDays,
                OpeningTimes = updateFooterDto.OpeningTimes,
                Status = updateFooterDto.Status
            });
            return Ok("Footer updated successfuly");
        }

        [HttpGet("{id}")]
        public IActionResult GetFooterById(int id)
        {
            var value = _footerService.TGetById(id);
            return Ok(value);
        }
    }
}

