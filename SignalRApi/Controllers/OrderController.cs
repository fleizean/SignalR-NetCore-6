using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DTOLayer.OrderDto;
using SignalR.EntityLayer.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult OrderList()
        {
            var values = _mapper.Map<List<ResultOrderDto>>(_orderService.TGetListAll());
            return Ok(values);
        }

        [HttpGet("OrderListWithDetail")]
        public IActionResult OrderListWithDetail()
        {
            var ordersWithDetails = _orderService.TGetOrdersWithDetails();
            var ordersWithDetailsDto = _mapper.Map<List<ResultOrderWithDetail>>(ordersWithDetails);
            return Ok(ordersWithDetailsDto);
        }

        [HttpGet("TotalOrderCount")]
        public IActionResult TotalOrderCount()
        {
            var values = _orderService.TTotalOrderCount();
            return Ok(values);
        }

        [HttpGet("TotalActiveOrderCount")]
        public IActionResult TotalActiveOrderCount()
        {
            var values = _orderService.TTotalActiveOrderCount();
            return Ok(values);
        }

        [HttpGet("LastOrderPrice")]
        public IActionResult LastOrderPrice()
        {
            var values = _orderService.TLastOrderPrice();
            return Ok(values);
        }

        [HttpGet("TodayTotalPrice")]
        public IActionResult TodayTotalPrice()
        {
            var values = _orderService.TTodayTotalPrice();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateOrder(CreateOrderDto createOrderDto)
        {
            if (createOrderDto != null)
            {
                _orderService.TAdd(new Order()
                {
                    TableNumber = createOrderDto.TableNumber,
                    Description = createOrderDto.Description,
                    Date = createOrderDto.Date,
                    TotalPrice = createOrderDto.TotalPrice,
                    Status = true
                });
                return Ok("Order added successfuly");
            }
            return NotFound("Order not added successfuly");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var value = _orderService.TGetById(id);
            if (value != null)
            {
                _orderService.TDelete(value);
                return Ok("Order deleted successfuly");
            }
            return NotFound("Order not deleted successfuly");
        }

        [HttpPut]
        public IActionResult UpdateOrder(UpdateOrderDto updateOrderDto)
        {
            _orderService.TUpdate(new Order()
            {
                OrderID = updateOrderDto.OrderID,
                TableNumber = updateOrderDto.TableNumber,
                Description = updateOrderDto.Description,
                Date = updateOrderDto.Date,
                TotalPrice = updateOrderDto.TotalPrice,
                Status = updateOrderDto.Status,
            });
            return Ok("Order updated successfuly");
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderById(int id)
        {
            var value = _orderService.TGetById(id);
            return Ok(value);
        }
    }
}

