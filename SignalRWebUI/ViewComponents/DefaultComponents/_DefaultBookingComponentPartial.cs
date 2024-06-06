using System;
using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.DefaultComponents
{
	public class _DefaultBookingComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

