using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DTOLayer.BasketDto;
using SignalR.EntityLayer.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : Controller
    {
        private readonly IBasketService _basketService;
        private readonly IMapper _mapper;

        public BasketController(IBasketService basketService, IMapper mapper)
        {
            _basketService = basketService;
            _mapper = mapper;
        }

        [HttpGet("GetBasketByMenuTableID")]
        public IActionResult GetBasketByMenuTableID(int id)
        {
            var values = _mapper.Map<List<ResultBasketWithProductDto>>(_basketService.TGetBaskeyByMenuTableNumber(id));
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateBasket(CreateBasketDto createBasketDto)
        {
            using var context = new SignalRContext();
            if (createBasketDto != null)
            {
                _basketService.TAdd(new Basket()
                {
                    ProductID = createBasketDto.ProductID,
                    Count = 1,
                    MenuTableID = 1,
                    Price = context.Products.Where(x => x.ProductID == createBasketDto.ProductID).Select(a => a.Price).FirstOrDefault(),
                    TotalPrice = 0,
                    Status = true
                });
                return Ok("Basket added successfuly");
            }
            return NotFound("Basket not added successfuly");
        }

        [HttpGet("{id}")]
        public IActionResult GetBasketById(int id)
        {
            var value = _basketService.TGetById(id);
            return Ok(value);
        }
    }
}

