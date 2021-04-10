using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Rocket_Elevators_Customer_Portal.Controllers
{
    [Authorize]
    public class ProductManagementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
