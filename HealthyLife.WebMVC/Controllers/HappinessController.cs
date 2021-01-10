using HappyLife.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthyLife.WebMVC.Controllers
{
    public class HappinessController : Controller
    {
        [Authorize]
        // GET: Happiness
        public ActionResult Index()
        {
            var model = new HappinessListItem[0];
            return View(model);
        }
    }
}