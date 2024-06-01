using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoneyCaseController : Controller
    {
        // GET: api/values
        private readonly IMoneyCaseService _moneyCaseService;
        private readonly IMapper _mapper;

        public MoneyCaseController(IMoneyCaseService moneyCaseService, IMapper mapper)
        {
            _moneyCaseService = moneyCaseService;
            _mapper = mapper;
        }

        [HttpGet("TotalPriceMoneyCase")]
        public IActionResult TotalPriceMoneyCase()
        {
            var values = _moneyCaseService.TTotalPriceMoneyCase();
            return Ok(values);
        }
    }
}

