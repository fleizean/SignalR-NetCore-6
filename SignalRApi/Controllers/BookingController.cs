using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DTOLayer.BookingDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _bookingService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            if (createBookingDto != null)
            {
                _bookingService.TAdd(new Booking()
                {
                    Name = createBookingDto.Name,
                    Phone = createBookingDto.Phone,
                    Mail = createBookingDto.Mail,
                    PersonCount = createBookingDto.PersonCount,
                    ReservationDate = createBookingDto.ReservationDate,
                    Status = createBookingDto.Status
                });
                return Ok("Booking added successfuly");
            }
            return NotFound("Booking not added successfuly");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var value = _bookingService.TGetById(id);
            if (value != null)
            {
                _bookingService.TDelete(value);
                return Ok("Booking deleted successfuly");
            }
            return NotFound("Booking not deleted successfuly");
        }

        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            _bookingService.TUpdate(new Booking()
            {
                BookingID = updateBookingDto.BookingID,
                Name = updateBookingDto.Name,
                Phone = updateBookingDto.Phone,
                Mail = updateBookingDto.Mail,
                PersonCount = updateBookingDto.PersonCount,
                ReservationDate = updateBookingDto.ReservationDate,
                Status = updateBookingDto.Status
            });
            return Ok("Booking updated successfuly");
        }

        [HttpGet("{id}")]
        public IActionResult GetBookingById(int id)
        {
            var value = _bookingService.TGetById(id);
            return Ok(value);
        }
    }
}

