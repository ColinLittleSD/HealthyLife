using HappyLife.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthyLife.WebMVC.Controllers
{
    [Authorize]
    public class DietController : Controller
    {
        // GET: Diet
        public ActionResult Index()
        {
            var model = new DietListItem[0];
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}