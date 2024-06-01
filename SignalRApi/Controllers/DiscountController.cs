using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DTOLayer.DiscountDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult DiscountList()
        {
            var values = _mapper.Map<List<ResultDiscountDto>>(_discountService.TGetListAll());
            return Ok(values);
        }

        [HttpGet("DiscountListWithProducts")]
        public IActionResult DiscountListWithProducts()
        {
            var productsWithCategories = _mapper.Map<List<ResultDiscountWithProduct>>(_discountService.TGetDiscountsWithProducts());
            return Ok(productsWithCategories);
        }

        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            if (createDiscountDto != null)
            {
                _discountService.TAdd(new Discount()
                {
                    ProductID = createDiscountDto.ProductID,
                    Amount = createDiscountDto.Amount,
                    Description = createDiscountDto.Description,
                    ImageUrl = createDiscountDto.ImageUrl,
                    Status = true
                });
                return Ok("Discount added successfuly");
            }
            return NotFound("Discount not added successfuly");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDiscount(int id)
        {
            var value = _discountService.TGetById(id);
            if (value != null)
            {
                _discountService.TDelete(value);
                return Ok("Discount deleted successfuly");
            }
            return NotFound("Discount not deleted successfuly");
        }

        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            _discountService.TUpdate(new Discount()
            {
                DiscountID = updateDiscountDto.DiscountID,
                ProductID = updateDiscountDto.ProductID,
                Amount = updateDiscountDto.Amount,
                Description = updateDiscountDto.Description,
                ImageUrl = updateDiscountDto.ImageUrl,
                Status = updateDiscountDto.Status
            });
            return Ok("Discount updated successfuly");
        }

        [HttpGet("{id}")]
        public IActionResult GetDiscountById(int id)
        {
            var value = _discountService.TGetById(id);
            return Ok(value);
        }
    }
}

