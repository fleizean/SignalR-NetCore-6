using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DTOLayer.MenuTableDto;
using SignalR.EntityLayer.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuTableController : Controller
    {
        private readonly IMenuTableService _menuTableService;
        private readonly IMapper _mapper;

        public MenuTableController(IMenuTableService menuTableService, IMapper mapper)
        {
            _menuTableService = menuTableService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult MenuTableList()
        {
            var values = _mapper.Map<List<ResultMenuTableDto>>(_menuTableService.TGetListAll());
            return Ok(values);
        }

        [HttpGet("MenuTableCount")]
        public IActionResult MenuTableCount()
        {
            var menuTableCount = _menuTableService.TMenuTableCount();
            return Ok(menuTableCount);
        }


        [HttpPost]
        public IActionResult CreateMenuTable(CreateMenuTableDto createMenuTableDto)
        {
            if (createMenuTableDto != null)
            {
                _menuTableService.TAdd(new MenuTable()
                {
                    Name = createMenuTableDto.Name,
                    Status = createMenuTableDto.Status,
                });
                return Ok("MenuTable added successfuly");
            }
            return NotFound("MenuTable not added successfuly");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMenuTable(int id)
        {
            var value = _menuTableService.TGetById(id);
            if (value != null)
            {
                _menuTableService.TDelete(value);
                return Ok("MenuTable deleted successfuly");
            }
            return NotFound("MenuTable not deleted successfuly");
        }

        [HttpPut]
        public IActionResult UpdateMenuTable(UpdateMenuTableDto updateMenuTableDto)
        {
            _menuTableService.TUpdate(new MenuTable()
            {
                MenuTableID = updateMenuTableDto.MenuTableID,
                Name = updateMenuTableDto.Name,
                Status = updateMenuTableDto.Status,
            });
            return Ok("MenuTable updated successfuly");
        }

        [HttpGet("{id}")]
        public IActionResult GetMenuTableById(int id)
        {
            var value = _menuTableService.TGetById(id);
            return Ok(value);
        }
    }
}

