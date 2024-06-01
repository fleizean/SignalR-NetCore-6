using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DTOLayer.OrderDetailDto;
using SignalR.EntityLayer.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : Controller
    {
        private readonly IOrderDetailService _orderDetailService;
        private readonly IMapper _mapper;

        public OrderDetailController(IOrderDetailService orderDetailService, IMapper mapper)
        {
            _orderDetailService = orderDetailService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult OrderDetailList()
        {
            var values = _mapper.Map<List<ResultOrderDetailDto>>(_orderDetailService.TGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateOrderDetail(CreateOrderDetailDto createOrderDetailDto)
        {
            if (createOrderDetailDto != null)
            {
                _orderDetailService.TAdd(new OrderDetail()
                {
                    ProductID = createOrderDetailDto.ProductID,
                    Count = createOrderDetailDto.Count,
                    UnitPrice = createOrderDetailDto.UnitPrice,
                    TotalPrice = createOrderDetailDto.TotalPrice,
                    OrderID = createOrderDetailDto.OrderID
                });
                return Ok("OrderDetail added successfuly");
            }
            return NotFound("OrderDetail not added successfuly");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrderDetail(int id)
        {
            var value = _orderDetailService.TGetById(id);
            if (value != null)
            {
                _orderDetailService.TDelete(value);
                return Ok("OrderDetail deleted successfuly");
            }
            return NotFound("OrderDetail not deleted successfuly");
        }

        [HttpPut]
        public IActionResult UpdateOrderDetail(UpdateOrderDetailDto updateOrderDetailDto)
        {
            _orderDetailService.TUpdate(new OrderDetail()
            {
                OrderDetailID = updateOrderDetailDto.OrderDetailID,
                ProductID = updateOrderDetailDto.ProductID,
                Count = updateOrderDetailDto.Count,
                UnitPrice = updateOrderDetailDto.UnitPrice,
                TotalPrice = updateOrderDetailDto.TotalPrice,
                OrderID = updateOrderDetailDto.OrderID
            });
            return Ok("OrderDetail updated successfuly");
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderDetailById(int id)
        {
            var value = _orderDetailService.TGetById(id);
            return Ok(value);
        }

    }
}

