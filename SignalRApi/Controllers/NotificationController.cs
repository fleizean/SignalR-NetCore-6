using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DTOLayer.Notification;
using SignalR.EntityLayer.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : Controller
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet]
        public IActionResult NotificationList()
        {
            var values = _notificationService.TGetListAll();
            return Ok(values);
        }

        [HttpGet("NotificationCountByStatusFalseCount")]
        public IActionResult NotificationCountByStatusFalseCount()
        {
            var values = _notificationService.TNotificationCountByStatusFalse();
            return Ok(values);
        }

        [HttpGet("NotificationStatusTrue")]
        public IActionResult NotificationStatusTrue(int id)
        {
            _notificationService.TNotificationStatusTrue(id);
            return Ok("Notification status changed successfuly");
        }

        [HttpGet("NotificationStatusFalse")]
        public IActionResult NotificationStatusFalse(int id)
        {
            _notificationService.TNotificationStatusFalse(id);
            return Ok("Notification status changed successfuly");
        }

        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
        {
            if (createNotificationDto != null)
            {
                _notificationService.TAdd(new Notification()
                {
                    Type = createNotificationDto.Type,
                    Description = createNotificationDto.Description,
                    Icon = createNotificationDto.Icon,
                    Date = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                    Status = createNotificationDto.Status
                });
                return Ok("Notification added successfuly");
            }
            return NotFound("Notification not added successfuly");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNotification(int id)
        {
            var value = _notificationService.TGetById(id);
            if (value != null)
            {
                _notificationService.TDelete(value);
                return Ok("Notification deleted successfuly");
            }
            return NotFound("Notification not deleted successfuly");
        }

        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
        {
            _notificationService.TUpdate(new Notification()
            {
                NotificationID = updateNotificationDto.NotificationID,
                Type = updateNotificationDto.Type,
                Description = updateNotificationDto.Description,
                Icon = updateNotificationDto.Icon,
                Date = updateNotificationDto.Date,
                Status = updateNotificationDto.Status
            });
            return Ok("Notification updated successfuly");
        }

        [HttpGet("{id}")]
        public IActionResult GetNotificationById(int id)
        {
            var value = _notificationService.TGetById(id);
            return Ok(value);
        }
    }
}

