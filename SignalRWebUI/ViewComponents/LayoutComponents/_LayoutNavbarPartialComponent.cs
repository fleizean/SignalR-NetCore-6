using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace SignalRWebUI.ViewComponents.LayoutComponents
{
	public class _LayoutNavbarPartialComponent : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }

  
    }
}

