﻿using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_Ui.ViewComponents.HomePage
{
    public class _DefaultServicesComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
