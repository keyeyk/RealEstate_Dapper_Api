﻿using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_Ui.ViewComponents.HomePage
{
    public class _DefaultFeatureComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
