﻿using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_Ui.ViewComponents.Layout
{
    public class _NavbarViewComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}